# Employee Data Parser and Data Service API

## Project 1: EmployeeDataParser

- This is a .NET Console App that can parser input files in the following three formats into a list of Employee objects.
   
   Each line is a list of last name, first name, email, favorite color and data of birth.
   >  Lastname | Fname | man@outlook.com | Pink | 2000-02-02T00:00:00

   >  Fox, Smart, fox@outlook.com, Green, 2001-11-11T00:00:00

   >  White   Snow   snow@yahoo.com   Blue   2009-08-08T00:00:00

- When running the console app with input files, the pasered records will be print to console three times using different properties for ordering.
  - Order by favorite color and then by last name.
  - Order by date of birth.
  - Order by last name descending.


## Project 2: Employee data service web API
- .NET web API with four endpoints:
  - [POST] /records Accept a string to post a employee record. The string must be in one of the above listed format for employee data.
  - [GET] /records/color Returns all employees sorted by them favorite color.
  - [GET] /records/birthdate Retures all employees sorted by their date of birth.
  - [GET] /records/name Returns all employees sorted by their last name.