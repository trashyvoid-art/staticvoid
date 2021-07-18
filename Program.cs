using System;
using static System.Console;

/*
 * STATIC VOID()
 * By Nasr Bin Safwan
 * With help from Karen Spriggs
 */

namespace adventureCodeReading
{
    class MainClass
    {
        public static void Main()
        {
            Text.Mems(@" ___  ____   __   ____  ____  ___    _  _  _____  ____  ____    _  _  
/ __)(_  _) /__\ (_  _)(_  _)/ __)  ( \/ )(  _  )(_  _)(  _ \  / )( \ 
\__ \  )(  /(__)\  )(   _)(_( (__    \  /  )(_)(  _)(_  )(_) )( (  ) )
(___/ (__)(__)(__)(__) (____)\___)    \/  (_____)(____)(____/  \_)(_/ 

");

            Text.Game("|| PRESS ANY KEY TO START ||");
            ReadKey();
            Clear();
            Game game = new Game();
        }
    }
}
