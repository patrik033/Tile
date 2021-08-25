using System;
using System.Collections.Generic;
using System.Text;

namespace Tile
{
    class Run
    {
        readonly Game game = new Game();
        public void RunGame()
        {
            game.CallPopulate();
            while (true != game.CheckForWinner())
            {
                game.CallMove();
            }
            Console.WriteLine("You won");
            Console.WriteLine("Enter any key to exit");
        }

        






    }
}
