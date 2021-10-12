using Spectre.Console;
using System;

namespace HeartBeatCalculator
{
    class Program
    {
        [Obsolete]
        static void Main(string[] args)
        {        
            var repeat = true;

            while (repeat)

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
                Console.WriteLine("5. Quit");

                userSelection = Console.ReadLine();
                
                switch (userSelection)
                {
                    case "1":
                        EKGStudy.ReadEKG();
                        Console.WriteLine("Press enter to return to main menu");
                        break;//Load ECG data from a csv file
                    case "2":
                        Console.WriteLine("Calculating heart rate...");
                        Console.WriteLine("Press enter to return to main menu");
                        break; //determine the heart rate by detecting the number of peaks over time and display a diagnosis
                    case "3":
                        Console.WriteLine("Graphing ECG data...");
                        EKGStudy.PlotECG();
                        Console.WriteLine("Press enter to return to main menu");
                        break; //graphically display the data
                    case "4":
                        Patient.AddPatient();
                        Console.WriteLine("Press enter to return to main menu");
                        break;
                    case "5":
                        repeat = false;
                        break;
                }
            }

        }
    }
}
