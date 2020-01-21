using System;
using Komodo.Core;

namespace Komodo
{
    public static class Startup
    {
        [STAThread]
        static void Main()
        {
            using (var game = new KomodoGame()) {
                game.Run();
            }
        }
    }
}
