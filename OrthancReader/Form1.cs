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
    public partial class Form1 : Form
    {
        Timer timer;
        public Form1()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
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
    }
}
