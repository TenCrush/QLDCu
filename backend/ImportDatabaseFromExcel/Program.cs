using Microsoft.Office.Interop.Excel;
using System;

namespace ImportDatabaseFromExcel
{
    class Program
    {
        static void Main(string[] args)
        {

            Application xlApp = new Application();
            Workbook xlWorkbook = xlApp.Workbooks.Open("data.xlsx");
            _Worksheet xlWorksheet = (_Worksheet) xlWorkbook.Sheets[1];
            Microsoft.Office.Interop.Excel.Range xlRange = xlWorksheet.UsedRange;
            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            //iterate over the rows and columns and print to the console as it appears in the file
            //excel is not zero based!!
            //for (int i = 1; i <= rowCount; i++)
            //{
            //    for (int j = 1; j <= colCount; j++)
            //    {
            //        //new line
            //        if (j == 1)
            //            Console.Write("\r\n");

            //        //write the value to the console
            //        if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
            //            Console.Write(xlRange.Cells[i, j].Value2.ToString() + "\t");
            //    }
            //}

        }
    }
}
