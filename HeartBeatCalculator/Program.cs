using Spectre.Console;
using System;

namespace HeartBeatCalculator
{
    class Program
    {
        [Obsolete]
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("****************************");
            Console.WriteLine("Welcome to Cardiac Analyzer!");
            Console.WriteLine("****************************");

            Console.WriteLine("Choose an option to get started:");
            Console.WriteLine("--------------------------------");

            string userSelection;

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1. Import ECG Data");
            Console.WriteLine("2. Calculate heart rate");
            Console.WriteLine("3. Graph ECG");
            Console.WriteLine("4. Create new Patient");

            userSelection = Console.ReadLine();

            switch (userSelection)
            {
                case "1":
                    Console.WriteLine("Reading ECG data...");
                    break;//Load ECG data from a csv file
                case "2":
                    Console.WriteLine("Calculating heart rate...");
                    break; //determine the heart rate by detecting the number of peaks over time and display a diagnosis
                case "3":
                    Console.WriteLine("Graphing ECG data...");
                    EKGStudy.PlotECG();
                    break; //graphically display the data
                case "4":
                    Console.WriteLine("Enter First Name:");
                    break;

            }

        }
    }
}
