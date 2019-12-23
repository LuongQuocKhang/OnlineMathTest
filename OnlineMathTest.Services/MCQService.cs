using AutoMapper;
using OnlineMathTest.Context.IUnitOfWork;
using OnlineMathTest.Interfaces;
using OnlineMathTest.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMathTest.Services
{
    public class MCQService : BaseService, IMCQService
    {
        private readonly IMapper _mapper;
        public MCQService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<LevelViewModel> GetAllLevel()
        {
            throw new NotImplementedException();
        }

        public List<MCQViewModel> GetAllMCQ()
        {
            throw new NotImplementedException();
        }

        public MCQViewModel GetMCQById(int Id)
        {
            throw new NotImplementedException();
        }

        public List<MCQViewModel> GetMCQByLevel(int level)
        {
            throw new NotImplementedException();
        }

        public List<MCQViewModel> GetMCQByType(int type)
        {
            throw new NotImplementedException();
        }

        public MCQVHistoryViewModel GetMCQHistory(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
