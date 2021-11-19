HEARTBEAT CALCULATOR
===============================


CONTENTS OF THIS FILE
---------------------
1. PROJECT DESCRIPTION
2. FULFILLMENT OF REQUIREMENTS  
3. SPECIAL INSTRUCTIONS
4. FUTURE DEVELOPMENT
#


PROJECT DESCRIPTION
-------------------

This goal of this project is to fulfill the requirements for Code Louisville's C#/.NET programming course. This is my first attempt at using this language to create a functional console application.

I wanted to draw on my background in biomedical engineering for this project. EKG or Electrocardiogram is a well known diagnostic tool for measuring and diagnosing cardiac function. The intended use of the 

application is to read, store and analyze ECG data to provide key statistics and diagnoses to the user. 

I'm tracking my project backlog using Trello. Progress on the project can be viewed here: https://trello.com/b/Natw2Dcq/code-louisville-project-c

---------------------------------------------------------------

FULFILLMENT OF REQUIREMENTS
---------------------------

__COMMITS__

Requirement Text: _"Project is uploaded to your GitHub repository and shows at minimum 5 separate commits."_

The GitHub repository URL is https://github.com/ojryan01/HeartBeatCalculator.

As of 12 November 2021, 21 separate commits have been made.

__README__

Requirement Text: _"Project includes a README file that explains the following: A one paragraph or longer description of what your project is about, Which 3+ features you have included from the below list to meet the requirementsm, Any special instructions required for the reviewer to run your project."_

__CLASSES AND OBJECTS__

Requirement Text:_"You must create at least one class, then create at least one object of that class and populate it with data. You must use or display the data in your application."_

* _EKGStudyRepository_ Class - The object is instantiated on starting the program and is used to store a list of EKGStudies.

* _EKGStudy_ Class - The object is instantiated when the user selects "Option 1: Import data" from the main menu. The properties include identifying information about the "patient" as well as a List of data points representing collected EKG data samples.
  

__FUNCTIONS AND/OR METHODS__ 

Requirement Text: _"Create and call at least 3 functions or methods, at least one of which must return a value that is used in your application."_

_EKGStudy_ Methods

* EKGStudy() - Constructor method to instantiate the EKGStudy object, collect some data for the properties and enter the file path for the data set.
* Validate() -  Ensures that the user-input frequency is a valid integer greater than zero.
* CalculateHeartRate() - Calculates a moving average and compares the current value to a set threshold value above the average. If the current data point is greater than the thresh-hold value, a Pulse Counter is incremented to store the number of heartbeats. The number of pulses are extrapolated into an average heart rate value in beats per minute (BPM).
* Diagnose() - Currently commented out, compares the calculated average heartrate against values to determine if the heartrate is in a healthy or pathologic state.

_EKGStudyRepository_ Methods
* AddEKG() - Adds an object of EKGStudy to the EKGStudyRepository list, assigns a unique ID to the data set and prints a summary of the stored data to a locally saved text file.
* ViewStudies() - View a summary of all the data imported during the session. 
* ViewStudyDetailsByID() - Prompts the user to enter a study ID and looks up the data in the EKGStudyRepository.

__IMPLEMENT 3 FEATURES FROM A GIVEN LIST__
Requirement Text: _"Choose at least 3 items on the Features List below and implement them in your project"_

__Feature 1:__ _"Implement a “master loop” console application where the user can repeatedly enter commands/perform actions, including choosing to exit the program"_

In Program.cs, the user is able to chose from 3 options which call one of the methods described above. There is also a "Help" option which describes the usage of each option and an "Exit" option to break from the master loop and close the program.

__Feature 2:__ _"Create a dictionary or list, populate it with several values, retrieve at least one value, and use it in your program""

In Program.CS, a list of EKGStudy is created by calling the EKGStudyRepository() constructor method. When AddEKG() is called, a new data set with patient info is added to the list. Data is retrieved by calling the ViewStudyDetailsbyID() method.

The individual EKG data points are also stored as a list of type float and data is retrieved for the peak detection algorithm.

__Feature 3:__ _"Implement a log that records errors, invalid inputs, or other important events and writes them to a text file"_

In the AddEKG() method, after the data is added to the EKGStudyRepositoryList, a summary of the list is printed to a text file DataSummary saved in the local Documents folder.


__ADDITIONAL FEATURES__

__Feature 4:__ _"Read data from an external file, such as text, JSON, CSV, etc and use that data in your application"_

EKG data is read from CSV format in the EKGStudy() constructor method. The data must be in a single column with no headers. 

__Feature 5:__ _"Use a LINQ query to retrieve information from a data structure (such as a list or array) or file"_

LINQ is used both to access intervals for the moving average heart rate calculation in CalculateHeartRate() and to access studies from the EKGStudyRepository list in ViewStudyDetailsByID().

---------------------------------------------------------------
SPECIAL INSTRUCTIONS
--------------------
There is a folder of test CSV data sets in the repo that you can import. You can save the CSV anywhere locally and the program will prompt you for the file path. 

For now, you can plot the data sets in excel to verify it caught the correct number of heartbeats.

The program currently only works with the sample file "_EKG Sample Data - Healthy 360 HZ.csv"_. 

---------------------------------------------------------------
FUTURE DEVELOPMENT AND LIMITATIONS
----------------------------------

1. One of the biggest challenges for this project was finding clean sample data to analyze in CSV format. A large bank of data exists at https://archive.physionet.org/cgi-bin/atm/ATM but without filtering the signals contain artifacts such as noise, baseline drift, etc. This makes threshold based peak detection difficult and essentially requires a different threshold value to be set using trial and error for each data set. In the future, I'd like to further refine the peak detection by filtering/smoothing the datasets so that the peak detection works for any EKG dataset.

2. Further input validation and error logging - Currently the only validated input is the Frequency value. Further validation could be implemented on the file path input as well as format of the CSV. The specific validation messages should be exported to a log file. 

3. Unit testing - Unit testing was covered as part of this course but due to time limitations I wasn't able to implement them as part of the MVP. In future projects I'd also like to practice test-driven development by fully writing out the tests and acceptance criteria before starting development.

4. Graphical display of data - I initially began using Winforms to plot the EKG data but a mentor recommended I try a Razor page app as a front end for the application. 

----------------------------------------------------------------
