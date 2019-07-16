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
            Application.Run(new Form1());
        }
        static async void testObject()
        {
            string[] inst = Orthanc.GetRecentInstances();
            string[] instances = Orthanc.GetInstances();
            Orthanc.GetInfo(instances[0]);

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
