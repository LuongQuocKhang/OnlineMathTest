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
   
    [Route("adminpage")]
    public class AdminManagementController : Controller
    {
        private readonly IMCQService _mcqService;
        private readonly IQuestionService _questionService;
        private readonly IUserService _userService;
        public AdminManagementController(IMCQService mcqService, IQuestionService questionService, IUserService userService)
        {
            _mcqService = mcqService;
            _questionService = questionService;
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }

        // mcq
        [HttpGet]
        [Route("/adminpage/mcq/getAllMCQ")]
        public IActionResult GetAllMCQ()
        {
            ResponseViewModel response = new ResponseViewModel();
            try
            {
                response.success = true;
                response.data = _mcqService.GetAllMCQ();
            }
            catch (Exception e)
            {
                response.errMsg = e.ToString();
            }
            return Json(response);
        }
        [HttpPost]
        [Route("/adminpage/mcq/add")]
        public IActionResult AddMCQ([FromBody]MCQViewModel mcq)
        {
            ResponseViewModel response = new ResponseViewModel();
            try
            {

            }
            catch (Exception e)
            {
                response.errMsg = e.ToString();
            }
            return Json(response);
        }
        // mcq question
        [HttpPost]
        [Route("/adminpage/mcqquestion")]
        public IActionResult MCQquestion(DataTableNetPostViewModel model)
        {
            DataTableResultNetViewModel response = new DataTableResultNetViewModel();
            int filteredResultsCount = 0;
            int totalResultsCount = 0;

            var items = _questionService.GetAllQuestion(model, out filteredResultsCount , out totalResultsCount);
            response.data = items;
            response.recordsFiltered = filteredResultsCount;
            response.recordsTotal = totalResultsCount;

            return Json(response);
        }

        [HttpGet]
        [Route("/adminpage/mcqquestion/getAllQuestionType")]
        public IActionResult GetAllQuestionType()
        {
            ResponseViewModel response = new ResponseViewModel();
            try
            {
                response.success = true;
                response.data = _mcqService.GetAllQuestionType();
            }
            catch (Exception e)
            {
                response.errMsg = e.ToString();
            }
            return Json(response);
        } 
        [HttpGet]
        [Route("/adminpage/mcqquestion/GetQuestionById")]
        public IActionResult GetQuestionById(int questionId)
        {
            ResponseViewModel response = new ResponseViewModel();
            try
            {
                response.success = true;
                response.data = _questionService.GetQuestionById(questionId);
            }
            catch (Exception e)
            {
                response.errMsg = e.ToString();
            }
            return Json(response);
        }

        [HttpGet]
        [Route("/adminpage/mcqquestion/getAllLevel")]
        public IActionResult GetAllLevel()
        {
            ResponseViewModel response = new ResponseViewModel();
            try
            {
                response.success = true;
                response.data = _mcqService.GetAllLevel();
            }
            catch (Exception e)
            {
                response.errMsg = e.ToString();
            }
            return Json(response);
        }

        [HttpPost]
        [Route("/adminpage/mcqquestion/addQuestion")]
        public IActionResult AddQuestion([FromBody] QuestionViewModel model)
        {
            ResponseViewModel response = new ResponseViewModel();
            try
            {
                response.success = _questionService.AddQuestion(model);
            }
            catch (Exception e) {
                response.errMsg = e.ToString();
            }
            return Json(response);
        } 
        [HttpPost]
        [Route("/adminpage/mcqquestion/updateQuestion")]
        public IActionResult UpdateQuestion([FromBody] QuestionViewModel model)
        {
            ResponseViewModel response = new ResponseViewModel();
            try
            {
                response.success = _questionService.UpdateQuestion(model);
            }
            catch (Exception e) {
                response.errMsg = e.ToString();
            }
            return Json(response);
        }
        [HttpPost]
        [Route("/adminpage/mcqquestion/deleteQuestion")]
        public IActionResult DeleteQuestion([FromBody] QuestionViewModel model)
        {
            ResponseViewModel response = new ResponseViewModel();
            try
            {
                response.success = _questionService.DeleteQuestion(model);
            }
            catch (Exception e)
            {
                response.errMsg = e.ToString();
            }
            return Json(response);
        }
        [Route("/adminpage/usermanagement/getAllUsers")]
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            ResponseViewModel response = new ResponseViewModel();
            try
            {
                response.success = true;
                response.data = _userService.GetAllUsers();
            }
            catch (Exception e)
            {
                response.errMsg = e.ToString();
            }
            return Json(response);
        }
    }
}