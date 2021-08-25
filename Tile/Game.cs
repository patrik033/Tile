using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace Tile
{
    class Game
    {

        private const int GameSize = 3;
        private int x, y;
        private readonly Tile[,] myTiles = new Tile[GameSize,GameSize];
        

        public void CallPopulate()
        {
            PopulateArray();
            PrintArray();
            Shuffle();
        }
        public void CallMove()
        {
            Move();
        }

        private void Shuffle()
        {
            for (int a = 0; a < 1; a++)
            {
                for (int i = 0; i < GameSize - 1; i++)
                {
                    //move left
                    Tile temp = myTiles[x, y];
                    myTiles[x, y] = myTiles[x, y - 1];
                    myTiles[x, y - 1] = temp;
                    PrintArray();
                }
                for (int i = 0; i < GameSize - 1; i++)
                {
                    //move up
                    Tile temp = myTiles[x, y];
                    myTiles[x, y] = myTiles[x - 1, y];
                    myTiles[x - 1, y] = temp;
                    PrintArray();
                    Console.WriteLine("\t---------------------");
                }
                //move right
                for (int j = 0; j < GameSize - 1; j++)
                {
                    Tile temp = myTiles[x, y];
                    myTiles[x, y] = myTiles[x, y + 1];
                    myTiles[x, y + 1] = temp;
                    PrintArray();
                }
                //move down to starting pos
                for (int j = 0; j < GameSize - 1; j++)
                {
                    Tile temp = myTiles[x, y];
                    myTiles[x, y] = myTiles[x + 1, y];
                    myTiles[x + 1, y] = temp;
                    PrintArray();
                }


            }
        }
        private void PopulateArray()
        {
            int num = 1;
            for (int i = 0; i < GameSize; i++)
            {
                for (int j = 0; j < GameSize; j++)
                {
                    myTiles[i, j] = new Tile(num);
                    num++;
                }
            }
            //set last element as "0"
            //if not, a grid with size 2 will become impossible to solve
            num = 0;
            myTiles[GameSize - 1, GameSize - 1] = new Tile(num);
        }
        public bool CheckForWinner()
        {
            int i, j;
            int winningCondition = 1;
            for (i = 0; i < GameSize; i++)
            {
                for (j = 0; j < GameSize; j++)
                {
                    if ((winningCondition < GameSize * GameSize) && (myTiles[i, j].X != winningCondition++))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private void PrintArray()
        {
            int rowCount = myTiles.GetLength(0);
            int colCount = myTiles.GetLength(1);
            Console.Clear();
            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                {
                    if (myTiles[row, col].X == 0)
                    {
                        x = row; y = col;
                        //write the "0" element with green console color
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("\t" + myTiles[row, col].X);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("  | ");
                    }
                    else
                    {
                        //write every other element
                        Console.Write("\t" + myTiles[row, col].X + "  | ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        private void Move()
        {
            ConsoleKeyInfo input;
            input = Console.ReadKey(true);

            if (input.Key == ConsoleKey.DownArrow)
            {
                if (x == GameSize - 1)
                    Console.WriteLine("Invalid move");
                else
                {
                    Tile temp = myTiles[x, y];
                    myTiles[x, y] = myTiles[x + 1, y];
                    myTiles[x + 1, y] = temp;
                    PrintArray();
                    Console.WriteLine("\t---------------------");
                }
            }
            if (input.Key == ConsoleKey.LeftArrow)
            {
                if (y == 0)
                    Console.WriteLine("Invalid move");
                else
                {
                    Tile temp = myTiles[x, y];
                    myTiles[x, y] = myTiles[x , y-1];
                    myTiles[x , y-1] = temp;
                    PrintArray();
                    Console.WriteLine("\t---------------------");
                }
            }
            if (input.Key == ConsoleKey.UpArrow)
            {
                if (x == 0)
                    Console.WriteLine("Invalid move");
                else
                {
                    Tile temp = myTiles[x, y];
                    myTiles[x, y] = myTiles[x-1, y ];
                    myTiles[x-1, y ] = temp;
                    PrintArray();
                    Console.WriteLine("\t---------------------");

                }
            }
            if (input.Key == ConsoleKey.RightArrow)
            {
                if (y == GameSize - 1)
                    Console.WriteLine("Invalid move");
                else
                {
                    Tile temp = myTiles[x, y];
                    myTiles[x, y] = myTiles[x, y + 1];
                    myTiles[x, y + 1] = temp;
                    PrintArray();
                    Console.WriteLine("\t---------------------");
                }
            }
            //press escape key to exit the program
            if (input.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
        }
        

    }
}

