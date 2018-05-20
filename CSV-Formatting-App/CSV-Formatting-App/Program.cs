using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_Formatting_App
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("| Pub Date    |                       Title | Authors                         | \n" +
                "|=============================================================================|");

            List<Values> values = File.ReadAllLines(@"C:\Users\Alex\Documents\CSV-Formatting\example.csv")
                                    .Skip(1)
                                    .Select(v => Values.FromCsv(v))
                                    .ToList();

            Console.ReadLine();
        }
    }

       public class Values
        {
            string PublicationDate;
            string Title;
            string Authors;

            public static Values FromCsv(string csvLine)
        {
            string[] data = csvLine.Split(',');
            Values values = new Values
            {
                PublicationDate = Convert.ToDateTime(data[0]).ToString("dd MMM yyyy"),
                Title = data[1].PadLeft( 27, ' '),
                Authors = data[2].PadRight(31 , ' ')
            };

            if (values.Title.Count() > 28)
            {
                values.Title =  values.Title.Remove(20).PadLeft(24, ' ') + "...";
            }
            if (values.Authors.Count() > 32)
            {
                values.Authors = values.Authors.Remove(28).PadLeft(24, ' ') + "...";
            }
            Console.WriteLine("| " + values.PublicationDate + " | " + values.Title + " | " + values.Authors + " | ");
            return values;
        }
  
    }
}