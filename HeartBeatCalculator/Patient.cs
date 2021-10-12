using Spectre.Console;
using System;
using System.Collections.Generic;

namespace HeartBeatCalculator
{
    public class Patient //classes are private by default so we need to make them publically accessible
    {

        //a constructor is a special kind of method, named with the class's name, executed each time an instance of the class is execute.
        //use ctor tab tab

        public Patient()
        {

        }

        public Patient(int PatientId)
        {
            PatientId = patientId;
        }

        //long hand example of encapsulation shown below:

        private string firstName; //data is encapsulated or hidden within the classes using a private backing field

        public string FirstName //the getter (gets property value) / setter (assigns value to backing field) makes the backing field accessible through the property
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }

        }

        //for the rest of the properties, we will use short hand encapsulation, where the backing field is set up autom-implemented behind the scenes 


        public string LastName { get; set; }
        public object PatientID { get; private set; }

        private int patientId;
        public int PatientId { get; private set; }

        public string FullName
        {
            get
            {
                return LastName + ' ' + FirstName;
            }
        }

        //DateType DateOfBirth { get; set; }

        //string AnalyzeECG() { get; set; } //calculate heart rate and return if the patient is healthy, has bradycardia or tachycardia

        [Obsolete]
       

        // Render the canvas

        //int calculateHeartRate() { get; set; }

        //Display patient data by id

        //public Patient Retrieve(int PatientId)
        //{
        //    //code that retrieves
        //    return new Patient();
        //}

        ////Display all patients

        //public List<Patient> Retrieve()
        //{
        //    //code that retrieves all customers
        //    return new List<Patient>();
        //}


        //Validates patient data
        public bool Validate()
        {
            var isValid = true;
            if (string.IsNullOrWhiteSpace(LastName)) isValid = false;
            if (string.IsNullOrWhiteSpace(FirstName)) isValid = false;
            return isValid;

        }

        public static List<Patient> Patients = new List<Patient>();

        public static void AddPatient()
        {
            var patient = new Patient();
            Console.WriteLine("Enter the first name:");
            patient.FirstName = Console.ReadLine();
            Console.WriteLine("Enter the last name:");
            patient.LastName = Console.ReadLine();
            patient.PatientID = Patients.IndexOf(patient); //assigns the patient id to the index in 
            Patients.Add(patient); //Adds this new patient to the list. need to get rest of patient info and also automatically assign a patient ID

            foreach (var Patient in Patients) //tryimg to print each patient info in the list
                { Console.WriteLine(patient.FullName);
                }
        }

        //importECG(); //import a data set for the selected patient?

        // we want to initialize an empty array that will populate with the ECG data which can then be analyzed for that patient double ecgData[] {get; set; } 

    }
}