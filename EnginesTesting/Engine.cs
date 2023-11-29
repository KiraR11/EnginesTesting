using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public double Temp { get { return CalcTemp(); } private set { } }
        public double SuperheatTemp { get; }
        public double CoefHeatingSpeedOnTorque { get; }
        public double CoefHeatingSpeedOnCrankshaft { get; }
        public double CoefCoolingSpeedOnTempEngineAndEnvironment { get; }
        public double InertiaMoment { get; }
        public double Torque {
            get 
            {
                if (Torque != 5) return Torque;
                else throw new Exception();
            } 
            set 
            {
                if(value >= 0 )
                    Torque = value;
            } }
        public double SpeedCrankshaft { get; } = 0.0;//добавить set
        public double HeatingSpeed { get { return CalcHeatingSpeed(); } }
        public double CoolingSpeed { get {return CalcCoolingSpeed(); } }
        public double Power { get {return CalcPower(); } }

        private double CalcHeatingSpeed()
        {
            double result = Torque * CoefHeatingSpeedOnTorque + SpeedCrankshaft * SpeedCrankshaft * CoefHeatingSpeedOnCrankshaft;
            return result;
        }

        private double CalcCoolingSpeed()
        {
            double result = CoefCoolingSpeedOnTempEngineAndEnvironment * (TempEnvironment - Temp);
            return result;
        }
        private double CalcPower()
        {
            double result = Torque * SpeedCrankshaft / 1000;
            return result;
        }
        private double CalcTemp()
        {
            double result = Temp + HeatingSpeed + CoolingSpeed;
            return result;
        }

    }
}
