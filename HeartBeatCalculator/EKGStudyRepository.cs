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

        public static void AddStudy()
        {
            
            //instantiate a new instance of EKGStudy
            var study = new EKGStudy();

            Console.WriteLine("Enter the patient ID");

            study.PatientID = Console.ReadLine(); // now, how to assign this to a specific patient and their list of studies 

            study.StudyID = EKGStudies.IndexOf(study); //assigns the study id to the current index in the list

            study.StudyData = ReadEKG(); // use the method to let the user enter the study data TODO: This isn't on the main menu yet! Also how do we tie this to a specific patient? Inheritence?

            EKGStudies.Add(study); //Adds the new study to the list.

            Console.WriteLine($"There are {EKGStudies.Count} studies in memory"); //State the number of studies currently on the list
        }


        //a method to import data into list from CSV

        public static List<float> ReadEKG()
        {
            //user enters file path

            Console.WriteLine("Enter the file path:");

            string path = Console.ReadLine();

            //user enters the sampling frequency in hertz

            Console.WriteLine("Enter the sample frequency in hertz:");

            string frequencyString = Console.ReadLine();

            //some validation of user input (later we can make this it's own method or class)

            if (string.IsNullOrWhiteSpace(frequencyString))
                throw new ArgumentException("Enter the sample frequency in hertz");

            var success = int.TryParse(frequencyString, out int frequency);

            if (!success || frequency < 0)
                throw new ArgumentException("Frequency must be > 0");

            Console.WriteLine("Reading ECG data...");

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
