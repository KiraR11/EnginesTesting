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
        {}
        private double? _overheatingTime;
        public double? OverheatingTime
        {
            get
            {
                if (_overheatingTime != null && _overheatingTime >= 0.0) return _overheatingTime;
                else throw new Exception();
            }
            private set
            {
                if (value != null && value >= 0.0)
                    _overheatingTime = value;
                else throw new Exception();
            }
        }
        protected override void Run()
        {
            double time = 0.0; 
            for (int i = 0; i < LinearDependence.Count; i++)
            {
                if (Engine.Temp <= Engine.SuperheatTemp)
                {
                    Engine.TorqueAndSpeedCrankshaft.Torque = LinearDependence[i].Torque;
                    Engine.TorqueAndSpeedCrankshaft.SpeedCrankshaft = LinearDependence[i].SpeedCrankshaft;
                    time++;
                }
                else break;
            }
            _overheatingTime = time;
        }
    }
}
