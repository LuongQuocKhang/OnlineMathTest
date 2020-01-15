using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMathTest.ViewModel
{
    public class UserViewModel : IdentityUser
    {
        public string role { get; set; }
        public int RoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string comfirmPassword { get; set; }
        public string Type { get; set; }
        public DateTime? CreateOn { get; set; }
        public bool? IsDeleted { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }
}
