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
    public class StatisticsService : BaseService, IStatisticsService
    {
        private readonly IMapper _mapper;
        public StatisticsService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public StatisticsViewModel getStastistic(int userId)
        {
            var result = new StatisticsViewModel();
            result.ChartCorrectAnswer = new List<int>();
            result.ChartWrongAnswer = new List<int>();
            result.Type = new List<string>();

            var userTest = _unitOfWork.Repository<UserTest>().Where(x => x.UserId == userId);
            var userMcqHistory = _unitOfWork.Repository<Mcqhistory>().Where(x => userTest.Select(t => t.Id).Contains(x.UserTestId));
            var questionType = _unitOfWork.Repository<QuestionType>();

            foreach (var item in questionType)
            {
                // số câu đúng
                var Answer = from history in userMcqHistory
                             join question in _unitOfWork.Repository<Question>()
                             on history.QuestionId equals question.Id
                             join answer in _unitOfWork.Repository<QuestionAnswer>()
                             on history.QuestionAnswerId equals answer.Id
                             where question.QuestionType.Value == item.Id
                             select new
                             {
                                 Answer = answer.DisplayNumber.Value.ToString(),
                                 Correct = question.CorrectAnswer,
                                 QuestionAnswerId = answer.Id,
                             };

                var sum = Answer.Count();
                var sumCorrectAnswer = Answer.Where(x => x.Answer == x.Correct).Count();
                var sumWrongAnswer = sum - sumCorrectAnswer;

                result.ChartCorrectAnswer.Add(sumCorrectAnswer);
                result.ChartWrongAnswer.Add(sumWrongAnswer);
                result.Type.Add(item.QuestionType1);
            }
            return result;
        }

        public McqHistoryViewModel GetMCQHistory(int Id)
        {
            throw new NotImplementedException();
        }

        public List<McqHistoryViewModel> getAllUserHistory()
        {
            throw new NotImplementedException();
        }
        public List<UserTestViewModel> GetAllUserTest(int userId)
        {
            var userTest = _unitOfWork.Repository<UserTest>().Where(x => x.UserId == userId);
            var result = _mapper.Map<List<UserTestViewModel>>(userTest);
            foreach (var item in result)
            {
                var mcq = _unitOfWork.Repository<Mcq>().FirstOrDefault(x => x.Id == item.Mcqid);
                item.McqTitle = mcq.Title;
            }
            return result;
        }

        public DashBoardChartViewModel GetAllUserTest(DateTime? startDate, DateTime? endDate)
        {
            var result = new DashBoardChartViewModel();
            var userTest = _unitOfWork.Repository<UserTest>()
                                    .Where(t => startDate == null || t.CreateOn.Value.Date >= startDate)
                                    .Where(t => endDate == null || t.CreateOn.Value.Date <= endDate);
            result.Dates = userTest.Select(x => x.CreateOn.Value.ToString("dd/MM/yyyy")).Distinct().ToList();

            foreach (var date in result.Dates)
            {
                var userTestByDate = userTest.Where(x => x.CreateOn.Value.Date.ToString("dd/MM/yyyy") == date);
                result.Attemps.Add(userTestByDate.Count());
            }

            return result;
        }

        public DashboardReportViewModel GetDashboardReport()
        {
            var result = new DashboardReportViewModel();
            var mcqs = _unitOfWork.Repository<Mcq>().Where(x => !x.IsDeleted.Value);
            result.Mcqs = mcqs.Count();
            var users = _unitOfWork.Repository<User>().Where(x => !x.IsDeleted.Value);
            result.Users = users.Count();
            var attemps = _unitOfWork.Repository<UserTest>();
            result.Attemps = attemps.Count();
            var avarage = attemps.Select(x => x.Point);
            result.AveragePoint = (string.Format("{0:0.00}", avarage.Sum(x => x.Value) / avarage.Count()).ToString());
            return result;
        }
    }
}
