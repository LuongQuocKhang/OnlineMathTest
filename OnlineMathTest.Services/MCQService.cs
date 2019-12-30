using AutoMapper;
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

        public List<MCQViewModel> GetAllMCQ(int pageLength = 0, int pageSize = 6)
        {
            var mcq = _unitOfWork.Repository<Mcq>().OrderBy(x => x.CreateOn).Skip(pageLength).Take(pageSize);
            var mcqvm = _mapper.Map<List<MCQViewModel>>(mcq.ToList());
            return mcqvm;
        }

        public MCQViewModel GetMCQById(int Id)
        {
            var mcq = _unitOfWork.Repository<Mcq>().FirstOrDefault(x => x.Id == Id);
            var mvqvm = _mapper.Map<MCQViewModel>(mcq);
            var mcqquestions = _unitOfWork.Repository<Mcqquestion>().Where(x => x.McqquestionId == mcq.Id);
            var questions = _unitOfWork.Repository<Question>().Where(x => mcqquestions.Select(t => t.QuestionId).Contains(x.Id));
            var questionsvm = _mapper.Map<List<QuestionViewModel>>(questions.ToList());
            foreach (var question in questionsvm)
            {
                question.Answers = new List<QuestionAnswerViewModel>();
                var answers = _unitOfWork.Repository<QuestionAnswer>().Where(x => x.QuestionId == question.Id);
                var answervm = _mapper.Map<List<QuestionAnswerViewModel>>(answers.ToList());
                question.Answers.AddRange(answervm);
            }
            mvqvm.Questions = questionsvm;
            return mvqvm;
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
