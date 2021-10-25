This Assigment allows a user to count invalid and valid records.I have added a Exception file where all the exceptions are handled. Then all the files are passed in a method of ParseCsvFile to check whether the FirstName,LastName,Email,Country,Postal Code are null or not. Additionaly, Email Validation and name validation are also added in this file.A method of a class WriteResults is called in this file to store all the entries in a csv file Output ( Additional Date column is added in this file ).Log file is also created to store all the log errors.
</br>
<br/>
Files :- </br>

WriteResults.cs = Writes Valid records in a file Output.txt.</br>
ParseCsvFile.cs = Parse the csv file and validate the data and store the number of valid and invalid records.</br>
DirectoryTraverse.cs = Traverse the SampleData Directory.
