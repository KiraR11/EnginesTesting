using System;
using System.Collections.Generic;
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

            MessageInputTempEnvironment();
            do
            {
                inputTemp = Console.ReadLine();
                resultCheckPosiblParse = Double.TryParse(inputTemp, out temp);
                if (!resultCheckPosiblParse || temp < -273)
                {
                   MessageIncorrectInput();
                }

            }
            while (!resultCheckPosiblParse || temp < -273);
            return temp;
        }
        private static void OutputResultTestMaxPower(TestMaxPower test)
        {
            Console.WriteLine("\nРезультаты теста на максимальную мощность двигателя:\n");
            Console.WriteLine("\n---------------------------\n");
            Console.WriteLine("Максимальная мощность двигателя равна: {0}\n", test.MaxPower);
            Console.WriteLine("Скорость вращения коленвала равна: {0}\n", test.SpeedCrankshaft);
            Console.WriteLine("\n---------------------------\n");
            
        }
        private static void OutputResultTestOverheatingTime(TestOverheatingTime test)
        {
            Console.WriteLine("\nРезультаты теста на время до перегрева:\n");
            Console.WriteLine("\n---------------------------\n");
            Console.WriteLine("Время работы двигателя в секундах равно: {0}\n", test.OverheatingTime);
            if (test.Overheating)
                Console.WriteLine("За время работы двигатель перегрелся");
            else
                Console.WriteLine("За время работы двигатель не перегрелся");
            Console.WriteLine("\n---------------------------\n");
        }
        public static void OutputResultTest(EngineTest test)
        {
            if (test is TestMaxPower)
            {
                OutputResultTestMaxPower(test as TestMaxPower);
            }
            if (test is TestOverheatingTime)
            {
                OutputResultTestOverheatingTime(test as TestOverheatingTime);
            }
        }
        public static void OutputEngines(List<Engine> engines)
        {
            Console.WriteLine("\nДвигатели:\n");
            for (int i = 0; i < engines.Count; i++)
            {
                Console.WriteLine("{0}.Двигатель {0}", i + 1);
            }
        }
        public static T ChooseEl<T>(List<T> elements, string nameOfTypeElement)
        {
            MessageToSelectItemEnterNumber(nameOfTypeElement);
            do
            {
                string inputNumber = Console.ReadLine();
                Console.WriteLine();
                int index;
                if (IsNumberInList(elements.Count, inputNumber, out index))
                {
                    return elements[index - 1];
                }
                else
                {
                    MessageIncorrectInput();
                }
            } while (true);
        }
        private static bool IsNumberInList(int count, string indexStr, out int index)
        {
            bool tryParseChecked = int.TryParse(indexStr, out index);
            return tryParseChecked && count >= index && index > 0;
        }
        public static void MessageToSelectItemEnterNumber(string nameOfTypeElement)
        {
            Console.WriteLine("\nДля выбора {0} введите его номер\n", nameOfTypeElement);
        }
        public static void MessageInfoEngine(Engine engine)
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("\n Момент инерции двигателя: {0}", engine.InertiaMoment);
            Console.WriteLine("\n Температура перегрева двигателя: {0}", engine.SuperheatTemp); 
            Console.WriteLine("\n Коэффициент зависимости скорости нагрева от крутящего момента двигателя: {0}", engine.CoefHeatingSpeedOnTorque); 
            Console.WriteLine("\n Коэффициент зависимости скорости нагрева от скорости вращения коленвала двигателя: {0}", engine.CoefHeatingSpeedOnCrankshaft); 
            Console.WriteLine("\n Коэффициент зависимости скорости охлаждения от температуры двигателя и окружающей среды двигателя: {0}", engine.CoefCoolingSpeedOnTempEngineAndEnvironment);
            Console.WriteLine("\n---------------------------\n");
        }
        public static bool PoolYesOrNo(string question)
        {
            string yes = "y";
            string no = "n";
            Console.WriteLine("\n{0}? ({1}/{2})\n", question, yes, no);
            while (true)
            {
                string answer = Console.ReadLine()!;
                if (answer!.ToLower() == yes)
                    return true;
                else if (answer.ToLower() == no)
                    return false;
                else
                    MessageIncorrectInput();
            }
        }
        public static void OutputExperiment(List<Experiment> experiments)
        {
            Console.WriteLine("\nЭксперементы:\n");
            for (int i = 0; i < experiments.Count; i++)
            {
                Console.WriteLine("{0}.Эксперемент {0}", i + 1);
            }
        }
        public static void MessageInfoExperiment(Experiment experiment)
        {
            Console.WriteLine("\n---------------------------\n");
            for (int i = 0; i < experiment.LinearDependence.Count; i++)
            {
                Console.WriteLine("{0}. Момент инерции = {1}, Скорость вращения коленвала = {2}\n", i + 1, experiment.LinearDependence[i].Torque, experiment.LinearDependence[i].SpeedCrankshaft);
            }
            Console.WriteLine("\n---------------------------\n");
        }
        public static void MessageCompletionProgram()
        {
            Console.WriteLine("\nТестирование окончино");
            Console.ReadKey();
        }
        public static void OutpuTestName(List<string> nameTests)
        {
            Console.WriteLine("\nТесты:\n");
            for (int i = 0; i < nameTests.Count; i++)
            {
                Console.WriteLine("\n{0}. {1}\n", i + 1, nameTests[i]);
            }
        }
    }
}
