using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    public class Class1
    {
        private GameInterface handler;
        Player activePlayer;
        public Player inactivePlayer;
        char[,] board;
        Player[] players;
        public char[] PlayerPlacements;
        public bool IsTesting { get; set; }
        public Class1()
        {
            players = new Player[2];

            //Random names from http://www.behindthename.com/random/ 
            //The names are Greek ;)
            players[0] = new Player() { Name = "Player 1: Theophania", Token = 'X' }; //using object initialization syntax
            players[1] = new Player() { Name = "Player 2: Xenon", Token = 'O' };
        }

        
        /// <summary>
        /// The Tic Tac Toe game loop, 2 players.  Iterate player turns until the game
        /// is over
        /// </summary>
        public void Start()
        {
            PlayerPlacements = handler.PlayerPlacements();
            board = handler.board();
            int indexOfCurrentPlayer = 0;
            int indexOfInactivePlayer = 1;
            activePlayer = players[indexOfCurrentPlayer];
            inactivePlayer = players[indexOfInactivePlayer];
            //SetEventHandler(handler);
            while (!GameOver(handler) && !IsTesting)
            {
                Console.WriteLine("Here is the board:");
                PrintBoard();

                TakeTurn(activePlayer);
                //select the other player
                indexOfCurrentPlayer = (indexOfCurrentPlayer == 0) ? 1 : 0;
                indexOfInactivePlayer = (indexOfInactivePlayer == 1) ? 0 : 1;
                activePlayer = players[indexOfCurrentPlayer];
                inactivePlayer = players[indexOfInactivePlayer];

                //Added this slight delay for user experience.  Without it it's harder to notice the board repaint
                //try commenting it out and check out the difference.  Which do you prefer?
                System.Threading.Thread.Sleep(300);
                if (!Console.IsOutputRedirected)
                {
                    Console.Clear();
                }
            }
        }

        /// <summary>
        /// Get and set the player's desired location on the board
        /// </summary>
        /// <param name="activePlayer"></param>
        private void TakeTurn(Player activePlayer)
        {
            int[] position = PiecePlacement(activePlayer);
            board[position[0], position[1]] = activePlayer.Token;
        }


        /// <summary>
        /// Give the user instructions for piece placement and return
        /// the 2D location of the position they select
        /// </summary>
        /// <param name="activePlayer"></param>
        /// <returns></returns>
        private int[] PiecePlacement(Player activePlayer)
        {
            //you need to be using the .NET framework 4.6 for this line to work (C# 6)
            Console.WriteLine();
            Console.WriteLine($"{activePlayer.Name}, it's your turn:");
            Console.WriteLine("Make your move by entering the number of the sqaure you'd like to take:");
            PrintBoardMap();
            Console.Write("Enter the number: ");

            //todo: Prevent returning a location that's already been used
            String Input = Console.ReadLine();
            if (Input != null)
            {
                return ConvertToArrayLocation(Input);
            }
            else
            {
                return ConvertToArrayLocation("1");
            }
        }


        /// <summary>
        /// Converts a single number entered by the user to an X,Y element for reference
        /// in a 2D array
        /// </summary>
        /// <param name="boardPosition">The single number to be converted</param>
        /// <returns>The X,Y position intended to be used with a 2D array</returns>
        public int[] ConvertToArrayLocation(string boardPosition)
        {
            int position = Int32.Parse(ChangeIfLetter(boardPosition));
            position = ChangeIfTooHigh(position);
            char ActiveToken = activePlayer.Token;
            PlayerPlacements[position] = ActiveToken;
            position--; //reduce position to account for 1-based board map (done for user experience)
            int row = position / 3;
            int column = position % 3;
            return new int[] { row, column }; //inline array initialization
        }
        public string ChangeIfLetter(string boardPosition)
        {
            int n;
            if (!int.TryParse(boardPosition, out n))
            {
                boardPosition = "1";
                return boardPosition;
            }
            return boardPosition;
        }
        public int ChangeIfTooHigh(int position)
        {
            if (position > 9)
            {
                position = 9;
                return position;
            }
            return position;
        }
        /// <summary>
        /// Prints a number for every position on the board to help the user
        /// know what single number to enter
        /// </summary>
        private void PrintBoardMap()
        {
            int position = 1; //1-based board map (done for user experience)

            for (int row = 0; row <= board.GetUpperBound(0); row++)
            {
                for (int column = 0; column <= board.GetUpperBound(1); column++)
                {
                    Console.Write(position++);
                    if (column < board.GetUpperBound(1))
                    {
                        Console.Write(" - ");
                    }
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Prints the board to the console with extra dashes for legibility
        /// </summary>
        private void PrintBoard()
        {
            Console.WriteLine();
            for (int row = 0; row <= board.GetUpperBound(0); row++)
            {
                for (int column = 0; column <= board.GetUpperBound(1); column++)
                {
                    Console.Write(board[row, column]);

                    //only print the dashes for the inner columns
                    if (column < board.GetUpperBound(1))
                    {
                        Console.Write(" - ");
                    }
                    {
                        {                                                                                                                                                                                                                                                                                                                                                                 /*Congrats!  You found the easter egg!  Weren't those useless curly brackets annoying? Plus one was missing.... way out here on column 500+*/                                                         }
                    }
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// You didn't think I'd write every method for you, did you?
        /// </summary>
        /// <returns></returns>
        private bool GameOver(GameInterface gi)
        {
            if (handler != null)
            {
                if (handler.WinConditions())
                {
                    return true;
                }
            }
            return false;
        }
        public void SetEventHandler(GameInterface gi)
        {
            handler = gi;
        }
    }
}
