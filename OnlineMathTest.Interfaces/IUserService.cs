using OnlineMathTest.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMathTest.Interfaces
{
    public interface IUserService
    {
        bool AddUser(UserViewModel user);
        UserReturnViewModel GetUserByUserName(string username);
    }
}
