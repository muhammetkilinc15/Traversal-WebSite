using DataAccessLayer.Concreate;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Vml;
using EntityLayer.Concreate;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Paragraph = iTextSharp.text.Paragraph;
using Path = System.IO.Path;

namespace TraversalWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PdfReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<Destination> DestinationList()
        {
            using (var c = new Context())
            {
                return c.Destinations.ToList();
            }
        }

        public IActionResult PdfReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PdfReport/" + "dosya3.pdf");
            var stream = new FileStream(path, FileMode.Create);
            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);


            document.Open();

            PdfPTable table = new PdfPTable(4);
            table.AddCell("Sehir");
            table.AddCell("Süre");
            table.AddCell("Kapasite");
            table.AddCell("Fiyat");

            var values = DestinationList();
            for (int i = 0; i < values.Count; i++)
            {
                table.AddCell(values[i].City);
                table.AddCell(values[i].DayNight);
                table.AddCell(values[i].Capacity.ToString());
                table.AddCell(   values[i].Price.ToString());
            }

            document.Add(table);

            document.Close();

            return File("/PdfReport/dosya3.pdf", "application/pdf", "Dosya3.pdf");
        }
    }
}
