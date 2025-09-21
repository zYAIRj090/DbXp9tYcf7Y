// 代码生成时间: 2025-09-21 11:05:42
using System;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace ExcelGenerator
{
    // Excel表格自动生成器
    public class ExcelGenerator
    {
        /// <summary>
        /// 生成Excel文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="sheetName">工作表名称</param>
        /// <param name="headers">表头列表</param>
        /// <param name="data">数据行列表</param>
        public void GenerateExcel(string filePath, string sheetName, string[] headers, string[][] data)
        {
            try
            {
                // 检查文件路径
                if (string.IsNullOrEmpty(filePath)) throw new ArgumentException("文件路径不能为空");

                // 创建Excel文件
                using (SpreadsheetDocument document = SpreadsheetDocument.Create(filePath, SpreadsheetDocumentType.Workbook))
                {
                    // 添加一个工作簿
                    WorkbookPart workbookPart = document.AddWorkbookPart();
                    workbookPart.Workbook = new Workbook();

                    // 添加一个工作表
                    WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                    worksheetPart.Worksheet = new Worksheet(new SheetData());

                    // 添加表格头部
                    SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();
                    uint sheetId = 1;
                    workbookPart.Workbook.AppendChild(new SheetsSequence()).AppendChild(new Sheet()
                    {
                        Id = workbookPart.GetIdOfPart(worksheetPart),
                        SheetId = sheetId,
                        Name = sheetName
                    });

                    // 添加表头
                    uint cellReference = 1;
                    foreach (var header in headers)
                    {
                        Cell cell = new Cell() {
                            CellReference = $"{(char)('A' + cellReference++)}\"1\""
                        };
                        cell.CellValue = new CellValue(header);
                        cell.DataType = new EnumValue<CellValues>(CellValues.String);
                        sheetData.AppendChild(cell);
                    }

                    // 添加数据行
                    uint rowNum = 2;
                    foreach (var row in data)
                    {
                        foreach (var item in row)
                        {
                            Cell cell = new Cell() {
                                CellReference = $"{(char)('A' + rowNum)}\"{rowNum}\