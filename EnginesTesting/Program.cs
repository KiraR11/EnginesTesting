using System;
using System.Collections.Generic;

namespace EnginesTesting
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // ввод температуры окружающей среды

            /*double temp;
            string inputTemp;
            bool resultCheckPosiblParse;

            Console.WriteLine("Введте температеру окружающей среды\n");
            do
            {
                inputTemp = Console.ReadLine();
                resultCheckPosiblParse = Double.TryParse(inputTemp, out temp);
                if(resultCheckPosiblParse == false)
                {
                    Console.WriteLine("\nВведённые данные не верны попробуйте еще раз\n");
                }
                    
            }
            while (!resultCheckPosiblParse);*/

            /*
             
             Проблемы:

            *  Изменение начальных параметров двигателя для других тестов при его тестировании первым тестом
            
            * Попробывать связать крутящий момент со скоростью коленвала в Двигателе с помощью DependTorqueOnSpeedCrankshaft
            
            * Дискретность тестирования с еденицей времени в одну секунду
            
            */

            InternalCombustionEngine engine = new InternalCombustionEngine(25, 110.0, 10.0, 0.01, 0.0001, 0.1);
            List<DependTorqueOnSpeedCrankshaft> dependence = new List<DependTorqueOnSpeedCrankshaft>() {
                new (20.0,0.0), 
                new (75.0,75.0), 
                new (100.0,150.0), 
                new (105.0,200.0), 
                new (75.0,250.0), 
                new (0.0,300.0)
            };
            TestMaxPower testOne = new TestMaxPower(engine,dependence);
            Console.WriteLine("Результаты первого теста:\n");
            Console.WriteLine("Максимальная мощность двигателя равна: {0}\n",testOne.MaxPower);
            Console.WriteLine("Скорость вращения коленвала равна: {0}\n",testOne.SpeedCrankshaft);
            Console.WriteLine("\n");

            TestOverheatingTime testTwo = new TestOverheatingTime(engine, dependence);
            Console.WriteLine("Результаты второго теста:\n");
            Console.WriteLine("Время работы двигателя до перегрева в секундах равно: {0}", testTwo.OverheatingTime);

        }
    }
}
