using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using ClosedXML.Excel;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using Model.DB;
using Model.DTO;
using Swashbuckle.Swagger;

namespace WebApp.Helpers
{
	/// <summary>
	/// List To datatable converter.
	/// </summary>
	public class ListToDataTableConverter
	{
		/// <summary>
		/// export generic method
		/// </summary>
		/// <param name="myList"></param>
		/// <typeparam name="T"></typeparam>
		public XLWorkbook ExportToExcel(List<ListTagsDTO> listToDo)
		{

			var wb = new XLWorkbook();
			var ws = wb.Worksheets.Add("todo_worksheet");


			var titleindexer = 1;
			
			foreach (var list in listToDo)
			{

				var items = list.Items.ToList();

					ws.Cell(1, titleindexer).Value = list.Name;
					ws.Range(1, titleindexer, 1,titleindexer+1).Merge().AddToNamed("Titles");

					ws.Cell(2, titleindexer).Value = String.Join(",",list.Tags.Select(i=>i.Name));
					ws.Range(2, titleindexer, 2, titleindexer + 1).Merge().AddToNamed("Tags");

				var rowIndexer = 3;

				foreach (var t in items)
				{

					ws.Cell(rowIndexer, titleindexer).Value =t.Text;

					var isCompleted = t.IsCompleted;

					ws.Cell(rowIndexer, titleindexer).Style.Fill.BackgroundColor = isCompleted ? XLColor.Green : XLColor.Red;

		
					ws.Cell(rowIndexer, titleindexer + 1).SetDataValidation().List("\"True,False\"");
					ws.Cell(rowIndexer, titleindexer + 1).SetDataValidation().IgnoreBlanks = true;
					ws.Cell(rowIndexer, titleindexer + 1).SetDataValidation().InCellDropdown = true;
					ws.Cell(rowIndexer, titleindexer + 1).Value = isCompleted;

					rowIndexer++;
				}


				titleindexer = titleindexer + 2;
			}
			
			return wb;

		}

	}
}