using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace Weather.Automation
{
    public class WeatherApiCall
    {
        public static string _appid;
        private readonly RestClient _client;
        private static string _baseurl;
        public WeatherApiCall()
        {
            _appid = "aa69195559bd4f88d79f9aadeb77a8f6";
            _baseurl = "https://samples.openweathermap.org/";
            _client = new RestClient(_baseurl);
        }

        public async Task WeatherRequest(string cityname)
        {

            var request = new RestRequest("data/2.5/weather", Method.GET);
            request.AddQueryParameter("q", cityname);
            request.AddQueryParameter("appid", _appid);

            var response = _client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                String Todaysdate = DateTime.Now.ToString("dd-MMM-yyyy");

                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                if (!Directory.Exists(docPath + "\\" + Todaysdate))
                {
                    Directory.CreateDirectory(docPath + "\\" + Todaysdate);

                }
                string FinalFilePath = docPath + "\\" + Todaysdate;
                string text = cityname + Environment.NewLine + Environment.NewLine;

                File.WriteAllText(Path.Combine(FinalFilePath, cityname + ".txt"), text);

                string[] lines = { response.Content.ToString() };

                File.AppendAllLines(Path.Combine(FinalFilePath, cityname + ".txt"), lines);
            }
        }

    }
}
