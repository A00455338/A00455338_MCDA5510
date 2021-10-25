using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class WriteResults
    {
        public void WriteData(string[] data,DateTime dt)
        {
            StreamWriter sw;
            string path = @"D:\Assignment1_software_Development\Assignment1\A00455338_MCDA5510\Assignment1\Output\Output.txt";
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (sw = File.CreateText(path))
                {
                    sw.Write("First Name, ");
                    sw.Write("Last Name, ");
                    sw.Write("Street Number, ");
                    sw.Write("Street, ");
                    sw.Write("City, ");
                    sw.Write("Province, ");
                    sw.Write("Country, ");
                    sw.Write("Postal Code, ");
                    sw.Write("Phone Number, ");
                    sw.Write("Email Adddress, ");
                    sw.WriteLine("Date");
                    sw.Close();
                }
            }

            // Open the file to read from.
            sw = new StreamWriter(path, true, Encoding.ASCII);
            for (int x = 0; x < data.Length; x++)
            {
                sw.Write(data[x]+", ");
            }
            sw.WriteLine(dt.Date);
            sw.Close();
        }
    }
}
