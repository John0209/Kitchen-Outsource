using Kitchen.Application.Models.Responses.Transaction;
using Kitchen.Infrastructure.Enum;

namespace Kitchen.Application.Models.Responses.Dashboard;

public class TransactionDashboardDto
{
    public TransactionStatus TransactionStatus { get; set; }
    public int TotalTransactionByStatus { get; set; }
    public List<GetTransactionResponse> Transactions { get; set; } = new List<GetTransactionResponse>();
}