using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JSON_Serialization_Example
{
    class Program
    {

        public class WeatherForecastWithPOCOs
        {
            public DateTimeOffset Date { get; set; }
            public int TemperatureCelsius { get; set; }
            public string Summary { get; set; }
            public string SummaryField { get; set; }
            public IList<DateTimeOffset> DatesAvailable { get; set; }
            public Dictionary<string, HighLowTemps> TemperatureRanges { get; set; }
            public string[] SummaryWords; //{ get; set; } << A property is read-only if it contains a public GETTER but not a public SETTER.
        }

        public class HighLowTemps
        {
            public int High { get; set; }
            public int Low { get; set; }
        }


        static void Main(string[] args)
        {
            DateTimeOffset dateAndTime;
            DateTimeOffset[] dateAndTimesAvailable;

            // Instantiate date and time using years, months, days, 
            // hours, minutes, and seconds
            dateAndTime = new DateTimeOffset(2008, 5, 1, 8, 6, 32,
                                             new TimeSpan(1, 0, 0));

            DateTimeOffset dateAndTimeAvailable1 = new DateTimeOffset(2020, 2, 3, 8, 6, 32,
                                            new TimeSpan(1, 0, 0));

            DateTimeOffset dateAndTimeAvailable2 = new DateTimeOffset(2020, 2, 4, 8, 6, 32,
                                           new TimeSpan(1, 0, 0));

            DateTimeOffset dateAndTimeAvailable3 = new DateTimeOffset(2020, 2, 5, 8, 6, 32,
                                           new TimeSpan(1, 0, 0));

            dateAndTimesAvailable = new DateTimeOffset[] { dateAndTimeAvailable1, dateAndTimeAvailable2, dateAndTimeAvailable3 };


            HighLowTemps hiLo_1 = new HighLowTemps();
            hiLo_1.High = 45;
            hiLo_1.Low = 20;

            HighLowTemps hiLo_2 = new HighLowTemps();
            hiLo_1.High = 65;
            hiLo_1.Low = 30;

            HighLowTemps hiLo_3 = new HighLowTemps();
            hiLo_1.High = 50;
            hiLo_1.Low = 40;



            var tempsHILO = new Dictionary<string, HighLowTemps>()
        {
            { "Monday", new HighLowTemps { High=65, Low=21 } },
            { "Tuesday", new HighLowTemps { High=35, Low=15 } },
            { "Wednesday", new HighLowTemps { High=45, Low=30 } }
        };


            WeatherForecastWithPOCOs forecast1 = new WeatherForecastWithPOCOs();
            forecast1.Date = dateAndTime;
            forecast1.TemperatureCelsius = 25;
            forecast1.Summary = "Weekday 3 Days";

            forecast1.SummaryWords = new string[] {"Sunny","Bright","Warm" };
            forecast1.SummaryField = "ShortRange";
            forecast1.DatesAvailable = dateAndTimesAvailable;
            forecast1.TemperatureRanges = tempsHILO;

            var options = new JsonSerializerOptions
            {
                IgnoreReadOnlyProperties = false,
                WriteIndented = true
            };

            string jsonString = JsonSerializer.Serialize(forecast1,options);

            Console.WriteLine(jsonString);


            string path = @"C:\_Angela\_GIT_CSharp\MiscTextFiles\WeatherReport.json";

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            using (var tw = new StreamWriter(path, true))
            {
                tw.WriteLine(jsonString.ToString());
                tw.Close();
            }


            using (var rw = new StreamReader(path))
            {
                string fileString = rw.ReadToEnd();
                rw.Close();
            
            }


            /// Output looks like this:
            //////////////////////////////////////////////////////
            //    {
            //    "Date": "2008-05-01T08:06:32+01:00",
            //      "TemperatureCelsius": 25,
            //      "Summary": "Weekday 3 Days",
            //      "SummaryField": "ShortRange",
            //      "DatesAvailable": [
            //        "2020-02-03T08:06:32+01:00",
            //        "2020-02-04T08:06:32+01:00",
            //        "2020-02-05T08:06:32+01:00"
            //      ],
            //      "TemperatureRanges": {
            //        "Monday": {
            //          "High": 65,
            //          "Low": 21
            //        },
            //        "Tuesday": {
            //          "High": 35,
            //          "Low": 15
            //        },
            //        "Wednesday": {
            //          "High": 45,
            //          "Low": 30
            //        }
            //      },
            //      "SummaryWords": [
            //        "Sunny",
            //        "Bright",
            //        "Warm"
            //      ]
            //        }

            //////////////////////////////////////////////////////


        
        }
    }
}
