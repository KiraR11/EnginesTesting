using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEngine
{
    public class TestMaxPower : EngineTest
    {
        public TestMaxPower(Engine engine, List<DependTorqueOnSpeedCrankshaft> dependence) : base(engine)
        {
            LinearDependence= dependence;
        }
        private double? _maxPower;
        private double? _speedCrankshaft;
        private List<DependTorqueOnSpeedCrankshaft> LinearDependence { get; }

        public double? MaxPower
        {
            get
            {
                if (_maxPower != null && _maxPower >= 0.0) return _maxPower;
                else throw new Exception();
            }
            private set
            {
                if (value != null && value >= 0.0)
                    _maxPower = value;
                else throw new Exception();
            }
        }
        public double? SpeedCrankshaft
        {
            get
            {
                if (_speedCrankshaft != null && _speedCrankshaft >= 0.0) return _speedCrankshaft;
                else throw new Exception();
            }
            private set
            {
                if (value != null && value >= 0.0)
                    _speedCrankshaft = value;
                else throw new Exception();
            }
        }
        protected override void Run()
        {
            double maxPower = 0.0;

            double speedCrankshaft = 0.0;
            for (int i = 0; i < LinearDependence.Count; i++)
            {
                Engine.TorqueAndSpeedCrankshaft.Torque = LinearDependence[i].Torque;
                Engine.TorqueAndSpeedCrankshaft.SpeedCrankshaft = LinearDependence[i].SpeedCrankshaft;
                if (Engine.Power > maxPower)
                {
                    maxPower = Engine.Power;
                    speedCrankshaft = Engine.TorqueAndSpeedCrankshaft.SpeedCrankshaft;
                }
            }
            MaxPower = maxPower;
            SpeedCrankshaft = speedCrankshaft;
        }
    }
}
