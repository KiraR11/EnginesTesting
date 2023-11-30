using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEngine
{
    public class InternalCombustionEngine : Engine
    {
        public InternalCombustionEngine(double superheatTemp, double inertiaMoment, double coefHeatingSpeedOnTorque, double coefHeatingSpeedOnCrankshaft, double coefCoolingSpeedOnTempEngineAndEnvironment)
           : base(superheatTemp, inertiaMoment, coefHeatingSpeedOnTorque, coefHeatingSpeedOnCrankshaft, coefCoolingSpeedOnTempEngineAndEnvironment) {}
        
    }
}
