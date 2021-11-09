using Spectre.Console;
using System;
using System.Collections.Generic;

namespace HeartBeatCalculator
{
    //This class is currently unused. May use it later when we want to track patients separately from studies
    
    public class Patient //classes are private by default so we need to make them publically accessible
    {

        //a constructor is a special kind of method, named with the class's name, executed each time an instance of the class is executed (i.e Patient patient  = new Patient). A default ctor is used when instantiating if you don't do this.
        //use ctor tab tab

        public Patient()
        {

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

        public string FullName
        {
            get
            {
                return LastName + ' ' + FirstName;
            }
        }

        public List<EKGStudy> Studies;

        //DateType DateOfBirth { get; set; }

        [Obsolete]
       

        // Render the canvas

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

        //Method to add a patient
        
        public static void AddPatient()
        {
            var patient = new Patient();
            Console.WriteLine("Enter the first name:");
            patient.FirstName = Console.ReadLine();
            Console.WriteLine("Enter the last name:");
            patient.LastName = Console.ReadLine();
            Patients.Add(patient); //Adds this new patient to the list. need to get rest of patient info and also automatically assign a patient ID
            patient.PatientID = Patients.IndexOf(patient); //assigns the patient id to the current index in the list
        }

        public static void ViewPatients()
        {
            foreach (var Patient in Patients)
                {
                Console.WriteLine("*****************");
                Console.WriteLine($"Name: {Patient.FullName}");
                Console.WriteLine($"Patient ID: {Patient.PatientID}");
                Console.WriteLine($"Number of studies: 0"); //Want to access the number of studies associated with that patient
                Console.WriteLine($"Studies:"); //access the list of study IDs
                Console.WriteLine("*****************");
            }
        }
    }
}