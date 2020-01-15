using OnlineMathTest.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMathTest.Interfaces
{
    public interface IQuestionService
    {
        List<QuestionViewModel> GetAllQuestion(DataTableNetPostViewModel model, out int filteredResultsCount, out int totalResultsCount);
        QuestionViewModel GetQuestionById(int Id);

        bool AddQuestion(QuestionViewModel questionvm);
        bool UpdateQuestion(QuestionViewModel questionvm);

        bool DeleteQuestion(QuestionViewModel questionvm);
    }
}
