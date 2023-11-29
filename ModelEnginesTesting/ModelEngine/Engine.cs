using ModelEnginesTesting.ModelEngine;

namespace EnginesTesting
{
    public abstract class Engine
    {
        protected Engine(double tempEnvironment, double superheatTemp, double inertiaMoment, double coefHeatingSpeedOnTorque, double coefHeatingSpeedOnCrankshaft, double coefCoolingSpeedOnTempEngineAndEnvironment)
        {
            Temp = tempEnvironment;
            TempEnvironment = tempEnvironment;
            SuperheatTemp = superheatTemp;
            CoefHeatingSpeedOnTorque = coefHeatingSpeedOnTorque;
            CoefHeatingSpeedOnCrankshaft = coefHeatingSpeedOnCrankshaft;
            CoefCoolingSpeedOnTempEngineAndEnvironment = coefCoolingSpeedOnTempEngineAndEnvironment;
            InertiaMoment = inertiaMoment;
        }
        public double TempEnvironment { get; } //?
        public double Temp { get; private set; }
        public double SuperheatTemp { get; }
        public double CoefHeatingSpeedOnTorque { get; }
        public double CoefHeatingSpeedOnCrankshaft { get; }
        public double CoefCoolingSpeedOnTempEngineAndEnvironment { get; }
        public double InertiaMoment { get; }

        private DependTorqueOnSpeedCrankshaft _torqueAndSpeedCrankshaft = new DependTorqueOnSpeedCrankshaft(0.0, 0.0);
        public DependTorqueOnSpeedCrankshaft TorqueAndSpeedCrankshaft 
        {
            get
            {
                return _torqueAndSpeedCrankshaft;
            }
            set
            {
                _torqueAndSpeedCrankshaft = value;
                Temp = CalcTemp();
            }
        }
        private double HeatingSpeed { get{ return CalcHeatingSpeed(); } }
        private double CoolingSpeed { get { return CalcCoolingSpeed(); } }
         
        public double Power { get {return CalcPower(); } }

        private double CalcHeatingSpeed()
        {
            double result = TorqueAndSpeedCrankshaft.Torque * CoefHeatingSpeedOnTorque + TorqueAndSpeedCrankshaft.SpeedCrankshaft * TorqueAndSpeedCrankshaft.SpeedCrankshaft * CoefHeatingSpeedOnCrankshaft;
            return result;
        }

        private double CalcCoolingSpeed()
        {
            double result = CoefCoolingSpeedOnTempEngineAndEnvironment * (TempEnvironment - Temp);
            return result;
        }
        private double CalcPower()
        {
            double result = TorqueAndSpeedCrankshaft.Torque * TorqueAndSpeedCrankshaft.SpeedCrankshaft / 1000;
            return result;
        }
        private double CalcTemp()
        {
            double result = Temp + HeatingSpeed + CoolingSpeed;
            return result;
        }
        public void CoolDown()//передоватьTempEnvironment?
        {
            Temp = TempEnvironment;    
        }

    }
}
