using OnlineMathTest.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMathTest.Interfaces
{
    public interface IStatisticsService
    {
        StatisticsViewModel getStastistic(int userId);
        List<McqHistoryViewModel> getAllUserHistory();
        McqHistoryViewModel GetMCQHistory(int Id);
        List<UserTestViewModel> GetAllUserTest(int userId);
        DashBoardChartViewModel GetAllUserTest(DateTime? startDate, DateTime? endDate);
        DashboardReportViewModel GetDashboardReport();
    }
}
