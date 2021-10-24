using Microsoft.VisualBasic.FileIO;
using System;
using System.IO;

namespace Assignment1
{
    class Program
    {
        int sum=0;
        int skippedRecords = 0;
        int flag = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Program ob = new Program();
            ob.walk("D:\\MCDA5510_Assignments\\Sample Data\\Sample Data");
        }

        public void walk(String path)
        {
           
            string[] list = Directory.GetDirectories(path);


            if (list == null) return;

            foreach (string dirpath in list)
            {
                if (Directory.Exists(dirpath))
                {
                    walk(dirpath);
                    //Console.WriteLine("Dir:" + dirpath);
                }
            }
            //Console.WriteLine("extra");
            string[] fileList = Directory.GetFiles(path);
            foreach (string filepath in fileList)
            {
                if(filepath.EndsWith("csv"))
                {
                    //Console.WriteLine("File:" + filepath);
                    parse(filepath);
                }
                //Console.WriteLine("File:" + filepath);
            }
        }

        public void parse(String fileName)
        {
            try
            {
                using (TextFieldParser parser = new TextFieldParser(fileName))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    skippedRecords = 0;
                    flag=0;
                    while (!parser.EndOfData)
                    {
                        //Process row
                        string[] fields = parser.ReadFields();
                        for(int i=0;i<fields.Length && fields.Length==10;i++)
                        {
                            if(fields[0].Length==0|| fields[1].Length == 0 || fields[6].Length == 0 || fields[7].Length == 0 || fields[9].Length==0)
                            {
                                flag = 1;
                            }
                        }
                        /*foreach (string field in fields)
                        {
                            if(field.Length==0)
                            {
                                flag = 1;
                                break;
                            }
                            /*else
                            {
                                flag = 0;
                                break;
                                //Console.WriteLine(field)
                            }
                        }*/
                        if(flag==1)
                        {
                            skippedRecords++;
                        }
                       /* else
                        {
                            correct++;
                        }*/
                    }
                    sum = sum + skippedRecords;
                }
                Console.WriteLine(sum);
            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.StackTrace);
            }

        }
    }
}
