using ModelEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
