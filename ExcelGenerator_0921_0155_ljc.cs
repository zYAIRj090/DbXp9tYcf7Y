// 代码生成时间: 2025-09-21 01:55:45
 * and maintainability.
 */

using System;
using System.IO;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace ExcelGenerator
{
    public class ExcelGenerator
    {
        private const string FileName = "GeneratedExcel.xlsx";

        /// <summary>
        /// Generates an Excel file with multiple sheets.
        /// </summary>
        /// <param name="sheetNames">An array of sheet names to be created.</param>
        /// <param name="data">A 2D array where each sub-array represents the data for a sheet.</param>
        public void GenerateExcelFile(string[] sheetNames, string[,] data)
        {
            if (sheetNames == null || data == null)
            {
                throw new ArgumentNullException("Sheet names and data cannot be null.");
            }

            if (sheetNames.Length != data.GetLength(0))
            {
                throw new ArgumentException("The number of sheet names and the first dimension of the data array must match.");
            }

            // Using OpenXML SDK to generate an Excel file.
            using (SpreadsheetDocument document = SpreadsheetDocument.Create(FileName, SpreadsheetDocumentType.Workbook))
            {
                // Add a WorkbookPart to the document.
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                // Add a WorksheetPart to the WorkbookPart.
                for (int i = 0; i < sheetNames.Length; i++)
                {
                    Sheet sheet = new Sheet() { Id = workbookPart.AddNewPart<WorksheetPart>().Id, SheetId = (uint)(i + 1), Name = sheetNames[i] };
                    workbookPart.Workbook.AppendChild(sheet);

                    // Add data to the sheet.
                    AddDataToSheet(workbookPart, data[i], i + 1);
                }

                // Save changes.
                document.Save();
            }
        }

        /// <summary>
        /// Adds data to a specific sheet in the Excel file.
        /// </summary>
        /// <param name="workbookPart">The workbook part where the sheet is located.</param>
        /// <param name="sheetData">A 1D array representing the data for the sheet.</param>
        /// <param name="sheetId">The ID of the sheet to add data to.</param>
        private void AddDataToSheet(WorkbookPart workbookPart, string[] sheetData, uint sheetId)
        {
            WorksheetPart worksheetPart = workbookPart.GetPartById(workbookPart.Workbook.Descendants<Sheet>().First(s => s.SheetId.Value == sheetId).Id) as WorksheetPart;
            worksheetPart.Worksheet = new Worksheet(new SheetData());

            // Add rows to the sheet.
            foreach (var item in sheetData)
            {
                Row row = new Row();
                Cell cell = new Cell() { CellValue = new CellValue(item), DataType = new EnumValue<CellValues>(CellValues.String) };
                row.Append(cell);
                worksheetPart.Worksheet.AppendChild(row);
            }

            // Save changes to the worksheet.
            worksheetPart.Worksheet.Save();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ExcelGenerator generator = new ExcelGenerator();
                // Example usage: Create an Excel file with two sheets.
                string[] sheetNames = { "Sheet1", "Sheet2" };
                string[,] data = {
                    { "Data1", "Data2" },
                    { "More Data1", "More Data2" }
                };

                generator.GenerateExcelFile(sheetNames, data);
                Console.WriteLine("Excel file generated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}