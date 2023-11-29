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
            SuperheatTemp = superheatTemp;
            CoefHeatingSpeedOnTorque = coefHeatingSpeedOnTorque;
            CoefHeatingSpeedOnCrankshaft = coefHeatingSpeedOnCrankshaft;
            CoefCoolingSpeedOnTempEngineAndEnvironment = coefCoolingSpeedOnTempEngineAndEnvironment;
            InertiaMoment = inertiaMoment;
        }
        public double TempEnvironment
        public double Temp { get; }
        public double SuperheatTemp { get; }
        public double CoefHeatingSpeedOnTorque { get; }
        public double CoefHeatingSpeedOnCrankshaft { get; }
        public double CoefCoolingSpeedOnTempEngineAndEnvironment { get; }
        public double InertiaMoment { get; }
        public double Torque { get; }
        public double SpeedCrankshaft { get; }
        public double HeatingSpeed { get { return CalcHeatingSpeed(); } }
        public double CoolingSpeed { get {return CoolingSpeed(double tempEnvironment); } }
        public double CalcHeatingSpeed()
        {
            double result = Torque * CoefHeatingSpeedOnTorque + SpeedCrankshaft * SpeedCrankshaft * CoefHeatingSpeedOnCrankshaft;
            return result;
        }

        public double CoolingSpeed(double tempEnvironment)
        {
            double result = CoefCoolingSpeedOnTempEngineAndEnvironment * (tempEnvironment - Temp);
            return result;
        }


    }
}
