using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;

namespace Assignment1
{
    class Program
    {
        public static void Main(string[] args)
        {
            DirectoryTraverse dt = new DirectoryTraverse();
            List<string> fileList = new List<string>();
            Double skippedRecord = 0;
            Double TotalRecords = 0;
            ParseCsvFile csvFile = new ParseCsvFile();
            Console.WriteLine("Hello World!");
            fileList = dt.Walk("D:\\MCDA5510_Assignments\\Sample Data\\Sample Data");
            foreach (string filepath in fileList)
           {
               if (filepath.EndsWith("csv"))
               {

                   Console.WriteLine("File:" + filepath);
                    skippedRecord=csvFile.parse(filepath);
                    Console.WriteLine(skippedRecord);
                   TotalRecords = TotalRecords + skippedRecord;

               }
           }

            Console.WriteLine(TotalRecords);
        }



      
    }
}
