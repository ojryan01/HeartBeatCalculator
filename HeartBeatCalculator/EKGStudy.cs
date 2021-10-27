﻿using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HeartBeatCalculator
{
    public class EKGStudy //this class should inherit info from patient.

    {
        public int StudyID { get; set;  }

        public string PatientID { get; set; }

        public int Duration { get; set; }

        public List<float> StudyData { get; set; }

        
        public EKGStudy()

        {

        }

        //A method to calculate the heart rate for a given reading

        public static double CalculateHeartRate( string studyId, List<float> studydata, int frequency )
        {

            Console.WriteLine("Enter the study ID");

            studyId = Console.ReadLine();
            
            int pulseCounter = 0;

       

            double duration = studydata.Count / frequency; // duration in seconds

            //Moving average calculation //ready to run and TEST

            for (int i = 0; i < studydata.Count; i++)

            { if (i < frequency)

                {
                    float intsum = studydata.Take(i).Sum(); // sum of first i members of study data list

                    float intavg = intsum / (i + 1); // sum above divided by the number of samples so far

                    if (studydata[i] > intavg + .25) //certain threshhold above the average is a peak TODO change study data list to two dimensional
                    {
                        pulseCounter += 1;
                    }
                }
                else
                {
                    float intsum = studydata.Skip(i - (frequency / 2)).Take(frequency).Sum();     //here we need to say, if i is greater than the samples in one second, take the sum of the surrounding one second (i - frequency/2)
                    float intavg = intsum / (i + 1); // sum above divided by the number of samples so far
                    if (studydata[i] > intavg + .25) //certain threshhold above the average is a peak TODO change study data list to two dimensional
                    {
                        pulseCounter += 1;
                    }

                }
            }

            

            

            foreach (float i in studydata)
            {

                if (i == 0) //simple zero crossing detection for a pure sine wave (going to need different algo for EKG
                {
                    pulseCounter += 1;
                }

                Console.WriteLine(i);

            }

            var heartRate = 60 * pulseCounter / duration; //heartrate in beats per min

            Console.WriteLine($"The study contains {studydata.Count} data points"); //verifying that all the data points got read into list

            Console.WriteLine($"The study duration is { duration } seconds"); //verifying that all the data points got read into list

            Console.WriteLine($"The average heart rate is { heartRate } beats per minute");

            return heartRate;

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


