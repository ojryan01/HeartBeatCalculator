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

* COMMITS

Requirement Text: _"Project is uploaded to your GitHub repository and shows at minimum 5 separate commits."_

The GitHub repository URL is https://github.com/ojryan01/HeartBeatCalculator.

As of 12 November 2021 21 separate commits have been made.

* README

Requirement Text: _"Project includes a README file that explains the following: A one paragraph or longer description of what your project is about, Which 3+ features you have included from the below list to meet the requirementsm, Any special instructions required for the reviewer to run your project."_


* CLASSES AND OBJECTS

Requirement Text:_"You must create at least one class, then create at least one object of that class and populate it with data. You must use or display the data in your application."_

__EKGStudyRepository Class__ - The object is instantiated on starting the program and is used to store a list of EKGStudies.

__EKGStudy Class__ - The object is instantiated when the user selects "Option 1: Import data" from the main menu. The properties include identifying information about the "patient" as well as a List of data points representing collected EKG data samples.
  

* FUNCTIONS AND/OR METHODS 

Requirement Text: _"Create and call at least 3 functions or methods, at least one of which must return a value that is used in your application."_

__Methods of the EKGStudy Class__

* Validate() -  Ensures that the user-input frequency is a valid integer greater than zero.
* CalculateHeartRate() - Uses simple moving average formula to detect peaks or heartbeats in the dataset.

__Methods of the EKGStudy Class__
AddEKG()
ViewStudies()
ViewStudyDetailsByID()

* IMPLEMENT 3 FEATURES FROM THE GIVEN LIST
Requirement Text: _"Choose at least 3 items on the Features List below and implement them in your project"_

Feature 1: "Implement a “master loop” console application where the user can repeatedly enter commands/perform actions, including choosing to exit the program"

Feature 2: "Create a dictionary or list, populate it with several values, retrieve at least one value, and use it in your program"

Feature 3: "Implement a log that records errors, invalid inputs, or other important events and writes them to a text file"

* ADDITIONAL FEATURES

Feature 4: "Read data from an external file, such as text, JSON, CSV, etc and use that data in your application"

Feature 5: "Use a LINQ query to retrieve information from a data structure (such as a list or array) or file"

---------------------------------------------------------------
SPECIAL INSTRUCTIONS
--------------------
There is a folder of test CSV data sets in the repo that you can import. You can save the CSV anywhere locally and the program will prompt you for the file path. 

For now, you can plot the data sets in excel to verify it caught the correct number of heartbeats.


The program currently only works with the sample file "_EKG Sample Data - Healthy 360 HZ.csv"_. 

---------------------------------------------------------------
FUTURE DEVELOPMENT AND LIMITATIONS
----------------------------------

----------------------------------------------------------------
