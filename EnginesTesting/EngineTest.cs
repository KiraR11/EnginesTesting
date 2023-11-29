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
        }
        public Engine Engine { get;}
        public List<DependTorqueOnSpeedCrankshaft> LinearDependence { get; }
        abstract public void Run();
    }
}
