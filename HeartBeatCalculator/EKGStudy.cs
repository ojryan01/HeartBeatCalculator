﻿using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HeartBeatCalculator
{
    public class EKGStudy

    {
        public int StudyID { get; }

        public string PatientName { get;  }

        public int Duration { get;  }

        public int[] StudyData { get;  }

        public EKGStudy(int studyID, string patientName, int duration, int[] studyData)

        {
            this.StudyID = studyID;
            this.PatientName = patientName;
            this.Duration = duration;
            this.StudyData = studyData;
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
