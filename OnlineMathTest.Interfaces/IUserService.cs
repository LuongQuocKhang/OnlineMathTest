using OnlineMathTest.Model;
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
        List<UserReturnViewModel> GetAllUsers();
        UserReturnViewModel GetUserById(string Id);
        List<Role> GetRoles();

        bool UpdateUser(UserReturnViewModel user);
        bool DeleteUser(UserReturnViewModel user);
    }
}
