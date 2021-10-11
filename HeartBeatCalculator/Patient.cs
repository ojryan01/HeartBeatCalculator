using Spectre.Console;
using System;

namespace HeartBeatCalculator
{
    public class patient //classes are private by default so we need to make them publically accessible
    {

        //a constructor is a special kind of method, named with the class's name, executed each time an instance of the class is execute.
        //use ctor tab tab

        public patient()
        {

        }

        public patient(int PatientId)
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

        //importECG(); //import a data set for the selected patient?

        // we want to initialize an empty array that will populate with the ECG data which can then be analyzed for that patient double ecgData[] {get; set; } 

    }
}