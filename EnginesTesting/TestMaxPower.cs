using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnginesTesting
{
    internal class TestMaxPower : EngineTest
    {
        public TestMaxPower(Engine engine, List<DependTorqueOnSpeedCrankshaft> dependence) : base(engine, dependence)
        {
            Run();
        }
        public double MaxPower { get;private set; }//сделать больше нуля на set
        public double SpeedCrankshaft { get; private set; }//сделать больше нуля на set
        public override void Run()
        {
            for (int i = 0; i < LinearDependence.Count; i++)
            {
                Engine.Torque = LinearDependence[i].Torque;
                Engine.SpeedCrankshaft = LinearDependence[i].SpeedCrankshaft;
            }
        }
    }
}
