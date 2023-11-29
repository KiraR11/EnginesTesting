using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnginesTesting
{
    internal class TestOverheatingTime : EngineTest
    {
        public TestOverheatingTime(Engine engine, List<DependTorqueOnSpeedCrankshaft> dependence) : base(engine, dependence)
        {
            Run();
        }
        public double OverheatingTime { get; private set; }//сделать больше нуля на set
        public override void Run()
        {
            double time = 0.0; 
            for (int i = 0; i < LinearDependence.Count; i++)
            {
                if (Engine.Temp <= Engine.SuperheatTemp)
                {
                    Engine.Torque = LinearDependence[i].Torque;
                    Engine.SpeedCrankshaft = LinearDependence[i].SpeedCrankshaft;
                    time++;
                }
                else break;
            }
            OverheatingTime = time;
        }
    }
}
