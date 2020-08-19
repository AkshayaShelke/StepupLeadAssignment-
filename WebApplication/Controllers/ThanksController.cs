using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;

using System.IO;
using WebApplication.Models;
using Syncfusion.Pdf.Grid;
using System.Data;

namespace WebApplication.Controllers
{
    public class ThanksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PdfDownload()
        {
            PdfDocument document = new PdfDocument();
            PdfPage page = document.Pages.Add();
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
            HomeModel home = TempData["UserDetails"] as HomeModel;
            PdfGrid pdfGrid = new PdfGrid();

            //Create a DataTable
            DataTable dataTable = new DataTable();

            //Add columns to the DataTable
            dataTable.Columns.Add("FirstName");
            dataTable.Columns.Add("LastName");
            dataTable.Columns.Add("Email");
            dataTable.Columns.Add("CompanyName");
            dataTable.Columns.Add("CompanySize");
            dataTable.Columns.Add("JobRole");
            dataTable.Columns.Add("JobDepartment");
            dataTable.Columns.Add("Phone");
            dataTable.Columns.Add("Country");

            //Add rows to the DataTable
            dataTable.Rows.Add(new object[] { "E01", home.FirstName });
            dataTable.Rows.Add(new object[] { "E02", home.LastName });
            dataTable.Rows.Add(new object[] { "E03", home.Email });
            dataTable.Rows.Add(new object[] { "E04", home.CompanyName });
            dataTable.Rows.Add(new object[] { "E05", home.CompanySize });
            dataTable.Rows.Add(new object[] { "E06", home.JobRole });
            dataTable.Rows.Add(new object[] { "E07", home.JobDepartment });
            dataTable.Rows.Add(new object[] { "E08", home.Phone });
            dataTable.Rows.Add(new object[] { "E09", home.Country });

            pdfGrid.DataSource = dataTable;

            pdfGrid.Draw(page, new PointF(10, 10));

            MemoryStream stream = new MemoryStream();
            document.Save(stream);
            stream.Position = 0;
            FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");
            fileStreamResult.FileDownloadName = "Sample.pdf";

            return fileStreamResult;
        }
    }
}
