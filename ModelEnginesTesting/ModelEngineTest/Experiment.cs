using System.Collections.Generic;

namespace ModelEngine
{
    public class Experiment
    {
        public Experiment(List<DependTorqueOnSpeedCrankshaft> linearDependence, double tempEnvironment)
        {
            LinearDependence = linearDependence;
            TempEnvironment = tempEnvironment;
        }

        public List<DependTorqueOnSpeedCrankshaft> LinearDependence { get; }
        public double TempEnvironment { get; }
    }
}
