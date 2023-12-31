﻿using ModelEngine;
using System;
using System.Collections.Generic;
using WorkingData;
using View;

namespace Flow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (Data.IsCorrect(args))
            {
                Data data = new(args);
                List<Engine> engines = data.GetEngines();
                List<List<DependTorqueOnSpeedCrankshaft>> dataExperimant = data.GetDataExperimant();
                MainFlow.StartProgram(engines,dataExperimant);
                ConsoleView.MessageCompletionProgram();
            }
            else
            {
                ConsoleView.MessageIncorrectInput();
            }
        }
    }
}
