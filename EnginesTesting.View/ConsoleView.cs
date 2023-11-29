using System;

namespace View
{
    public class ConsoleView
    {
        public static void MessageIncorrectInput() 
        {
            Console.WriteLine("\nВведённые данные не верны попробуйте еще раз\n");
        }
        public static void MessageInputTempEnvironment()
        {
            Console.WriteLine("Введте температеру окружающей среды\n");
        }
    }
}
