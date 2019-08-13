using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Weather.Automation.Entites;

namespace Weather.Automation
{
    public class AutomationWorkEngine : AutomationJobBase
    {
        public static string CheckFile;
        public AutomationWorkEngine()
        {

        }

        public void ExecuteRequest()
        {
            DirectoryInfo di = new DirectoryInfo(@"C:\Weather");
            FileInfo[] TxtFiles = di.GetFiles("*.txt");
            if (TxtFiles.Length > 0)
                RunAutomation(TxtFiles);
        }

        public async override void RunAutomation(FileInfo[] FInfo)
        {
            foreach (var filepath in FInfo)
            {
                await ExecuteFiles(filepath.ToString());
                File.Delete(filepath.ToString());
            }
        }

        public async Task ExecuteFiles(string filepath)
        {
            WeatherApiCall ObjWeatherApiCall = new WeatherApiCall();
            try
            {
                int counter = 0;
                string line = string.Empty;

                List<CityEntities> LstCity = new List<CityEntities>();
                System.IO.StreamReader file =
               new System.IO.StreamReader(filepath.ToString());
                while ((line = file.ReadLine()) != null)
                {
                    if (counter != 0)
                    {
                        string[] arrayList = null;
                        arrayList = Splitter(line);

                        LstCity.Add(new CityEntities { CityID = Convert.ToInt16(arrayList[0].Trim()), CityName = Convert.ToString(arrayList[1].Trim()) });
                    }
                    counter++;
                }

                file.Close();
                foreach (var item in LstCity)
                {
                    await ObjWeatherApiCall.WeatherRequest(item.CityName);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ObjWeatherApiCall = null;
            }
        }

        private static string[] Splitter(string input)
        {
            return Regex.Split(input, @"\t+");
        }
    }
}
