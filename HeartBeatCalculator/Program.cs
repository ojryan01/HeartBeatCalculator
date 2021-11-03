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
                Console.WriteLine("1. Import data");
                Console.WriteLine("2. View stored data");
                Console.WriteLine("3. Retrieve stored data by Study ID");
                Console.WriteLine("4. Graph ECG");
                Console.WriteLine("5. Help");
                Console.WriteLine("6. Quit");

                userSelection = Console.ReadLine();
                
                switch (userSelection)
                {
                    case "1":
                        EKGStudyRepository.AnalyzeEKG(); //Load, analyze and store ECG data from a csv file
                        Console.WriteLine("Press enter to return to main menu");
                        Console.ReadLine();
                        break;
                    case "2":
                        EKGStudyRepository.ViewStudies();
                        Console.WriteLine("Press enter to return to main menu");
                        Console.ReadLine();
                        break;
                    case "3":
                        EKGStudyRepository.ViewStudyDetailsByID();
                        Console.WriteLine("Press enter to return to main menu");
                        Console.ReadLine();
                        break;
                    case "4":
                        Console.WriteLine("Graphing ECG data...");
                        EKGStudy.PlotECG();
                        Console.WriteLine("Press enter to return to main menu");
                        Console.ReadLine();    
                        break; //graphically display the data
                    case "5":
                        Console.WriteLine("Commands:");
                        Console.WriteLine("1. Import data: Enter patient details and provide a local file path to the data set. File format should be " +
                            "in CSV format. Only Y values should be provided (i.e EKG data in milivolts). Time data is interpolated from the user provided study frequency");
                        Console.WriteLine("2. View stored data: This option displays the top level information for each dataset stored in memory (Patient name and study ID). To see the full data for a given data set, use Option 3. ");
                        Console.WriteLine("3. Retrieve stored data by Study ID: View full details for a stored datasets by entering the study ID. Use Option 2 to view the stored datasets or Option 1 to import a new dataset");
                        Console.ReadLine();
                        break; //graphically display the data
                    case "6":
                        repeat = false;
                        break;
                }
            }

        }
    }
}
