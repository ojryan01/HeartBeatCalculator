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
    public class EKGStudy

    {
        public string Name { get; set;  }

        public int Age { get; set; }

        public string Sex { get; set; }

        public List<float> StudyData { get; set; }

        public int Frequency { get; set; }

        public int StudyID { get; set; }

        public double Duration { get; set; }

        public EKGStudy()

        {

        }

        //A method to calculate the heart rate for a given reading

        public static double CalculateHeartRate( List<float> studydata, int frequency )
        {
            int pulseCounter = 0;

            double duration = studydata.Count / frequency; // duration in seconds

            //Moving average calculation //ready to run and TEST

            for (int i = 0; i < studydata.Count; i++)

            { if (i < (frequency / 2) )

                {
                    float intsum = studydata.Take(i+1).Sum(); // sum of first i members of study data list

                    float intavg = intsum / (i+1); // sum above divided by the number of samples so far

                    var currentvalue = studydata[i];

                    double threshholdmodifier = 1.3635;

                    var comparevalue = intavg + threshholdmodifier;

                    if (currentvalue > comparevalue ) //certain threshhold above the average is a peak 
                    {
                        pulseCounter += 1;
                    }
                }
                else
                {
                    float intsum = studydata.Skip(i - (frequency / 4)).Take(frequency / 2).Sum();     //here we need to say, if i is greater than the samples in one second, take the sum of the surrounding one second (i - frequency/2)
                    float intavg = intsum / (frequency); // sum above divided by the number of samples in the interval

                    var currentvalue = studydata[i];

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

            Console.WriteLine($"The study contains {studydata.Count} data points"); //verifying that all the data points got read into list

            Console.WriteLine($"The study duration is { duration } seconds"); //verifying that all the data points got read into list

            Console.WriteLine($"{ pulseCounter } beats detected");

            Console.WriteLine($"The average heart rate is { heartRate } beats per minute");

            Console.WriteLine("************************************************");

            return heartRate;
        }

        //A method to diagnose someone's heart rate based on sex, gender, age and the calculated heartrate

        public static string Diagnose(double heartrate)
        {
            string diagnosis = "";

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

        }
    }


