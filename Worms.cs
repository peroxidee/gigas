namespace gigas;

using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Net.Sockets;

public class Worms
{
    public static async Task Def(string[] args)
    {
        List<string> addrs = new List<string>();
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
    }

    private static async Task<bool> Spread(List<string> adrs)
    {
        using (TcpClient tcl = new TcpClient ())
        {
            for (int i = 0; i <= adrs.Count; i++)
            {
                try
                {
                    IPAddress nadr = new IPAddress(adrs[i]);
                    IPEndPoint edp = new IPEndPoint(nadr, 135);
                    if (await tcl.Connect(edp))
                    {
                        
                    }

                }
                catch
                {
                    return false;
                }
                    
            }
            
        }
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