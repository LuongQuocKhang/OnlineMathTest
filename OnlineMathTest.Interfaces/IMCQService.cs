using OnlineMathTest.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMathTest.Interfaces
{
    public interface IMCQService
    {
        List<MCQViewModel> GetAllMCQ();
        List<MCQViewModel> GetMCQByLevel(int level);
        List<MCQViewModel> GetMCQByType(string type);
        MCQViewModel GetMCQById(int Id);
        UserTestViewModel GetUsetTest(int Id);
        List<LevelViewModel> GetAllLevel();
        List<QuestionTypeViewModel> GetAllQuestionType();
        bool DeleteMCQ(MCQViewModel mcq);
        bool AddMCQ(MCQViewModel mcq);
        int SubmitExam(MCQViewModel mcq, int userId);
        MCQViewModel GetExamResultById(int id);
        List<MCQViewModel> GetAllMcqByQuestionType(int id);
        List<MCQViewModel> GetAllMcqByLevel(int id);
        List<MCQViewModel> GetAllMCQ(SearchViewModel searchQuery);
    }
}
