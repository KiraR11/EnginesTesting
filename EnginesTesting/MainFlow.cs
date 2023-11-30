using ModelEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using View;
using WorkingData;

namespace Flow
{
    
    internal class MainFlow
    {
        public static void StartProgram(List<Engine> engines,List<List<DependTorqueOnSpeedCrankshaft>> dependsTorqueOnSpeeds) 
        {
            double temp = ConsoleView.InputTempEnvironment();
            List<Experiment> experiments = GetExperiments(dependsTorqueOnSpeeds, temp);
            do
            {
                Engine engine = ChoiseEngine(engines);
                Experiment experiment = ChoiseExperiment(experiments);
                List<string> NameTests = new List<string> { "Тест на максимальную мощность", "Тест время до переграва" };

                EngineTest test = ChoiseTest(engine, experiment, NameTests);

                ConsoleView.OutputResultTest(test);
            } while (ConsoleView.PoolYesOrNo("Продолжить тестирование?"));

            /*Engine engine = new InternalCombustionEngine(110.0, 10.0, 0.01, 0.0001, 0.1);
            Experiment experiment = new Experiment
                (
                new List<DependTorqueOnSpeedCrankshaft>() {
                new (20.0,0.0),
                new (75.0,75.0),
                new (100.0,150.0),
                new (105.0,200.0),
                new (75.0,250.0),
                new (0.0,300.0)
            },
                temp
                );
            TestMaxPower testOne = new TestMaxPower(engine, experiment);
            TestOverheatingTime testTwo = new TestOverheatingTime(engine, experiment);
            */
        }
        private static Engine ChoiseEngine(List<Engine> engines)
        {
            Engine engine;
            do
            {
                ConsoleView.OutputEngines(engines);
                engine = ConsoleView.ChooseEl(engines, "двителя");
                ConsoleView.MessageInfoEngine(engine);
            } while (!ConsoleView.PoolYesOrNo("Оставить выбранный двигатель?"));
            return engine;
        }
        private static Experiment ChoiseExperiment(List<Experiment> experiments)
        {
            Experiment experiment;
            do
            {
                ConsoleView.OutputExperiment(experiments);
                experiment = ConsoleView.ChooseEl(experiments, "эксперемента");
                ConsoleView.MessageInfoExperiment(experiment);
            } while (!ConsoleView.PoolYesOrNo("Оставить выбранный эксперемент?"));
            return experiment;
        }
        private static EngineTest ChoiseTest(Engine engine,Experiment experiment,List<string> NameTests)
        {
            EngineTest test = null;
            do
            {
                for (int i = 0; i < NameTests.Count; i++)
                {
                    Console.WriteLine("{0}. {1}", i, NameTests[i]);
                }
                string NameTest = ConsoleView.ChooseEl(NameTests, "теста");
                if (NameTest == "Тест на максимальную мощность")
                    test = new TestMaxPower(engine, experiment);
                if (NameTest == "Тест время до переграва")
                    test = new TestOverheatingTime(engine, experiment);
            } while (!ConsoleView.PoolYesOrNo("Оставить выбранный тест?"));
            return test;
        }
        private static List<Experiment> GetExperiments(List<List<DependTorqueOnSpeedCrankshaft>> dataExperiment,double temp)
        {
            List<Experiment> experiments = new();
            foreach (List<DependTorqueOnSpeedCrankshaft> depends in dataExperiment)
                experiments.Add(new Experiment(depends, temp));
            return experiments;
        }
    }
}
