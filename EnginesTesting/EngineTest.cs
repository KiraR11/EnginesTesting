using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnginesTesting
{
    internal abstract class EngineTest
    {
        public EngineTest(Engine engine,List<DependTorqueOnSpeedCrankshaft> dependence)
        {
            Engine = engine;
            LinearDependence = dependence;
            Run();
        }
        protected Engine Engine { get;}
        protected List<DependTorqueOnSpeedCrankshaft> LinearDependence { get; }
        protected abstract void Run();
    }
}
