using log4net;
using log4net.Config;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Assignment1
{
    public class ParseCsvFile
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static double skippedRecords = 0;
        private static double validRecords = 0;
        double[] arr= new double[2];
        int flag = 0;
        int rowNumber = 0;
        WriteResults writedata = new WriteResults();
        public double[] parse(String fileName)
        {
            try
            {
                using (TextFieldParser parser = new TextFieldParser(fileName))
                {
                    DateTime dt = File.GetLastWriteTime(fileName);
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    skippedRecords = 0;
                    rowNumber = 0;
                    while (!parser.EndOfData)
                    {
                        flag = 0;
                        rowNumber++;
                        //Process row
                        string[] fields = parser.ReadFields();
                        for (int i = 0; i < fields.Length && fields.Length == 10; i++)
                        {
                            
                            if (fields[i].Length == 0 && (i==1 || i==0 || i==7 || i==6 || i==9))
                            {
                                flag = 1;
                                log.Error("Field " + i + " is empty of row" + rowNumber + " in file " + fileName);
                                break;
                            }
                            else if(Regex.Match(fields[0], "[0-9]$@!%&*").Success || Regex.Match(fields[1], "[0-9]$@!%&*").Success)
                            {
                                flag = 1;
                                log.Error("Name " + " is invalid of row" + rowNumber + " in file " + fileName);
                                break;
                            }
                                else if (rowNumber != 1 && 
                                !(Regex.IsMatch(fields[9], @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                                           @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                                           @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")))
                                    {
                                        flag = 1;
                                        log.Error("Email " + " is invalid of row" + rowNumber + " in file " + fileName);
                                        break;
                                    }
                        }
                        if (flag == 1)
                        {
                            skippedRecords++;
                        }
                        else if (rowNumber!=1)
                        {
                            validRecords++;
                            writedata.WriteData(fields,dt);
                        }
                    }
                }
                arr[0] = skippedRecords;
                arr[1] = validRecords;
                return arr;
            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.StackTrace);
                return null;
            }

        }
    }
}
