using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 

namespace EnginesTesting.Flow
{
    internal class MainFlow
    {
        public static void StartProgram() 
        {


        }
        private double InputTempEnvironment()
        {
            double temp;
            string inputTemp;
            bool resultCheckPosiblParse;

            Console.WriteLine("Введте температеру окружающей среды\n");
            do
            {
                inputTemp = Console.ReadLine();
                resultCheckPosiblParse = Double.TryParse(inputTemp, out temp);
                if (resultCheckPosiblParse == false)
                {
                    ConsoleView.
                }

            }
            while (!resultCheckPosiblParse);
            return temp;
        }
    }
}
