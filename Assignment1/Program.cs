using log4net;
using log4net.Config;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Assignment1
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

            DirectoryTraverse dt = new DirectoryTraverse();
            List<string> fileList = new List<string>();
            Double[] Records = new double[2];
            Double TotalSkippedRecords = 0;
            Double TotalValidRecords = 0;
            ParseCsvFile csvFile = new ParseCsvFile();
            Console.WriteLine("Hello World!");
            fileList = dt.Walk("D:\\MCDA5510_Assignments\\Sample Data\\Sample Data");
            foreach (string filepath in fileList)
           {
                    Records = csvFile.parse(filepath);
                    TotalSkippedRecords = TotalSkippedRecords + Records[0];
                    TotalValidRecords = TotalValidRecords + Records[1];
           }
            stopwatch.Stop();
            log.Info("Total number of Skipped Records : "+ TotalSkippedRecords);
            log.Info("Total number of Valid Records : " + TotalValidRecords);
            log.Info(" Elapsed Time is { 0 } s : "+(stopwatch.ElapsedMilliseconds)/1000);
        }



      
    }
}
