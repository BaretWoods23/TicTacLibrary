using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    public interface GameInterface
    {
        bool WinConditions();
        char[,] board();
        char[] PlayerPlacements();

    }
}
