using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeartBeatCalculator
{
    public class EKGStudyRepository
    {

        public static List<EKGStudy> EKGStudies = new List<EKGStudy>();

        public static double AnalyzeEKG()
        {
            
            //instantiate a new instance of EKGStudy and collect some data for the properties
            var study = new EKGStudy();

            //Console.WriteLine("Enter the patient name");

            study.Name = "olivia";//Console.ReadLine();

            //Console.WriteLine("Enter the patient age");

            study.Age = 30; //int.Parse(Console.ReadLine());

            //Console.WriteLine("Enter the sample frequency in hertz:");

            string frequencyString = "500"; //Console.ReadLine();

            //some validation of user input (later we can make this it's own method or class)

            if (string.IsNullOrWhiteSpace(frequencyString))
                throw new ArgumentException("Enter the sample frequency in hertz");

            var success = int.TryParse(frequencyString, out int frequency);

            if (!success || frequency < 0)
                throw new ArgumentException("Frequency must be > 0");

            study.Frequency = frequency;

            // use the ReadEKG method to let the user enter the study data and assign it to the StudyData property

            study.StudyData = ReadEKG();

            double heartRate = EKGStudy.CalculateHeartRate(study.StudyData, frequency);

            string diagnosis = EKGStudy.Diagnose(heartRate);

            //Add the new instance of EKGStudy to the list EKGStudies

            EKGStudies.Add(study);

            Console.WriteLine($"There are {EKGStudies.Count} studies in memory"); //State the number of studies currently on the list

            return heartRate;
          
        }

        //a method to import data into list from CSV

        public static List<float> ReadEKG()
        {
            //user enters file path

            //Console.WriteLine("Enter the file path:");

            string path = "C:\\Users\\olivi\\source\\repos\\HeartBeatCalculator\\EKG10seconds500hz.csv"; //Console.ReadLine();

            //logic to read the csv into a list of strings

            var reader = new StreamReader(File.OpenRead(path)); //read the file

            List<string> studyDataString = new List<string>();

            while (!reader.EndOfStream) //until we get to end of file
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                foreach (var item in values)
                {
                    studyDataString.Add(item);
                }
            }

            List<float> studyData = studyDataString.Select(x => float.Parse(x)).ToList(); // Convert list of strings to list of floats

            return studyData;
        }
    }
}
