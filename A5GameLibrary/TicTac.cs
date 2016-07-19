using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class TicTac : GameLibrary.GameInterface
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
            e.SetEventHandler(this);
            e.Start();

        }
        private bool CheckHorizontal(char ActiveToken)
        {
            int start = 1;
            int end = 3;
            for (int i = 0; i <= 2; i++)
            {
                int gamewinCheck = 0;
                for (int j = start; j <= end; j++)
                {
                    if (PlayerPlacements[j] == ActiveToken)
                    {
                        gamewinCheck += 1;
                    }
                }
                if (gamewinCheck > 2)
                {
                    return true;
                }
                start += 3;
                end += 3;
            }
            return false;
        }
        private bool CheckVertical(char ActiveToken)
        {
            int start = 1;
            int end = 9;
            for (int i = 0; i <= 2; i++)
            {
                int gamewinCheck = 0;
                for (int j = start; j < end; j += 3)
                {
                    if (PlayerPlacements[j] == ActiveToken)
                    {
                        gamewinCheck += 1;
                    }
                }
                if (gamewinCheck > 2)
                {
                    return true;
                }
                start += 1;
                end += 1;
            }
            return false;
        }
        private bool CheckDiag(char ActiveToken)
        {
            int start = 1;
            int end = 10;
            int flipCount = 4;
            int gamewinCheck = 0;
            for (int j = start; j < end; j += flipCount)
            {
                if (PlayerPlacements[j] == ActiveToken)
                {
                    gamewinCheck += 1;
                }
                if (gamewinCheck > 2)
                {
                    return true;
                }
                if (flipCount == 4)
                {
                    start += 2;
                    flipCount -= 2;
                }
            }
            return false;
        }
        public bool WinConditions()
        {
            char ActiveToken = GameLibrary.Class1.inactivePlayer.Token;
            if (CheckHorizontal(ActiveToken) || CheckVertical(ActiveToken) || CheckDiag(ActiveToken))
            {
                return true;
            }
            return false;
        }
    }
}