using ModelEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEngine
{
    public abstract class EngineTest
    {
        public EngineTest(Engine engine,Experiment experiment)
        {
            Engine = engine;
            Experiment = experiment;
            Engine.CoolDown(experiment.TempEnvironment);
            Run();
        }
        protected Engine Engine { get; }
        protected abstract void Run();
        public Experiment Experiment { get;}
    }
}
