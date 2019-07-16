using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
//using NewtonSoft.Json;
using Newtonsoft.Json;

namespace OrthancReader
{
    public static class Orthanc
    {
        #region fields
        public static string restUri = "http://localhost:8042/";
        static WebClient getClient = new WebClient();
        static HttpClient postClient = new HttpClient();
        static string lastQueriedInstance = "";
        public static int instanceCount = -1;
        #endregion

        #region utility
        private async static Task<string> sendPostData(string uri, string[] keysAndValues)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            for (int i = 0; i < keysAndValues.Length; i += 2)
            {
                sb.Append("\"");
                sb.Append(keysAndValues[i]);
                sb.Append("\":");
                if (keysAndValues[i + 1][0] != '{')
                {
                    sb.Append("\"");
                }
                sb.Append(keysAndValues[i + 1]);
                if (keysAndValues[i + 1][0] != '{')
                {
                    sb.Append("\"");
                }
                if (i < keysAndValues.Length - 2)
                {
                    sb.Append(",");

                }
            }
            sb.Append("}");
            string sbString = sb.ToString();
            ByteArrayContent bytes = new ByteArrayContent(Encoding.UTF8.GetBytes(sbString));

            var response = await postClient.PostAsync(uri, bytes);
            var responseString = await response.Content.ReadAsStringAsync();
            return responseString;
        }
        private static string[] parseArray(string page)
        {
            List<string> ids = new List<string>();
            string[] items = page.Split(',');
            for (int i = 0; i < items.Length; i++)
            {
                string id = items[i];
                if (id.Contains('"'))
                {
                    id = id.Substring(id.IndexOf('"') + 1);
                    id = id.Substring(0, id.LastIndexOf('"'));
                    ids.Add(id);
                }
            }
            return ids.ToArray();
        }
        #endregion

        #region content
        public static string[] GetInstances()
        {
            string address = restUri + "instances";
            string page = getClient.DownloadString(address);
            string[] instances = parseArray(page);
            instanceCount = instances.Length;
            return instances;
        }
        public static string GetStudies()
        {
            string address = restUri + "studies";
            string page = getClient.DownloadString(address);
            return page;
        }
        public static void DownloadFile(string instanceCode, string filename)
        {
        }
        public static void GetInfo(string instanceCode)
        {
            string instanceText = GetInstance(instanceCode);
            string parentSeries = GetValue(instanceText, "ParentSeries");
            string seriesText = getClient.DownloadString(restUri + "series/" + parentSeries);
            string seriesDescription = GetValue(seriesText, "SeriesDescription");
            string parentStudy = GetValue(seriesText, "ParentStudy");
            //the study will just be a list of series.
            try
            {
                string studyText = getClient.DownloadString(restUri + "study/" + parentStudy);
            }
            catch(WebException ex)
            {
                //do nothing
            }

        }
        #endregion

        public static string[] GetRecentInstances()
        {
            List<string> retVal = new List<string>();
            string[] instances = GetInstances();
            if (instances.Length > 0)
            {
                if (!instances[instances.Length - 1].Equals(lastQueriedInstance))
                {
                    DateTime startDate = DateTime.Now.AddDays(-2);
                    for (int i = 0; i < instances.Length; i++)
                    {
                        DateTime date = GetCreationDate(instances[i]);
                        if (date.CompareTo(startDate) > 0)
                        {
                            retVal.Add(instances[i]);
                        }
                    }
                }
                lastQueriedInstance = instances[instances.Length - 1];
            }
            return retVal.ToArray();
        }
        public static DateTime GetCreationDate(string instance)
        {
            int returnValue = int.MinValue;
            string address = restUri + "instances/" + instance;
            string page = getClient.DownloadString(address);
            string date = GetValue(page, "\"InstanceCreationDate\" : \"");
            string time = GetValue(page, "\"InstanceCreationTime\" : \"");
            return DateTime.ParseExact(date + time, "yyyyMMddHHmmss.fff", null);

             double.Parse(date + time);
        }
        private static string GetValue(string page, string target)
        {
            if(target == null || target.Length == 0)
            {
                throw new ArgumentException("you must specify a target");
            }
            if(target[0] != '"')
            {
                target = "\"" + target + "\" : \"";
            }
            string retVal = "";
            int targetInd = page.IndexOf(target);
            if (targetInd > -1)
            {
                retVal = page.Substring(targetInd + target.Length);
                retVal = retVal.Substring(0, retVal.IndexOf('"'));
            }
            return retVal;
        }
        public static string GetInstance(string instance)
        {
            string address = restUri + "instances/" + instance;
            string page = getClient.DownloadString(address);
            object obj = Newtonsoft.Json.JsonConvert.DeserializeObject(page);
            return page;
        }
    }
}
