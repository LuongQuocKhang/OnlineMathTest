using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineMathTest.Interfaces;
using OnlineMathTest.ViewModel;

namespace OnlineMathTest.Controllers
{
    public class StastisticController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IStatisticsService _stastisticService;
        public StastisticController(IStatisticsService stastisticService,IUserService userService, UserManager<IdentityUser> userManager)
        {
            _stastisticService = stastisticService;
            _userService = userService;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetStastistics(string userId)
        {
            ResponseViewModel response = new ResponseViewModel();
            try
            {
                response.success = true;
                var _user = _userManager.FindByIdAsync(userId).Result;
                var user = _userService.GetUserByUserName(_user.UserName);
                response.data = _stastisticService.getStastistic(Int32.Parse(user.Id));
            }
            catch(Exception e)
            {
                response.success = false;
                response.errMsg = e.ToString();
            }
            return Json(response);
        }
        [HttpGet]
        public IActionResult GetAllUserTest(string UserId)
        {
            ResponseViewModel response = new ResponseViewModel();
            try
            {
                var _user = _userManager.FindByIdAsync(UserId).Result;
                var user = _userService.GetUserByUserName(_user.UserName);
                response.data = _stastisticService.GetAllUserTest(Int32.Parse(user.Id));
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