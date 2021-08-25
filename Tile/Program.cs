using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Tile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Use arrow keys to swap tiles");
            Console.WriteLine("If you want to exit during runtime, press esc\n");
            Run mynew = new Run();
            mynew.RunGame();
            Console.ReadLine();
        }
    }
}
