using System;

namespace ModelEngine
{
    public class TestMaxPower : EngineTest
    {
        public TestMaxPower(Engine engine, Experiment experiment) : base(engine, experiment) { }

        private double? _maxPower;
        private double? _speedCrankshaft;

        public double MaxPower
        {
            get
            {
                if (_maxPower != null && _maxPower >= 0.0) return (double)_maxPower;
                else throw new Exception();
            }
            private set
            {
                if (value >= 0.0)
                    _maxPower = value;
                else throw new Exception();
            }
        }
        public double SpeedCrankshaft
        {
            get
            {
                if (_speedCrankshaft != null && _speedCrankshaft >= 0.0) return (double)_speedCrankshaft;
                else throw new Exception();
            }
            private set
            {
                if (value >= 0.0)
                    _speedCrankshaft = value;
                else throw new Exception();
            }
        }
        protected override void Run()
        {
            double maxPower = 0.0;

            double speedCrankshaft = 0.0;
            for (int i = 0; i < Experiment.LinearDependence.Count; i++)
            {
                Engine.TorqueAndSpeedCrankshaft = Experiment.LinearDependence[i];
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
