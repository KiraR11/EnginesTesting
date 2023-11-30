using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEngine
{
    public class TestOverheatingTime : EngineTest
    {
        public TestOverheatingTime(Engine engine,Experiment experiment) : base(engine, experiment) { }

        private double? _overheatingTime;
        private List<DependTorqueOnSpeedCrankshaft> LinearDependence { get; }
        public double OverheatingTime
        {
            get
            {
                if (_overheatingTime != null && _overheatingTime >= 0.0) return (double)_overheatingTime;
                else throw new Exception();
            }
            private set
            {
                if (value >= 0.0)
                    _overheatingTime = value;
                else throw new Exception();
            }
        }
        protected override void Run()
        {
            double time = 0.0; 
            for (int i = 0; i < Experiment.LinearDependence.Count; i++)
            {
                if (Engine.Temp <= Engine.SuperheatTemp)
                {
                    Engine.TorqueAndSpeedCrankshaft.Torque = Experiment.LinearDependence[i].Torque;
                    Engine.TorqueAndSpeedCrankshaft.SpeedCrankshaft = Experiment.LinearDependence[i].SpeedCrankshaft;
                    time++;
                }
                else break;
            }
            _overheatingTime = time;
        }
    }
}
