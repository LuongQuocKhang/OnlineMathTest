using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineMathTest.Common;
using OnlineMathTest.Interfaces;
using OnlineMathTest.ViewModel;

namespace OnlineMathTest.Controllers
{
    public class MCQController : Controller
    {
        private readonly IMCQService _mcqService;
        private readonly IUserService _userService;
        private readonly UserManager<IdentityUser> _userManager;
        public MCQController(IMCQService mcqService, IUserService userService, UserManager<IdentityUser> userManager)
        {
            _mcqService = mcqService;
            _userService = userService;
            _userManager = userManager;
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
        [HttpGet]
        public IActionResult GetAllQuestionType()
        {
            ResponseViewModel response = new ResponseViewModel();
            try
            {
                response.success = true;
                response.data = _mcqService.GetAllQuestionType();
            }
            catch (Exception ex)
            {
                response.errMsg = ex.ToString();
            }
            return Json(response);
        } 
        [HttpGet]
        public IActionResult GetExamResultById(int Id)
        {
            ResponseViewModel response = new ResponseViewModel();
            try
            {
                response.success = true;
                response.data = _mcqService.GetExamResultById(Id);
            }
            catch (Exception ex)
            {
                response.errMsg = ex.ToString();
            }
            return Json(response);
        }

        [HttpPost]
        public IActionResult SubmitExam([FromBody]MCQViewModel mcq)
        {
            ResponseViewModel response = new ResponseViewModel();
            try
            {
                var user = _userManager.GetUserAsync(HttpContext.User).Result;
                var _user = _userService.GetUserByUserName(user.UserName);
                response.success = true;
                response.data = _mcqService.SubmitExam(mcq, Int32.Parse(_user.Id));
            }
            catch (Exception ex)
            {
                response.success = false;
                response.errMsg = ex.ToString();
            }
            return Json(response);
        }
    }
}