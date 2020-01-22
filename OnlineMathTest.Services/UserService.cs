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
                _user.Password = MD5Encryptor.EncryptData(user.Password);
                _unitOfWork.Repository<User>().Add(_user);

                _user.RoleId = (int)Common.Role.USER;
                _unitOfWork.SaveChanges();
                return true;
            }
            catch (Exception e) { }
            return false;
        }

        public List<UserReturnViewModel> GetAllUsers()
        {
            var users = _unitOfWork.Repository<User>().Where(x => !x.IsDeleted.Value);
            var result = _mapper.Map<List<UserReturnViewModel>>(users);
            return result;
        }

        public List<Model.Role> GetRoles()
        {
            return _unitOfWork.Repository<Model.Role>().ToList();
        }

        public UserReturnViewModel GetUserById(string Id)
        {
            var user = _unitOfWork.Repository<User>().FirstOrDefault(x => x.Id.ToString() == Id);
            var uservm = _mapper.Map<UserReturnViewModel>(user);
            return uservm;
        }

        public UserReturnViewModel GetUserByUserName(string username)
        {
            var user = _unitOfWork.Repository<User>().FirstOrDefault(x => x.Username == username);
            var role = _unitOfWork.Repository<Model.Role>().FirstOrDefault(x => x.Id == user.RoleId);
            var result = new UserReturnViewModel()
            {
                Id = user.Id.ToString(),
                UserName = user.Username,
                Role = role.RoleName,
                roleId = role.Id
            };
            _mapper.Map(user, result);
            return result;
        }

        public bool UpdateUser(UserReturnViewModel user)
        {
            var _user = _unitOfWork.Repository<User>().FirstOrDefault(x => x.Id.ToString() == user.Id);
            _mapper.Map(user, _user);
            _unitOfWork.SaveChanges();
            return true;
        } 
        public bool DeleteUser(UserReturnViewModel user)
        {
            var _user = _unitOfWork.Repository<User>().FirstOrDefault(x => x.Id.ToString() == user.Id);
            _user.IsDeleted = true;
            _unitOfWork.SaveChanges();
            return true;
        }

        public List<UserTestViewModel> GetAllUserTest(int userId)
        {
            var userTest = _unitOfWork.Repository<UserTest>().Where(x => x.UserId == userId);
            var result = _mapper.Map<List<UserTestViewModel>>(userTest);
            return result;
        }
    }
}
