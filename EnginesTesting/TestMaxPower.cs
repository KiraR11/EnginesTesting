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
        {}
        private double? _maxPower;
        private double? _speedCrankshaft;

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
            double maxPower = Engine.Power;

            double speedCrankshaft = (double)Engine.SpeedCrankshaft;
            for (int i = 0; i < LinearDependence.Count; i++)
            {
                Engine.Torque = LinearDependence[i].Torque;
                Engine.SpeedCrankshaft = LinearDependence[i].SpeedCrankshaft;
                if (Engine.Power > maxPower)
                {
                    maxPower = Engine.Power;
                    speedCrankshaft = (double)Engine.SpeedCrankshaft;
                }
            }
            MaxPower= maxPower;
            SpeedCrankshaft= speedCrankshaft;
        }
    }
}
