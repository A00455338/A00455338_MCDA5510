using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class ParseCsvFile
    {
        //public static double sum = 0;
        private static double skippedRecords = 0;
        int flag = 0;
        public double parse(String fileName)
        {
            try
            {
                using (TextFieldParser parser = new TextFieldParser(fileName))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    skippedRecords = 0;
                    while (!parser.EndOfData)
                    {
                        flag = 0;
                        //Process row
                        string[] fields = parser.ReadFields();
                        for (int i = 0; i < fields.Length && fields.Length == 10; i++)
                        {
                            if (fields[0].Length == 0 || fields[1].Length == 0 || fields[6].Length == 0 || fields[7].Length == 0 || fields[9].Length == 0)
                            {
                                flag = 1;
                                break;
                            }
                        }
                        if (flag == 1)
                        {
                            skippedRecords++;
                        }
                    }
                }
                return skippedRecords;
            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.StackTrace);
                return 0;
            }

        }
    }
}
