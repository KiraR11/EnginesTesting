using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using ModelEngine;

namespace WorkingData
{
    public class Data
    {
        public Data(string[] nameFiles)
        {
            CurrentDirectory = $"{Environment.CurrentDirectory}";
            NameFiles = nameFiles;
        }
        private string[] NameFiles;
        private string CurrentDirectory { get; set; }
        private string EnginesJsonPath { get { return CurrentDirectory + "\\JsonData\\" + NameFiles[0]; } }
        private string LineDependJsonPath { get { return CurrentDirectory + "\\JsonData\\" + NameFiles[1]; } }

        public static bool IsCorrect(string[] args)
        {
            if (args.Length == 2)
            {
                return args.All(x => x.Contains(".json"));
            }
            return false;
        }
        public List<Engine> GetEngines()
        {
            try
            {
                string textJson = File.ReadAllText(EnginesJsonPath);

                List<Engine> element = JsonSerializer.Deserialize<List<Engine>>(textJson)!;
                return element;
            }
            catch (FileNotFoundException)
            {
                throw new Exception("Не найден файл");
            }
            catch (JsonException)
            {
                throw new Exception("Ошибка в файле");
            }
            catch
            {
                throw new Exception("Ошибка");
            }
        }
        
        
        public List<List<DependTorqueOnSpeedCrankshaft>> GetDataExperimant()
        {
            try
            {
                string textJson = File.ReadAllText(LineDependJsonPath);

                List<List<DependTorqueOnSpeedCrankshaft>> element = JsonSerializer.Deserialize<List<List<DependTorqueOnSpeedCrankshaft>>>(textJson)!;
                return element;
            }
            catch (FileNotFoundException)
            {
                throw new Exception("Не найден файл");
            }
            catch (JsonException)
            {
                throw new Exception("Ошибка в файле");
            }
            catch
            {
                throw new Exception("Ошибка");
            }
        }
    }
}
