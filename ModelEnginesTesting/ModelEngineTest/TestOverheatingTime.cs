using System;
namespace ModelEngine
{
    public class TestOverheatingTime : EngineTest
    {
        public TestOverheatingTime(Engine engine,Experiment experiment) : base(engine, experiment) { }

        public bool Overheating { get; private set; } = false;

        private double? _overheatingTime;
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
                    Engine.TorqueAndSpeedCrankshaft = Experiment.LinearDependence[i];
                    time++;
                }
                else 
                {
                    Overheating= true;
                    break;
                }
                
            }
            _overheatingTime = time;
        }
    }
}
