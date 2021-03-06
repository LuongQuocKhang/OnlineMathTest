﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineMathTest.Interfaces;
using OnlineMathTest.ViewModel;

namespace OnlineMathTest.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserManager<IdentityUser> _userManager;
        public UserController(IUserService userService, UserManager<IdentityUser> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetUserProfileById(string Id)
        {
            ResponseViewModel response = new ResponseViewModel();
            try
            {
                response.success = true;
                var _user = _userManager.FindByIdAsync(Id).Result;
                response.data = _userService.GetUserByUserName(_user.UserName);
            }
            catch (Exception e) 
            {
                response.success = false;
                response.errMsg = e.ToString();
            }

            return Json(response);
        }
        [HttpGet]
        public IActionResult GetRoles()
        {
            ResponseViewModel response = new ResponseViewModel();
            try
            {
                response.success = true;
                response.data = _userService.GetRoles();
            }
            catch (Exception e)
            {
                response.success = false;
                response.errMsg = e.ToString();
            }
            return Json(response);
        }

        [HttpPost]
        public IActionResult UpdateUser([FromBody]UserReturnViewModel user)
        {
            ResponseViewModel response = new ResponseViewModel();
            try
            {
                var _user = _userManager.FindByNameAsync(user.UserName).Result;
                _user.Email = user.Email;
                _user.NormalizedEmail = user.Email.ToUpper();
                _userManager.UpdateAsync(_user);
                response.success = _userService.UpdateUser(user);
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