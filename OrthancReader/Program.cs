using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrthancReader
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            testObject();
            //MakeCatalog();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
        static async void testObject()
        {
            string[] patients = Orthanc.GetPatients();
            var patient = Orthanc.GetPatient(patients[patients.Length - 1]);

            //string[] inst = Orthanc.GetRecentInstances();
            string[] instances = Orthanc.GetInstances();
            //string patientId = Orthanc.GetPatientId(instances[instances.Length-1]);
            string relativePath = Orthanc.GetPath(instances[instances.Length - 1]);

        }
        static void MakeCatalog()
        {
            string[] instances = Orthanc.GetInstances();
            DateTime previousDate = DateTime.MinValue;
            using (StreamWriter sWriter = new StreamWriter("catalog.csv"))
            {
                for (int i = 0; i < instances.Length; i++)
                {
                    DateTime date = Orthanc.GetCreationDate(instances[i]);
                    TimeSpan span = date.Subtract(previousDate);
                    previousDate = date;
                    sWriter.WriteLine(i + "," + instances[i] + "," + date.ToString("yyyy-MM-dd HH:mm:ss.fff") + "," + span.TotalMilliseconds);
                }
            }
        }
    }
}
