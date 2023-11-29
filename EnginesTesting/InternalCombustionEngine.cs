using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnginesTesting
{
    internal class InternalCombustionEngine : Engine
    {
        public InternalCombustionEngine(double temp, double superheatTemp, double inertiaMoment, double coefHeatingSpeedOnTorque, double coefHeatingSpeedOnCrankshaft, double coefCoolingSpeedOnTempEngineAndEnvironment)
           : base(temp, superheatTemp, inertiaMoment, coefHeatingSpeedOnTorque, coefHeatingSpeedOnCrankshaft, coefCoolingSpeedOnTempEngineAndEnvironment) {}
        
    }
}
