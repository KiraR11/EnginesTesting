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
        private double? _torque;
        public double Torque
        {
            get
            {
                if (_torque != null && _torque >= 0.0) return (double)_torque;
                else throw new Exception();
            }
            set
            {
                if (value >= 0.0)
                {
                    _torque = value;
                }

                else throw new Exception();
            }
        }
        private double? _speedCrankshaft;
        public double SpeedCrankshaft
        {
            get
            {
                if (_speedCrankshaft != null && _speedCrankshaft >= 0.0) return (double)_speedCrankshaft;
                else throw new Exception();
            }
            set
            {
                if (value >= 0.0)
                {
                    _speedCrankshaft = value;
                }

                else throw new Exception();
            }
        }
    }
}
