using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Weather.Entities.CityEntities;
using Weather.Service;

namespace Weather
{
    class Program
    {
        public static string[] CITYcolumns { get; set; } = null;

        static void Main(string[] args)
        {
            WorkerRole Obj = new WorkerRole();

            Obj.OnStart();

            //int counter = 0;
            //string line;
            ////List<CityModel> LstCity = new List<CityModel>();

            //List<string[]> arrayList = new List<string[]>();
            //// Read the file and display it line by line.
            //System.IO.StreamReader file =
            //   new System.IO.StreamReader("c:\\Angular\\test.txt");
            //while ((line = file.ReadLine()) != null)
            //{
            //    if (counter != 0)
            //        arrayList.Add(Splitter(line));
            //    //call your function here
            //    counter++;
            //}

            //file.Close();

            //// Suspend the screen.
            //Console.ReadLine();
        }

        // Method to split a line into a string array separated by whitespace
        private static string[] Splitter(string input)
        {
            return Regex.Split(input, @"\t+");
        }
    }
}
