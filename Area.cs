using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Xml;
using System.Windows.Forms;

namespace Converter
{
    class Area
    {
        String AreaName;
        String AreaPlace;
        String LevelOfThreat;
        String QuantityCitizens;
        public Area(String name, String place, String level, String citizens)
        {
            AreaName = name;
            AreaPlace = place;
            LevelOfThreat = level;
            QuantityCitizens = citizens;
        }
        public override string ToString()
        {
            return AreaName + ", " + AreaPlace + ", " + LevelOfThreat + ", " + QuantityCitizens;
        }
        public static void convertToJSON(String LastPath, String FilePath, List<String> lines)
        {
            var li = File.ReadAllLines(FilePath);

            var model = li.Select(p => new
            {
                name = p.Split(", ")[0],
                place = p.Split(", ")[1],
                level = p.Split(", ")[2],
                citizens = p.Split(", ")[3],
            });
            var json = System.Text.Json.JsonSerializer.Serialize(model);
            LastPath = LastPath.Replace(".txt", ".json");
            using (StreamWriter sw = new StreamWriter(LastPath))
            {
                sw.WriteLine(json);
            }
        }
        public static void convertToCSV(String LastPath, String FilePath, List<String> lines)
        {
            LastPath = LastPath.Replace(".txt", ".csv");
            using (StreamWriter sw = new StreamWriter(LastPath))
            {
                sw.WriteLine("name,place,level,citizens");
                foreach (String item in lines)
                {
                    sw.WriteLine(item);
                }
            }
        }
        public static void convertToXML(String LastPath, String FilePath, List<String> lines)
        {
            var sr = new StreamReader(FilePath);
            var xmlTree = new XStreamingElement("Root",
                from line in sr.Lines()
                let items = line.Split(',')
                select new XElement("Area",
                            new XAttribute("name", items[0]),
                            new XElement("place", items[1]),
                            new XElement("level", items[2]),
                            new XElement("citizens", items[3])
                        )
            );
            using (StreamWriter sw = new StreamWriter(LastPath))
            {
                sw.WriteLine(xmlTree);
            }
        }
        public static void convertToXLSX(String LastPath, String FilePath, List<String> lines)
        {
            LastPath = LastPath.Replace(".txt", ".xlsx");
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
            ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
            var fr = new StreamReader(FilePath);
            String[] areas;
            int ii = 1;
            foreach (String item in lines)
            {
                areas = item.Split(",");
                for (int i = ii; i <= lines.Count; i++)
                {
                    for (int j = 1; j <= 4; j++)
                    {
                        ExcelWorkSheet.Cells[i, j] = areas[j - 1];
                    }
                }
                ii++;
            }
            ExcelWorkBook.SaveAs(LastPath);
            ExcelWorkBook.Close(true);
            ExcelApp.Quit();
        }
        public static String convertToTXT(String LastPath, String FilePath)
        {
            List<Area> areas = new List<Area>();
            String LastPath1 = "";
            //JSON
            if (FilePath.Contains(".json"))
            {
                LastPath1 = FilePath.Replace(".json", ".txt");
                string json = File.ReadAllText(FilePath);
                areas = JsonConvert.DeserializeObject<List<Area>>(json);
                using (StreamWriter sw = new StreamWriter(LastPath1))
                {
                    foreach (Area item in areas)
                    {
                        sw.WriteLine(item);
                    }
                }
            }
            //CSV
            else if (FilePath.Contains(".csv"))
            {
                LastPath1 = FilePath.Replace(".csv", ".txt");
                string[] lns = File.ReadAllLines(FilePath);
                List<String> lnes = new List<String>();
                using (StreamReader fs = new StreamReader(FilePath))
                {
                    while (true)
                    {
                        string temp = fs.ReadLine();

                        if (temp == null) break;

                        lnes.Add(temp);
                    }
                }
                using (StreamWriter sw = new StreamWriter(LastPath1))
                {
                    foreach (String item in lnes)
                    {
                        sw.WriteLine(item);
                    }
                }
            }
            //XML
            else if (FilePath.Contains(".xml"))
            {
                LastPath1 = FilePath.Replace(".xml", ".txt");
                XmlTextReader reader = new XmlTextReader(FilePath);
                String s = "";
                while (reader.Read())
                {
                    int i = 0;
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element: // The node is an element.
                            while (reader.MoveToNextAttribute()) // Read the attributes.
                                s += reader.Value;
                            break;
                        case XmlNodeType.Text: //Display the text in each element.
                            s += "," + reader.Value;
                            break;
                        case XmlNodeType.EndElement: //Display the end of the element.
                            if (reader.Name == "Area")
                            {
                                s += "\n";
                            }
                            break;
                    }
                }
                string[] values = s.Split("\n");
                using (TextWriter tw = new StreamWriter(LastPath1))
                {
                    foreach (String q in values)
                    {
                        if (!q.Equals(""))
                            tw.WriteLine(q);
                    }
                }
            }
            //XLSX
            else if (FilePath.Contains(".xlsx"))
            {
                LastPath1 = FilePath.Replace(".xlsx", ".txt");
                Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application(); //открыть эксель
                Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook = ExcelApp.Workbooks.Open(FilePath);
                Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Sheets[1]; //получить 1 лист
                Microsoft.Office.Interop.Excel.Range range;

                var lastCell = ExcelWorkSheet.Cells.SpecialCells(Microsoft.Office.Interop.Excel.XlCellType.xlCellTypeLastCell);//1 ячейку

                string[,] list = new string[lastCell.Row, lastCell.Column]; // массив значений с листа равен по размеру листу
                for (int i = 0; i < (int)lastCell.Row; i++) //по всем колонкам
                    for (int j = 0; j < (int)lastCell.Column; j++) // по всем строкам
                    {
                        range = (Microsoft.Office.Interop.Excel.Range)ExcelWorkSheet.Cells[i + 1, j + 1];
                        list[i, j] = range.Value.ToString();
                    }

                ExcelWorkBook.Close(false, Type.Missing, Type.Missing); //закрыть не сохраняя
                ExcelApp.Quit(); // выйти из экселя
                for (int i = 0; i < list.GetLength(0); i++)
                {
                    Area area = new Area(list[i, 0], list[i, 1], list[i, 2], list[i, 3]);
                    areas.Add(area);
                }
                using (TextWriter tw = new StreamWriter(LastPath1))
                {
                    foreach (Area item in areas)
                    {
                        tw.WriteLine(item);
                    }
                }
            }

            return LastPath1;
        }
    }
}
