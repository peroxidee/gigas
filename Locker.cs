using System.Drawing;
using System.Windows.Forms;


namespace gigas;

public class Locker
{


    public static void Pos()
    {
        while (1==1)
        {
            Console.SetCursorPosition(0,0 );
            if (Console.ReadKey().Key != ConsoleKey.K && Console.ReadKey().Key != ConsoleKey.Enter)
            {
                break;
            }
            
        }
    }
    
}