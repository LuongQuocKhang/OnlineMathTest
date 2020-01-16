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
    public class QuestionService : BaseService, IQuestionService
    {
        private readonly IMapper _mapper;
        public QuestionService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public bool AddQuestion(QuestionViewModel questionvm)
        {
            try
            {
                var question = _mapper.Map<Question>(questionvm);
                _unitOfWork.Repository<Question>().Add(question);
                _unitOfWork.SaveChanges();
                foreach (var answervm in questionvm.Answers)
                {
                    var answer = _mapper.Map<QuestionAnswer>(answervm);
                    answer.QuestionId = question.Id;
                    _unitOfWork.Repository<QuestionAnswer>().Add(answer);
                }
                _unitOfWork.SaveChanges();
                return true;
            }
            catch(Exception e) { throw e; }
        }

        public bool DeleteQuestion(QuestionViewModel questionvm)
        {
            var question = _unitOfWork.Repository<Question>().FirstOrDefault(x => x.Id == questionvm.Id);
            question.IsDeleted = true;
            _unitOfWork.SaveChanges();
            return true;
        }

        public List<QuestionViewModel> GetAllQuestion(DataTableNetPostViewModel model, out int filteredResultsCount, out int totalResultsCount)
        {
            var questions = _unitOfWork.Repository<Question>().Where(x => !x.IsDeleted.Value).ToList();
            var result = _mapper.Map<List<QuestionViewModel>>(questions);
            filteredResultsCount = result.Count;
            totalResultsCount = filteredResultsCount;
            return result.Skip(model.start).Take(model.length).ToList();
        }

        public List<QuestionViewModel> GetAllQuestion()
        {
            var questions = _unitOfWork.Repository<Question>().Where(x => !x.IsDeleted.Value).ToList();
            var result = _mapper.Map<List<QuestionViewModel>>(questions);
            foreach (var questionvm in result)
            {
                var answer = _unitOfWork.Repository<QuestionAnswer>().Where(x => x.QuestionId == questionvm.Id).ToList();
                var answervm = _mapper.Map<List<QuestionAnswerViewModel>>(answer);
                questionvm.Answers = answervm;
            }
            return result;
        }

        public QuestionViewModel GetQuestionById(int Id)
        {
            var question = _unitOfWork.Repository<Question>().FirstOrDefault(x => x.Id == Id);
            var questionvm = _mapper.Map<QuestionViewModel>(question);
            var answer = _unitOfWork.Repository<QuestionAnswer>().Where(x => x.QuestionId == Id);
            var answervm = _mapper.Map<List<QuestionAnswerViewModel>>(answer);
            questionvm.Answers = answervm;
            return questionvm;
        }

        public bool UpdateQuestion(QuestionViewModel questionvm)
        {
            try
            {
                var question = _unitOfWork.Repository<Question>().FirstOrDefault(x => x.Id == questionvm.Id);
                _mapper.Map(questionvm, question);
                _unitOfWork.Repository<Question>().Update(question);
                foreach (var answervm in questionvm.Answers)
                {
                    var answer = _unitOfWork.Repository<QuestionAnswer>().FirstOrDefault(x => x.Id == answervm.Id);
                    _mapper.Map(answervm, answer);
                    _unitOfWork.Repository<QuestionAnswer>().Update(answer);
                }
                _unitOfWork.SaveChanges();
                return true;
            }
            catch(Exception e) { throw e; }
        }
    }
}
