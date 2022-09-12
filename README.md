# Employee Data Parser and Data Service API

## Project 1: Employee Data Parser

- This is a .NET Console App that can parser input files into a list of Employees. The input file must be in one of the following three formats. Each line is a list of last name, first name, email, favorite color and date of birth.
  
   >  Lastname | Fname | man@gmail.com | Pink | 2000-02-02T00:00:00

   >  Fox, Smart, fox@outlook.com, Green, 2001-11-11T00:00:00

   >  White   Snow   snow@yahoo.com   Blue   2009-08-08T00:00:00

- When running the console app with input files, all pasered records will be printed to the console three times each with a different ordering method.
  - Order by favorite color and then by last name.
  - Order by date of birth.
  - Order by last name descending.


## Project 2: Employee Data Service API
- .NET web API with four endpoints:
  - [POST] /records: Accept a string in body to post a employee record. The string must be in one of the above listed format for employee data. The response contains the newly posted employee object.
  - [GET] /records/color: Returns all employees sorted by their favorite color in Json format.
  - [GET] /records/birthdate: Retures all employees sorted by their date of birth in Json format.
  - [GET] /records/name: Returns all employees sorted by their last name in Json format.

## Two test projects written with XUnit are included. 
