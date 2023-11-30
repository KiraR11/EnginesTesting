using System;

namespace ModelEngine
{
    public class DependTorqueOnSpeedCrankshaft
    {
        public DependTorqueOnSpeedCrankshaft(double torque, double speedCrankshaft)
        {
            _torque = torque;
            _speedCrankshaft = speedCrankshaft;
        }
        private double? _torque;
        public double Torque
        {
            get
            {
                if (_torque != null && _torque >= 0.0) return (double)_torque;
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
        }
    }
}
