using BusinessLayer.Abstract;
using ClosedXML.Excel;
using DataAccessLayer.Concreate;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace TraversalWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExcelController : Controller
    {
        private readonly IDestinationService destinationService;
        private readonly IExcelService excelService;

        public ExcelController(IDestinationService destinationService, IExcelService excelService)
        {
            this.destinationService = destinationService;
            this.excelService = excelService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public IActionResult GetFile()

        {
            return File(excelService.Excellist(DestinationList()), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "YeniExcel.xlsx");
        }

        public List<Destination> DestinationList()
        {
            List<Destination> list = new List<Destination>();

            using (var c = new Context())
            {
                list = c.Destinations.ToList();
                return list;
            }
        }

        public IActionResult DestinationExcelReport()
        {
            using (var workbook = new XLWorkbook())
            {
                var workSheet = workbook.Worksheets.Add("Tur Listesi");
                workSheet.Cell(1, 1).Value = "Şehir";
                workSheet.Cell(1, 2).Value = "Konaklama Süresi";
                workSheet.Cell(1, 3).Value = "Fiyat";
                workSheet.Cell(1, 4).Value = "Kapasite";

                int rowCount = 2;
                var values = DestinationList();
                for (int i = 0; i < values.Count; i++)
                {
                    workSheet.Cell(rowCount, 1).Value = values[i].City;
                    workSheet.Cell(rowCount, 2).Value = values[i].DayNight;
                    workSheet.Cell(rowCount, 3).Value = values[i].Price;
                    workSheet.Cell(rowCount, 4).Value = values[i].Capacity;
                    rowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Tur Listesi.xlsx");
                }
            }
        }
    }
}
