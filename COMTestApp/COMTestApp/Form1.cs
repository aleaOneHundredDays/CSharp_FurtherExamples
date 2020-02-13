using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace COMTestApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            if (xlApp == null)
            {
                MessageBox.Show("Excel is not properly installed!!");
                return;
            }

            xlApp.DisplayAlerts = false;
            string filePath = @"c:\Test\Test2.xlsx";
            Workbook xlWorkBook = xlApp.Workbooks.Open(filePath, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
            Sheets worksheets = xlWorkBook.Worksheets;


            string newFileName = "newsheet";
            string newFile = RandomString(4, false);
            newFileName = newFileName + "_" + newFile;


            var xlNewSheet = (Worksheet)worksheets.Add(worksheets[1], Type.Missing, Type.Missing, Type.Missing);
            xlNewSheet.Name = newFileName;
            xlNewSheet.Cells[1, 1] = "New sheet content";

            xlNewSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);
            xlNewSheet.Select();

            xlWorkBook.Save();
            xlWorkBook.Close();

            releaseObject(xlNewSheet);
            releaseObject(worksheets);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);

            MessageBox.Show("New Worksheet Created! Called:" + newFileName);
        }

        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        private static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            if (xlApp == null)
            {
                MessageBox.Show("Excel is not properly installed!!");
                return;
            }

            xlApp.DisplayAlerts = false;


            Workbook newWorkbook = xlApp.Workbooks.Add();
         
            newWorkbook.SaveAs("ExcelTest.xlsx");





            //Input cell value by row and column coordinate
            // worksheet.Cell(1, 1).Value = "A1";

            // //Input cell value by cell name
            // worksheet.Cell("B1").Value = "B1";

            // //Input cell value by row id and column name
            // worksheet.Cell(1, "C").Value = "C1";

            // workbook.SaveAs("CreateNew.xlsx");

            // //Set Excel property values
            //// workbook.Properties.Title = "Sample";
            // //workbook.Properties.Author = "iDiTect";
            // //workbook.Properties.Subject = "iDiTect.Excel Sample";
            // //workbook.Properties.Keywords = "iDiTect.Excel";
            // //workbook.Properties.Category = "iDiTect.Excel";
            // //workbook.Properties.Company = "iDiTect.com";

            // workbook.Save();


        }
    }
}
