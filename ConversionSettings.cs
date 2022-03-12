using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Converter
{
    public partial class ConversionSettings : Form
    {
        public int convert = Properties.Settings.Default.chk;
        public ConversionSettings()
        {
            InitializeComponent();
        }

        private void btnExitForm_Click(object sender, EventArgs e)
        {

            //Save JSON
            if (rbtnJson.Checked)
            {
                Properties.Settings.Default.chk = 0;
            }
            //Save SCV
            else if (rbtnCsv.Checked)
            {
                Properties.Settings.Default.chk = 1;
            }
            //Save XML
            else if (rbtnXML.Checked)
            {
                Properties.Settings.Default.chk = 2;
            }
            //Save XLSX
            else
            {
                Properties.Settings.Default.chk = 3;
            }
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void ConversionSettings_Load(object sender, EventArgs e)
        {
            switch (Properties.Settings.Default.chk)
            {
                case 0:
                    rbtnJson.Checked = true;
                    break;
                case 1:
                    rbtnCsv.Checked = true;
                    break;
                case 2:
                    rbtnXML.Checked = true;
                    break;
                case 3:
                    rbtnXLSX.Checked = true;
                    break;
            }
        }
    }
}
