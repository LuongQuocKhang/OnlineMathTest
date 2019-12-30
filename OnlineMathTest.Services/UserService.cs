using AutoMapper;
using OnlineMathTest.Common;
using OnlineMathTest.Context.IUnitOfWork;
using OnlineMathTest.Interfaces;
using OnlineMathTest.Models.Models;
using OnlineMathTest.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineMathTest.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public bool AddUser(UserViewModel user)
        {
            try
            {
                var _user = _mapper.Map<User>(user);
                _unitOfWork.Repository<User>().Add(_user);

                _user.RoleId = (int)Role.USER;
                _unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception e) { }
            return false;
        }

        public UserReturnViewModel GetUserByUserName(string username)
        {
            var user = _unitOfWork.Repository<User>().FirstOrDefault(x => x.Username == username);
            var role = _unitOfWork.Repository<Model.Role>().FirstOrDefault(x => x.Id == user.RoleId);
            var result = new UserReturnViewModel()
            {
                UserName = user.Username,
                Role = role.RoleName
            };
            return result;
        }
    }
}
