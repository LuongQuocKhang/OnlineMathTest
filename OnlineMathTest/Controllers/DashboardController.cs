using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineMathTest.Interfaces;
using OnlineMathTest.ViewModel;

namespace OnlineMathTest.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IStatisticsService _stastisticService;

        public DashboardController(IStatisticsService stastisticService)
        {
            _stastisticService = stastisticService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetAllUserTest(DateTime? startDate , DateTime? endDate)
        {
            ResponseViewModel response = new ResponseViewModel();
            try
            {
                response.data = _stastisticService.GetAllUserTest(startDate, endDate);
                response.success = true;
            }
            catch (Exception e)
            {
                response.success = false;
                response.errMsg = e.ToString();
            }
            return Json(response);
        }
        [HttpGet]
        public IActionResult GetDashboardReport()
        {
            ResponseViewModel response = new ResponseViewModel();
            try
            {
                response.data = _stastisticService.GetDashboardReport();
                response.success = true;
            }
            catch (Exception e)
            {
                response.success = false;
                response.errMsg = e.ToString();
            }
            return Json(response);
        }
    }
}