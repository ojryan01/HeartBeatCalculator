using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace HeartBeatCalculator
{
    public class EKGStudy

    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Sex { get; set; }

        public List<float> StudyData { get; set; }

        public int Frequency { get; set; }

        public int StudyID { get; set; }

        public double Duration { get; set; }

        public EKGStudy()

        {
            //instantiate a new instance of EKGStudy and collect some data for the properties

            Console.WriteLine("Enter the patient name");

            Name = Console.ReadLine();

            //Console.WriteLine("Enter the patient age"); We can use this later to get more granular with diagnosis

            //study.Age = 30; //int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the sample frequency in hertz:");

            string frequencyString = Console.ReadLine();

            //validate the frequency input

            Frequency = Validate(frequencyString);

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

                StudyData = studyDataString.Select(x => float.Parse(x)).ToList(); // Convert list of strings to list of floats

                AnalyzeEKG();
            }
        }

            //a combined method that calls functions to:
            //ReadEKG, AddEKG to repository, CalculateHeartRate, and Diagnose the patient 
            public double AnalyzeEKG()
            {
             
                double heartRate = CalculateHeartRate();

                // string diagnosis = EKGStudy.Diagnose(heartRate); this isn't quite working yet for all datasets

                return heartRate;
            }

            //A method to calculate the heart rate for a given reading

            public double CalculateHeartRate()
            {
                int pulseCounter = 0;

                double duration = StudyData.Count / Frequency; // duration in seconds

                //Moving average calculation //ready to run and TEST

                for (int i = 0; i < StudyData.Count; i++)

                { if (i < (Frequency / 2))

                    {
                        float intsum = StudyData.Take(i + 1).Sum(); // sum of first i members of study data list

                        float intavg = intsum / (i + 1); // sum above divided by the number of samples so far

                        var currentvalue = StudyData[i];

                        double threshholdmodifier = 1.3635;

                        var comparevalue = intavg + threshholdmodifier;

                        if (currentvalue > comparevalue) //certain threshhold above the average is a peak 
                        {
                            pulseCounter += 1;
                        }
                    }
                    else
                    {
                        float intsum = StudyData.Skip(i - (Frequency / 4)).Take(Frequency / 2).Sum();     //here we need to say, if i is greater than the samples in one second, take the sum of the surrounding one second (i - frequency/2)
                        float intavg = intsum / (Frequency); // sum above divided by the number of samples in the interval

                        var currentvalue = StudyData[i];

                        double threshholdmodifier = 1.96;

                        var comparevalue = intavg + threshholdmodifier;

                        if (currentvalue > comparevalue) //certain threshhold above the average is a peak 
                        {
                            pulseCounter += 1;
                        }
                    }
                }

                var heartRate = 60 * pulseCounter / duration; //heartrate in beats per min

                Console.WriteLine("Reading ECG data...");
                Console.WriteLine("************************************************");

                Console.WriteLine($"The study contains {StudyData.Count} data points"); //verifying that all the data points got read into list

                Console.WriteLine($"The study duration is { duration } seconds"); //verifying that all the data points got read into list

                Console.WriteLine($"{ pulseCounter } beats detected");

                Console.WriteLine($"The average heart rate is { heartRate } beats per minute");

                Console.WriteLine("************************************************");

                return heartRate;
            }

            //A method to diagnose someone's heart rate based on sex, gender, age and the calculated heartrate

            public string Diagnose()
            {
                string diagnosis = "";
                double heartrate = CalculateHeartRate();

                if (heartrate <= 60)
                {
                    diagnosis = "Bradycardia (slow heart rate)";
                }

                else if (heartrate > 60 && heartrate < 100)
                {
                    diagnosis = "Healthy";
                }
                else
                {
                    diagnosis = "Tachycardia (Elevated heart rate)";
                }

                Console.WriteLine($"Your diagnosis is: {diagnosis}");
                return diagnosis;
            }

            //a method to validate that a positive integer value is provided for the sample frequency
            public int Validate(string frequencyString)
            {

                if (string.IsNullOrWhiteSpace(frequencyString))
                    throw new ArgumentException("Enter the sample frequency in hertz");

                var success = int.TryParse(frequencyString, out int frequency);

                if (!success)
                    throw new ArgumentException("Frequency must be an integer value");

                else if (frequency < 0)
                    throw new ArgumentException("Frequency must be > 0");

                return frequency;
            }

        }
    }



