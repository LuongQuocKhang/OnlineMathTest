using OnlineMathTest.Context.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMathTest.Services
{
    public class BaseService
    {
        protected IUnitOfWork _unitOfWork;
        public BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
