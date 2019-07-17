using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrthancReader
{
    public partial class FormMain : Form
    {
        Timer timer;
        public FormMain()
        {

            this.FormClosed += FormMain_FormClosed;
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Orthanc.SaveConfig();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if(checkBoxSynchronize.Checked)
            {
                processNewFiles();
            }
        }

        private void processNewFiles()
        {

        }

        private void labelStatus_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxSynchronize_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBoxOrthancFolder_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dg = new FolderBrowserDialog();
            dg.SelectedPath = textBoxDicomFolder.Text;
            if (dg.ShowDialog() == DialogResult.OK)
            {
                textBoxDicomFolder.Text = dg.SelectedPath;
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            copyEverything();
        }

        private void copyEverything()
        {
            Orthanc.CreateNeededFolders();
            string[] instances = Orthanc.GetInstances();
            Orthanc.CopyFiles(instances);

        }
    }
}
