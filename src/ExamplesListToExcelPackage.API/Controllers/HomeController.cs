using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExamplesListToExcelPackage.API.Infrastructure;
using ExamplesListToExcelPackage.API.Infrastructure.Repositories;
using ExamplesListToExcelPackage.Domain.Models;
using ListToExcelPackage;
using ListToExcelPackage.Services;
using ListToExcelPackage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExamplesListToExcelPackage.API.Controllers
{
    [ApiController]
    [Route("v1")]
    public class HomeController : ControllerBase
    {
        private IOrdersRepository _ordersRepository;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IOrdersRepository ordersRepository)
        {
            _logger = logger;
            _ordersRepository = ordersRepository;
        }

        /// <summary>
        /// This will export list of objects to and return Excel File by using ListToExcelPackage nuget package
        /// Create the Excel file and save it as stream, Returns a Memory Stream
        /// Simple Excel file without any styles added
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Orders")]
        public IActionResult ExportOrdersReport()
        {
            var ordersList = _ordersRepository.GetOrders();
            var fileStream = ListToExcel.CreateFileStream<Order>(ordersList, "My Orders List");
            fileStream.Position = 0;
            return File(fileStream, "application/octet-stream", $"Orders_{DateTime.Now:yyyy-MM-dd}.xlsx");
        }

        /// <summary>
        /// Adding some styles to excel, FontBold, BackgroundColor, ... etc
        /// </summary>
        /// <returns>FileSteamResult</returns>
        [HttpGet]
        [Route("OrdersWithStyle")]
        public IActionResult ExportOrdersReportWithStyle()
        {
            var ordersList = _ordersRepository.GetOrders();
            //Styles separated to dependent method for better understanding
            List<StyleOption> styles = Extensions.GetStyleOptions(ordersList.Count);
            //using ListToExcelPackage
            var fileStream = ListToExcel.CreateFileStream<Order>(ordersList, "My Orders List", styles);
            fileStream.Position = 0;
            //return FileSteamResult
            return File(fileStream, "application/octet-stream", $"Orders_{DateTime.Now:yyyy-MM-dd}.xlsx");
        }

        /// <summary>
        /// Create the Excel file from list of objects and save it to ObjectStorage (here Oracle Cloud Infrastructure), Returns ObjectName
        /// for more information about OCI Object Storage visit: https://docs.cloud.oracle.com/en-us/iaas/Content/Object/Concepts/objectstorageoverview.htm
        /// for creating free cloud account visit: https://www.oracle.com/sa/cloud/free/
        /// NAMESPACE_NAME: axy7edlo4u4z
        /// BUCKET_NAME: bucket-20201015-0005
        /// </summary>
        /// <returns>ObjectName</returns>
        [HttpGet]
        [Route("OrdersOCI")]
        public async Task<IActionResult> ExportOrdersReportOCIAsync()
        {
            var ordersList = _ordersRepository.GetOrders();
            List<StyleOption> styles = Extensions.GetStyleOptions(ordersList.Count);
            //using ListToExcelPackage
            var objectName = await ListToExcel.CreateAndSaveToOCI<Order>(ordersList, "My Orders List", styles);
            //return objectName as string
            return Ok(objectName);
        }

        /// <summary>
        /// Helper action to download the file saved to the ObjectStorage (here Oracle Cloud)
        /// can be used from anywhere.
        /// </summary>
        /// <returns>FileSteamResult</returns>
        [HttpGet]
        [Route("DownloadFile/{objectName}")]
        public async Task<IActionResult> DownloadFileFromOCIAsync(string objectName)
        {
            //using ListToExcelPackage.Services
            var fileStream = await OciObjectStorage.RetrieveObject(objectName);
            fileStream.Position = 0;
            //return FileSteamResult
            return File(fileStream, "application/octet-stream", $"Orders_{DateTime.Now:yyyy-MM-dd}.xlsx");
        }


    }
}
