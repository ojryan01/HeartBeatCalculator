using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeartBeatCalculator
{
    public class EKGStudyRepository : IDisposable
    {

        public void Dispose() { }

        private List<EKGStudy> EKGStudies = new List<EKGStudy>();

        //Add an EKGStudy to the study repository list
        public void AddEKG(EKGStudy study)
        {
            EKGStudies.Add(study);

            study.StudyID = EKGStudies.IndexOf(study);

            Console.WriteLine($"Data saved to memory:");

            Console.WriteLine($"     Study ID: {study.StudyID}");

            Console.WriteLine($"     Patient Name: {study.Name}");

            Console.WriteLine("************************************************");

            Console.WriteLine($"There are {EKGStudies.Count} studies in memory."); //State the number of studies currently on the list

            //Write data summary to file

            string[] title = { "Summary of Data in Memory", "_________________________________" };

            // Set a variable to the Documents path.
            string docPath =
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Write the title to a new file named "DataSummary.txt". The using statements indicates Disposable
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "DataSummary.txt")))
            {
                foreach (string line in title)
                    outputFile.WriteLine(line);
            }

            //append the ID of each dataset stored to the DataSummaryFile
            foreach (var EKGStudy in EKGStudies)
            {
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "DataSummary.txt"), true))
                {
                    // Create a string array with the lines of text

                    string[] datasummary = { $"Study ID: {EKGStudy.StudyID}", $"Patient Name: {EKGStudy.Name}", "*************" };

                    foreach (string line in datasummary)
                    {
                        outputFile.WriteLine(line);
                    }
                }
            }
        }

        //a method to import data into list from CSV:

        public EKGStudy ReadEKG()
        {
            //instantiate a new instance of EKGStudy and collect some data for the properties
            var study = new EKGStudy();

            Console.WriteLine("Enter the patient name");

            study.Name = Console.ReadLine();

            //Console.WriteLine("Enter the patient age"); We can use this lated to get more granular with diagnosis

            //study.Age = 30; //int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the sample frequency in hertz:");

            string frequencyString = Console.ReadLine();

            //validate the frequency input

            study.Frequency = EKGStudy.Validate(frequencyString);

            //user enters file path

            Console.WriteLine("Enter the file path:");

            string path = Console.ReadLine();

            //read the csv into a list of strings

            using (var reader = new StreamReader(File.OpenRead(path)))  //read the file. The using statment indicates disposable object declaration
            {
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

                study.StudyData = studyDataString.Select(x => float.Parse(x)).ToList(); // Convert list of strings to list of floats

                return study;
            }
        }
       
        //a method to view the name and study ID of each study in the List EKG Studies

        public void ViewStudies()
        {
            foreach (var EKGStudy in EKGStudies)
            {
                Console.WriteLine("*****************");
                Console.WriteLine($"Name: {EKGStudy.Name}");
                Console.WriteLine($"Study ID: {EKGStudies.IndexOf(EKGStudy)}");
                Console.WriteLine("*****************");
            }
        }
        
        //Access a specific study by entering the study ID 
        public void ViewStudyDetailsByID()
        {
            Console.WriteLine("Enter the study ID");
            var studyID = int.Parse(Console.ReadLine());

            var studyDetails = from stud in EKGStudies
                                       where stud.StudyID == studyID
                                       select stud;


            foreach (var detail in studyDetails)
            {
                Console.WriteLine("*******************************************");
                Console.WriteLine($"Displaying data for Study: {detail.StudyID}");
                Console.WriteLine($"Patient Name: {detail.Name}");
                detail.StudyData = ReadEKG().StudyData;
                double heartRate = EKGStudy.CalculateHeartRate(detail.StudyData, detail.Frequency);
                //string diagnosis = EKGStudy.Diagnose(heartRate); Under construction
                Console.WriteLine("*******************************************");
            }

        }

        
    }
}
