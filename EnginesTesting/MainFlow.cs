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
        public static List<EngineTest> StartProgram(List<Engine> engines,List<List<DependTorqueOnSpeedCrankshaft>> dependsTorqueOnSpeeds) 
        {
            double temp = ConsoleView.InputTempEnvironment();
            List<EngineTest> tests = new();
            List<Experiment> experiments = GetExperiments(dependsTorqueOnSpeeds, temp);
            do
            {
                Engine engine = ChoiseEngine(engines);
                Experiment experiment = ChoiseExperiment(experiments);
                List<string> NameTests = new List<string> { "Тест на максимальную мощность", "Тест время до переграва" };

                EngineTest test = ChoiseTest(engine, experiment, NameTests);
                tests.Add(test);
                ConsoleView.OutputResultTest(test);
            } while (ConsoleView.PoolYesOrNo("Продолжить тестирование?"));

            return tests;
        }
        private static Engine ChoiseEngine(List<Engine> engines)
        {
            Engine engine;
            do
            {
                ConsoleView.OutputEngines(engines);
                engine = ConsoleView.ChooseEl(engines, "двителя");
                ConsoleView.MessageInfoEngine(engine);
            } while (!ConsoleView.PoolYesOrNo("Оставить выбранный двигатель"));
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
            } while (!ConsoleView.PoolYesOrNo("Оставить выбранный эксперемент"));
            return experiment;
        }
        private static EngineTest ChoiseTest(Engine engine,Experiment experiment,List<string> nameTests)
        {
            EngineTest test = null;
            do
            {
                ConsoleView.OutpuTestName(nameTests);
                string NameTest = ConsoleView.ChooseEl(nameTests, "теста");
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
