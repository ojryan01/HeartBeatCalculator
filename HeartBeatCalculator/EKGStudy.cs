using Spectre.Console;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HeartBeatCalculator
{
    public class EKGStudy //this class should inherit info from patient.

    {
        public int StudyID { get; }

        public string PatientName { get; }

        public int Duration { get; }

        public List<float> StudyData { get; }

        public EKGStudy(int studyID, string patientName, int duration, List<float> studyData)

        {
            this.StudyID = studyID;
            this.PatientName = patientName;
            this.Duration = duration;
        }


        //import data into list from CSV
        public static List<float> ReadEKG()
        {

            //user enters file path
            
            Console.WriteLine("Enter the file path:");

            string path = Console.ReadLine();

            //user enters the sampling frequency in hertz
            
            Console.WriteLine("Enter the sample frequency in hertz:");
          
            string frequencyString = Console.ReadLine();

            int frequency = Int32.Parse(frequencyString);

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

            List<float> studyData = studyDataString.Select( x => float.Parse(x)).ToList(); // Convert list of strings to list of floats

            double duration = studyDataString.Count / frequency; // duration in seconds

            int pulseCounter = 0;

            foreach (float i in studyData)
             {

                if (i == 0) //simple zero crossing detection for a pur sine wave (going to need different algo for EKG
                    {
                    pulseCounter += 1;   
                    } 

                Console.WriteLine(i);
                
             }

            var heartRate = 60 * pulseCounter / duration; //heartrate in beats per min

            Console.WriteLine($"The study contains {studyDataString.Count} data points"); //verifying that all the data points got read into list

            Console.WriteLine($"The study duration is { duration } seconds"); //verifying that all the data points got read into list

            Console.WriteLine($"The average heart rate is { heartRate } beats per minute");

            return studyData;
        }
        


            [Obsolete]

            public static void PlotECG() //when we create an object instance then it doesn't need to be static anymore?

            {
                var canvas = new Canvas(300, 300);

                // Draw some shapes
                for (var i = 0; i < canvas.Width; i++)
                {


                    var plotx = i;
                    var ploty = Math.Ceiling(50 + 50 * Math.Sin(i * (Math.PI / 180)));
                    Console.WriteLine($"{plotx}, {ploty}");

                    //straight line
                    canvas.SetPixel(plotx, (int)ploty, Color.Blue);

                    // Cross
                    //canvas.SetPixel(i, i, Color.White);
                    //canvas.SetPixel(canvas.Width - i - 1, i, Color.White);

                    // Border
                    canvas.SetPixel(i, 0, Color.Red);
                    canvas.SetPixel(0, i, Color.Green);
                    canvas.SetPixel(i, canvas.Height - 1, Color.Blue);
                    canvas.SetPixel(canvas.Width - 1, i, Color.Yellow);
                }

                AnsiConsole.Render(canvas);
                Console.ReadLine();

            }

        }
    }


