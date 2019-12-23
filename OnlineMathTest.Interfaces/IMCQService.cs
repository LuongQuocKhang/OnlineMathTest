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
        List<MCQViewModel> GetMCQByType(int type);
        MCQViewModel GetMCQById(int Id);
        MCQVHistoryViewModel GetMCQHistory(int Id);
        List<LevelViewModel> GetAllLevel();
    }
}
