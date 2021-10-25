using log4net;
using log4net.Config;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Assignment1
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public static void Main(string[] args)
        {

            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

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

                   //Console.WriteLine("File:" + filepath);
                    skippedRecord=csvFile.parse(filepath);
                    //Console.WriteLine(skippedRecord);
                   TotalRecords = TotalRecords + skippedRecord;
               }
           }
            log.Info("Hello logging world!");
            log.Error("Error!");
            log.Warn("Warn!");


            Console.WriteLine(TotalRecords);
        }



      
    }
}
