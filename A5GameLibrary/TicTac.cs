using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class TicTac
    {
        static void Main(string[] args)
        {
            TicTac p = new TicTac();
            p.Start();
        }
        char[,] board = new char[3, 3];
        char[] PlayerPlacements = new char[10];
        private void Start()
        {
            GameLibrary.Class1 e = new GameLibrary.Class1();
            e.Start();
        }
    }
}