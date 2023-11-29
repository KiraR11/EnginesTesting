using ModelEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View;
using WorkingData;

namespace Flow
{
    
    internal class MainFlow
    {
        public static void StartProgram() 
        {

            Engine engine = new InternalCombustionEngine(25, 110.0, 10.0, 0.01, 0.0001, 0.1);
            List<DependTorqueOnSpeedCrankshaft> dependence = new List<DependTorqueOnSpeedCrankshaft>() {
                new (20.0,0.0),
                new (75.0,75.0),
                new (100.0,150.0),
                new (105.0,200.0),
                new (75.0,250.0),
                new (0.0,300.0)
            };
            TestMaxPower testOne = new TestMaxPower(engine, dependence);
            Console.WriteLine("Результаты первого теста:\n");
            Console.WriteLine("Максимальная мощность двигателя равна: {0}\n", testOne.MaxPower);
            Console.WriteLine("Скорость вращения коленвала равна: {0}\n", testOne.SpeedCrankshaft);
            Console.WriteLine("\n");

            TestOverheatingTime testTwo = new TestOverheatingTime(engine, dependence);
            Console.WriteLine("Результаты второго теста:\n");
            Console.WriteLine("Время работы двигателя до перегрева в секундах равно: {0}", testTwo.OverheatingTime);
        }
        private double InputTempEnvironment()
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
    }
}
