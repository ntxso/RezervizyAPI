using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace CoreNT.Utilities
{
    public class ExcelUtility
    {
		public static DataTable ExcelDataToDataTable(string filePath, string sheetName=null, bool hasHeader = true)
		{
			var dt = new DataTable();
			var fi = new FileInfo(filePath);
			// Check if the file exists
			if (!fi.Exists)
				throw new Exception("File " + filePath + " Does Not Exists");

			ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
			var xlPackage = new ExcelPackage(fi);
			// get the first worksheet in the workbook
			var worksheet =(sheetName==null)? xlPackage.Workbook.Worksheets[0]: xlPackage.Workbook.Worksheets[sheetName];

			dt = worksheet.Cells[1, 1, worksheet.Dimension.End.Row, worksheet.Dimension.End.Column].ToDataTable(c =>
			{
				c.FirstRowIsColumnNames = true;
			});

			return dt;
		}

		public static DataTable ExcelDataToDataTable(Stream stream, bool hasHeader = true)
		{
			var dt = new DataTable();
			//var fi = new FileInfo(filePath);
			//// Check if the file exists
			//if (!fi.Exists)
			//	throw new Exception("File " + filePath + " Does Not Exists");

			ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
			var xlPackage = new ExcelPackage(stream);
			// get the first worksheet in the workbook
			var worksheet = xlPackage.Workbook.Worksheets[0];

			dt = worksheet.Cells[1, 1, worksheet.Dimension.End.Row, worksheet.Dimension.End.Column].ToDataTable(c =>
			{
				c.FirstRowIsColumnNames = true;
			});

			return dt;
		}
	}
}
