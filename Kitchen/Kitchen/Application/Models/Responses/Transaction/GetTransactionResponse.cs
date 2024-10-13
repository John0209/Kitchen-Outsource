using Kitchen.Infrastructure.Enum;

namespace Kitchen.Application.Models.Responses.Transaction;

public class GetTransactionResponse
{
    public string? UserName { get; set; }
    public int Id { get; set; }
    public string? TransactionDate { get; set; }
    public string? TransactionCode { get; set; }
    public decimal Price { get; set; }
    public ValidityPeriodType ValidityPeriod { get; set; }
    public int ValidityDays { get; set; }
    public TransactionStatus Status { get; set; }
}