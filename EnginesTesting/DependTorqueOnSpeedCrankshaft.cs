using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnginesTesting
{
    internal class DependTorqueOnSpeedCrankshaft
    {
        public DependTorqueOnSpeedCrankshaft(double torque, double speedCrankshaft)
        {
            Torque = torque;
            SpeedCrankshaft = speedCrankshaft;
        }

        public double Torque { get; }
        public double SpeedCrankshaft { get; }
    }
}
