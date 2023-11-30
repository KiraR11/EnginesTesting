using System;
using EnginesTesting.Model;
using ModelEngine;

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
        public static double InputTempEnvironment()
        {
            double temp;
            string inputTemp;
            bool resultCheckPosiblParse;

            ConsoleView.MessageInputTempEnvironment();
            do
            {
                inputTemp = Console.ReadLine();
                resultCheckPosiblParse = Double.TryParse(inputTemp, out temp);
                if (resultCheckPosiblParse == false)
                {
                    ConsoleView.MessageIncorrectInput();
                }

            }
            while (!resultCheckPosiblParse);
            return temp;
        }
        public static void OutputResultTestMaxPower(TestMaxPower test)
        {
            Console.WriteLine("Результаты теста на максимальную мощность двигателя:\n");
            Console.WriteLine("Максимальная мощность двигателя равна: {0}\n", test.MaxPower);
            Console.WriteLine("Скорость вращения коленвала равна: {0}\n", test.SpeedCrankshaft);
            Console.WriteLine("\n");
        }
        public static void OutputResultTestOverheatingTime(TestOverheatingTime test)
        {
            Console.WriteLine("Результаты теста на время до перегрева:\n");
            Console.WriteLine("Время работы двигателя до перегрева в секундах равно: {0}", test.OverheatingTime);
            Console.WriteLine("\n");
        }
    }
}
