﻿using AutoMapper;
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

        public bool AddMCQ(MCQViewModel mcq)
        {
            if (mcq == null) return false;
            var _mcq = new Mcq();
            _mapper.Map(mcq, _mcq);
            _mcq.CreateOn = DateTime.Now;
            _mcq.IsDeleted = false;
            _unitOfWork.Repository<Mcq>().Add(_mcq);
            _unitOfWork.SaveChanges();
            foreach (var item in mcq.Questions)
            {
                var mcqquestion = new Mcqquestion()
                {
                    McqquestionId = _mcq.Id,
                    QuestionId = item.Id
                };
                _unitOfWork.Repository<Mcqquestion>().Add(mcqquestion);
            }
            _unitOfWork.SaveChanges();
            return true;
        }

        public bool DeleteMCQ(MCQViewModel mcq)
        {
            var _mcq = _unitOfWork.Repository<Mcq>().FirstOrDefault(x => x.Id == mcq.Id);
            _mcq.IsDeleted = true;
            var _mcqQuestion = _unitOfWork.Repository<Mcqquestion>().Where(x => x.McqquestionId == _mcq.Id);
            _unitOfWork.Repository<Mcqquestion>().RemoveRange(_mcqQuestion);
            _unitOfWork.SaveChanges();
            return true;
        }

        public List<LevelViewModel> GetAllLevel()
        {
            var level = _unitOfWork.Repository<Level>();
            var result = _mapper.Map<List<LevelViewModel>>(level.ToList());
            return result;
        }

        public List<MCQViewModel> GetAllMCQ()
        {
            var mcq = _unitOfWork.Repository<Mcq>().Where(x => !x.IsDeleted.Value)
                .OrderBy(x => x.CreateOn);
            var mcqvm = _mapper.Map<List<MCQViewModel>>(mcq.ToList());
            return mcqvm;
        }
        public List<MCQViewModel> GetAllMCQ(SearchViewModel searchQuery)
        {
            var mcq = _unitOfWork.Repository<Mcq>().Where(x => !x.IsDeleted.Value 
            && RemoveUnicode.RemoveSign4VietnameseString(x.Title).ToLower().Contains(RemoveUnicode.RemoveSign4VietnameseString(searchQuery.Key).ToLower()))
                .OrderBy(x => x.CreateOn);
            var mcqvm = _mapper.Map<List<MCQViewModel>>(mcq.ToList());
            return mcqvm;
        }

        public List<MCQViewModel> GetAllMcqByQuestionType(int id)
        {
            var questions = _unitOfWork.Repository<Question>().Where(x => x.QuestionType.Value == id);
            var mcqQuestion = _unitOfWork.Repository<Mcqquestion>().Where(x => questions.Select(t => t.Id).Contains(x.QuestionId)).Select(t => t.McqquestionId);
            var mcq = _unitOfWork.Repository<Mcq>().Where(x => mcqQuestion.Contains(x.Id));
            var result = _mapper.Map<List<MCQViewModel>>(mcq);
            return result;
        }
        public List<MCQViewModel> GetAllMcqByLevel(int id)
        {
            var mcq = _unitOfWork.Repository<Mcq>().Where(x => x.LevelType == id);
            var result = _mapper.Map<List<MCQViewModel>>(mcq);
            return result;
        }
        public List<QuestionTypeViewModel> GetAllQuestionType()
        {
            var questiontype = _unitOfWork.Repository<QuestionType>().ToList();
            var result = _mapper.Map<List<QuestionTypeViewModel>>(questiontype);
            return result;
        }

        public MCQViewModel GetExamResultById(int id)
        {
            var userTest = _unitOfWork.Repository<UserTest>().FirstOrDefault(x => x.Id == id);
            var _mcqhistory = _unitOfWork.Repository<Mcqhistory>().Where(x => x.UserTestId == id);

            var mcq = _unitOfWork.Repository<Mcq>().FirstOrDefault(x => x.Id == userTest.Mcqid);
            var mvqvm = _mapper.Map<MCQViewModel>(mcq);
            var mcqquestions = _unitOfWork.Repository<Mcqquestion>().Where(x => x.McqquestionId == mcq.Id);
            var questions = _unitOfWork.Repository<Question>().Where(x => mcqquestions.Select(t => t.QuestionId).Contains(x.Id));
            var questionsvm = _mapper.Map<List<QuestionViewModel>>(questions.ToList());
            foreach (var question in questionsvm)
            {
                question.Answers = new List<QuestionAnswerViewModel>();

                var answers = _unitOfWork.Repository<QuestionAnswer>().Where(x => x.QuestionId == question.Id);
                var answervm = _mapper.Map<List<QuestionAnswerViewModel>>(answers.ToList());
                var selectedAnswer = _mcqhistory.FirstOrDefault(x => x.QuestionId == question.Id);
                if (selectedAnswer != null)
                {
                    var answer = answers.FirstOrDefault(x => x.Id == selectedAnswer.QuestionAnswerId);
                    question.SelectedValue = answer.DisplayNumber.Value;
                }
                else
                {
                    question.SelectedValue = 0;
                }

                question.Answers.AddRange(answervm);
            }
            mvqvm.Questions = questionsvm;
            return mvqvm;
        }

        public MCQViewModel GetMCQById(int Id)
        {
            var mcq = _unitOfWork.Repository<Mcq>().FirstOrDefault(x => x.Id == Id && !x.IsDeleted.Value);
            mcq.Views += 1;
            _unitOfWork.SaveChanges();

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

        public List<MCQViewModel> GetMCQByType(string type)
        {
            var mcqs = _unitOfWork.Repository<Mcq>().Where(x => x.Type == type);
            var result = _mapper.Map<List<MCQViewModel>>(mcqs);
            return result;
        }

        public UserTestViewModel GetUsetTest(int Id)
        {
            var usertest = _unitOfWork.Repository<UserTest>().FirstOrDefault(x => x.Id == Id);
            var result = _mapper.Map<UserTestViewModel>(usertest);
            return result;
        }

        public int SubmitExam(MCQViewModel mcq,int userId)
        {
            double point = 0.0;
            var mcqTest = new UserTest()
            {
                Mcqid = mcq.Id,
                UserId = userId,
                Point = point,
                CreateOn = DateTime.Now
            };
            
            _unitOfWork.Repository<UserTest>().Add(mcqTest);
            _unitOfWork.SaveChanges();
            var _mcq = _unitOfWork.Repository<Mcq>().FirstOrDefault(x => x.Id == mcq.Id);
            _mcq.Attempts += 1;
            foreach (var question in mcq.Questions)
            {
                var mcqhistory = new Mcqhistory()
                {
                    Mcqid = mcq.Id,
                    UserTestId = mcqTest.Id,
                    CreateOn = DateTime.Now,
                    QuestionId = question.Id
                };
                var answer = question.Answers.FirstOrDefault(x => x.DisplayNumber.Value == question.SelectedValue);
                if ( answer != null)
                {
                    mcqhistory.QuestionAnswerId = answer.Id;
                    if (question.SelectedValue == question.CorrectAnswer)
                    {
                        point += question.Point.Value;
                    }
                    _unitOfWork.Repository<Mcqhistory>().Add(mcqhistory);
                }
            }     
            mcqTest.Point = point;
            _unitOfWork.SaveChanges();
            return mcqTest.Id;
        }
    }
}
