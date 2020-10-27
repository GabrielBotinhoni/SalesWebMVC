using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Services;

namespace SalesWebMVC.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly SalesRecordService _salesRecordService;

        public SalesRecordsController(SalesRecordService salesRecordService)
        {
            _salesRecordService = salesRecordService;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public async Task<IActionResult> SimpleSearch(DateTime? min, DateTime? max)
        {
            if(!min.HasValue)
            {
                min = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if(!max.HasValue)
            {
                max = DateTime.Now;
            }

            ViewData["min"] = min.Value.ToString("yyyy-MM-dd");
            ViewData["max"] = max.Value.ToString("yyyy-MM-dd");
            var result = await _salesRecordService.FindByDateAsync(min, max);
            return View(result);
        }

        public IActionResult GroupingSearch()
        {
            return View();
        }
    }
}