using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
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
        public static long instanceCount = -1;
        public static long instanceCopyNumber = -1;
        static string configFile = "config.txt";
        public static string rootFolder = @"C:\Orthanc\FIRMM";


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
        public static string[] GetStudies()
        {
            string address = restUri + "studies";
            string page = getClient.DownloadString(address);
            return parseArray(page);
        }
        public static string[] GetPatients()
        {
            string address = restUri + "patients";
            string page = getClient.DownloadString(address);
            return parseArray(page);
        }
        public static void DownloadFile(string instanceCode, string filename)
        {
        }
        public static Patient GetPatientWithInstanceCode(string instanceCode)
        {
            Instance instance = GetInstance(instanceCode);
            Series series = GetSeries(instance.ParentSeries);
            Study study = GetStudy(series.ParentStudy);
            Patient patient = GetPatient(study.ParentPatient);

            // getClient.DownloadString(restUri + "series/" + instance.ParentSeries);
            //string parentStudy = GetValue(seriesText, "ParentStudy");
            //string studyText;
            //string patientId;

            //string seriesDescription = GetValue(seriesText, "SeriesDescription");
            //studyText = getClient.DownloadString(restUri + "studies/" + parentStudy);
            //patientId = GetValue(studyText, "PatientID");
            return patient;
        }

        public static string GetPath(string instanceCode)
        {
            //StringBuilder path = new StringBuilder();
            //string instanceText = GetInstance(instanceCode);
            //string seriesCode = GetValue(instanceText, "ParentSeries");
            //string seriesText = getClient.DownloadString(restUri + "series/" + seriesCode);
            //string seriesDescription = GetValue(seriesText, "SeriesDescription");
            //string studyCode = GetValue(seriesText, "ParentStudy");
            //string studyText = getClient.DownloadString(restUri + "studies/" + studyCode); 
            //string patientId = GetValue(studyText, "PatientID");


            ////debug
            //string patientCode = GetValue(studyText, "ParentPatient");
            //var patientText = GetPatient(patientCode);
            ////end debug
            ///
            Instance instance = GetInstance(instanceCode);
            Series series = GetSeries(instance.ParentSeries);
            Study study = GetStudy(series.ParentStudy);
            //Patient patient = GetPatient(study.ParentPatient);
            return getInstanceFilename(study, series, instance);



            //string value = study.PatientMainDicomTags.PatientID + "\\" + study.MainDicomTags.RequestedProcedureDescription + "\\" + series.MainDicomTags.SeriesNumber + "\\" + instance.IndexInSeries;

            //string protocolName = GetValue(studyText, "ProtocolName");

            //path.Append(patientId);
            //path.Append("\\");



            //return path.ToString();

            //return value;
        }

        public static string getPatientFolder(Study study)
        {
            if (rootFolder[rootFolder.Length - 1] != '\\')
            {
                rootFolder = rootFolder + "\\";
            }
            return rootFolder + study.PatientMainDicomTags.PatientName + "\\";
        }
        public static string getStudyFolder(Study study)
        {
            DateTime date = DateTime.ParseExact(study.MainDicomTags.StudyDate, "yyyyMMdd", null);
            DateTime date2 = date.AddYears(-28 * 12);
            date2 = date2.AddDays(-70 * 7);
            string dateString = date2.ToString("yyyyMMdd");
            return getPatientFolder(study) + dateString + "\\";
        }
        public static string getSeriesFolder(Study study, Series series)
        {
            return getStudyFolder(study) + series.MainDicomTags.ProtocolName + "\\";
        }
        public static string getSeriesRunFolder(Study study, Series series)
        {
            return getSeriesFolder(study, series) + series.MainDicomTags.SeriesNumber + "\\";
        }
        public static string getInstanceFilename(Study study, Series series, Instance instance)
        {
            return getSeriesRunFolder(study, series) + instance.MainDicomTags.InstanceNumber;

        }
        public static string getInstanceFilename(string instanceCode)
        {
            Instance instance = GetInstance(instanceCode);
            Series series = GetSeries(instance.ParentSeries);
            Study study = GetStudy(series.ParentStudy);

            return getSeriesRunFolder(study, series) + instance.MainDicomTags.InstanceNumber + ".dcm";

        }

        public async static void CopyFiles(string[] instances)
        {
            CreateNeededFolders();
            for (int i = 0; i < instances.Length; i++)
            {
                string filename = getInstanceFilename(instances[i]);
                string uri = restUri + "instances/" + instances[i] + "/file";
                try
                {
                    getClient.DownloadFile(uri, filename);
                    int dummy = 1;
                }
                catch (Exception ex)
                {
                }
            }
        }

        public static void CreateNeededFolders()
        {
            if(!Directory.Exists(rootFolder))
            {
                throw new ApplicationException("trying to write to rootFolder that doesn't exist: " + rootFolder);
            }
            string[] patientCodes = GetPatients();
            for (int i = 0; i < patientCodes.Length; i++)
            {
                Patient patient = GetPatient(patientCodes[i]);
                for (int j = 0; j < patient.Studies.Length; j++)
                {
                    Study study = GetStudy(patient.Studies[j]);
                    string patientFolder = getPatientFolder(study);

                    if (!Directory.Exists(patientFolder))
                    {
                        Directory.CreateDirectory(patientFolder);
                    }

                    string studyFolder = getStudyFolder(study);
                    if(!Directory.Exists(studyFolder))
                    {
                        Directory.CreateDirectory(studyFolder);
                    }
                    for (int k = 0; k < study.Series.Length; k++)
                    {
                        Series series = GetSeries(study.Series[k]);
                        string seriesFolder = getSeriesFolder(study, series);
                        string seriesRunFolder = getSeriesRunFolder(study, series);
                        //debug
                        if (study.PatientMainDicomTags.PatientName.Equals("PHANTOMNETZ"))
                        {
                            int dummy = 1;
                        }
                        //end debug
                        if (!Directory.Exists(seriesFolder))
                        {
                            Directory.CreateDirectory(seriesFolder);
                        }
                        if (!Directory.Exists(seriesRunFolder))
                        {
                            Directory.CreateDirectory(seriesRunFolder);
                        }
                        //for (int m = 0; m < series.Instances.Length; m++)
                        //{
                        //    Instance instance = GetInstance(series.Instances[m]);
                        //    //if(study.ID.Equals(rsFC))
                        //    //study.PatientMainDicomTags.PatientID + "\\" + study.MainDicomTags.RequestedProcedureDescription + "\\" + series.MainDicomTags.SeriesNumber + "\\" + instance.IndexInSeries;
                        //}
                    }
                }
                //var studies = JsonConvert.DeserializeObject<string[]>(studyCodes as string); 
            }

        }

        public static void SaveConfig()
        {
            using (StreamWriter sWriter = new StreamWriter(configFile))
            {
                sWriter.WriteLine(restUri);
                sWriter.WriteLine(lastQueriedInstance);
                sWriter.WriteLine(instanceCount);

            }
        }
        public static void LoadConfig()
        {
            int maxErrors = 5;
            int errorCount = 0;
            bool success = false;
            while (!success && errorCount < maxErrors)
            {
                try
                {
                    using (StreamReader sReader = new StreamReader(configFile))
                    {
                        restUri = sReader.ReadLine();
                        lastQueriedInstance = sReader.ReadLine();
                        instanceCount = long.Parse(sReader.ReadLine());
                    }
                }
                catch(Exception ex)
                {
                    errorCount++;
                    Thread.Sleep(100);
                }
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
            if (target == null || target.Length == 0)
            {
                throw new ArgumentException("you must specify a target");
            }
            if (target[0] != '"')
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
        public static Instance GetInstance(string instanceCode)
        {
            string address = restUri + "instances/" + instanceCode;
            string page = getClient.DownloadString(address);
            //object obj = Newtonsoft.Json.JsonConvert.DeserializeObject(page);
            Instance ins = JsonConvert.DeserializeObject<Instance>(page);
            return ins;
        }
        //public static string GetPatizent(string patientId)
        public static Patient GetPatient(string patientId)
        {
            string address = restUri + "patients/" + patientId;
            string page = getClient.DownloadString(address);
            Patient p = JsonConvert.DeserializeObject<Patient>(page);
            return p;
        }
        public static Study GetStudy(string studyId)
        {
            string address = restUri + "studies/" + studyId;
            string page = getClient.DownloadString(address);
            Study p = JsonConvert.DeserializeObject<Study>(page);
            return p;
        }
        public static Series GetSeries(string seriesId)
        {
            string address = restUri + "series/" + seriesId;
            string page = getClient.DownloadString(address);
            Series p = JsonConvert.DeserializeObject<Series>(page);
            return p;
        }
    }
}
