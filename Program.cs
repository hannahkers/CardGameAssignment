using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CardGameAssignment.Utility;

namespace CardGameAssignment
{
    class Program
    {
        static void Main()
        {
            Application game = new Application();
            game.LoadGame();
            Pause();
        }
    }
}
