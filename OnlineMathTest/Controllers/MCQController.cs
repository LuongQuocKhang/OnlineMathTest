using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineMathTest.Common;
using OnlineMathTest.Interfaces;
using OnlineMathTest.ViewModel;

namespace OnlineMathTest.Controllers
{
    public class MCQController : Controller
    {
        private readonly IMCQService _mcqService;
        public MCQController(IMCQService mcqService)
        {
            _mcqService = mcqService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetMCQs()
        {
            ResponseViewModel response = new ResponseViewModel();
            try
            {
                response.success = true;
                response.data = _mcqService.GetAllMCQ(EnumSettings.DefaultPageSize,EnumSettings.DefaultPageLength);
            }
            catch (Exception ex)
            {
                response.errMsg = ex.ToString();
            }
            return Json(response);
        }
        [HttpGet]
        public IActionResult GetMCQById(int Id)
        {
            ResponseViewModel response = new ResponseViewModel();
            try
            {
                response.success = true;
                response.data = _mcqService.GetMCQById(Id);
            }
            catch (Exception ex)
            {
                response.errMsg = ex.ToString();
            }
            return Json(response);
        }
    }
}