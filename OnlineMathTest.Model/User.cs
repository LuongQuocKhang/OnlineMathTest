using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace OnlineMathTest.Models.Models
{
    public partial class User
    {
        public User()
        {
            UserTest = new HashSet<UserTest>();
        }

        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
        public DateTime? CreateOn { get; set; }
        public bool? IsDeleted { get; set; }
        public int RoleId { get; set; }
        public virtual ICollection<UserTest> UserTest { get; set; }
    }
}
