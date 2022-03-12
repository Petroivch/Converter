using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;

namespace Converter
{
    public partial class frmMain : Form
    {

        Color color;
        String FilePath;
        String LastPath;
        public frmMain()
        {
            InitializeComponent();
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnExit_MouseHover(object sender, EventArgs e)
        {
            color = btnExit.BackColor;
            btnExit.BackColor = Color.Red;

        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.BackColor = color;
        }

        private void btnFileSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog OPF = new OpenFileDialog();
            OPF.InitialDirectory = Directory.GetCurrentDirectory() + "\\input";
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                FilePath = OPF.FileName;
            }
        }
        public String getFilePath()
        {
            return FilePath;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Converter.ConversionSettings form = new Converter.ConversionSettings();
            form.ShowDialog();
        }

        private void Convertion_Click(object sender, EventArgs e)
        {
            SaveFileDialog SFD = new SaveFileDialog();
            SFD.InitialDirectory = Directory.GetCurrentDirectory() + "\\output";
            ConversionSettings cs = new ConversionSettings();
            int convert = cs.convert;
            switch (convert)
            {
                case 0:
                    SFD.Filter = "JSON|.json";
                    break;
                case 1:
                    SFD.Filter = "CSV|*.csv";
                    break;
                case 2:
                    SFD.Filter = "XML|*.xml";
                    break;
                case 3:
                    SFD.Filter = "XLSX|*.xlsx";
                    break;
            }
            if (SFD.ShowDialog() == DialogResult.OK)
            {
                LastPath = SFD.FileName;
                SaveFile(LastPath);
            }
            MessageBox.Show("Ваш файл находится в " + LastPath);
        }
        private void SaveFile(String LastPath)
        {
            if (!FilePath.Contains(".txt"))
            {
                FilePath = Area.convertToTXT(LastPath, FilePath);
            }
            List<String> lines = new List<string>();
            using (StreamReader fs = new StreamReader(FilePath))
            {
                while (true)
                {
                    string temp = fs.ReadLine();

                    if (temp == null) break;

                    lines.Add(temp);
                }
            }
            ConversionSettings cs = new ConversionSettings();
            int convert = cs.convert;
            switch (convert)
            {
                case 0:
                    Area.convertToJSON(LastPath, FilePath, lines);
                    break;
                case 1:
                    Area.convertToCSV(LastPath, FilePath, lines);
                    break;
                case 2:
                    Area.convertToXML(LastPath, FilePath, lines);
                    break;
                case 3:
                    Area.convertToXLSX(LastPath, FilePath, lines);
                    break;
            }
            /*using (StreamWriter sw = new StreamWriter(LastPath))
            {
                foreach (String item in lines)
                {
                    sw.WriteLine(item);
                }
            } */

        }
    }
    public static class StreamReaderSequence
    {
        public static IEnumerable<string> Lines(this StreamReader source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            string line;
            while ((line = source.ReadLine()) != null)
            {
                yield return line;
            }
        }
    }
}
