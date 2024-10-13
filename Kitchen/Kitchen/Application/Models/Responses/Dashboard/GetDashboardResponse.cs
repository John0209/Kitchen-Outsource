using Kitchen.Application.Models.Responses.Transaction;

namespace Kitchen.Application.Models.Responses.Dashboard;

public class GetDashboardResponse
{
    public decimal TotalIncome { get; set; }
    public decimal TotalIncomeToday { get; set; }
    public int TotalUser { get; set; }
    public int TotalUserToday { get; set; }
    public int TotalMemberShip { get; set; }
    public int TotalMemberShipToday { get; set; }
    public int TotalTransaction { get; set; }
    public int TotalTransactionToday { get; set; }
    public List<TransactionDashboardDto> Transactions { get; set; } = new List<TransactionDashboardDto>();
}