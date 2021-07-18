using System;
namespace adventureCodeReading
{
    public class Text
    {
        public static void Game(string Message)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(Message);
            Console.ResetColor();
        }

        public static void Entity(string Message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Message);
            Console.ResetColor();
        }

        public static void Player(string Message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(Message);
            Console.ResetColor();
        }

        public static void Mems(string Message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(Message);
            Console.ResetColor();
        }
    }
}
