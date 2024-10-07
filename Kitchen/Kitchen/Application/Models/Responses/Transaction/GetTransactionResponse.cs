using Kitchen.Infrastructure.Enum;

namespace Kitchen.Application.Models.Responses.Transaction;

public class GetTransactionResponse
{
    public int Id { get; set; }
    public DateTime TransactionDate { get; set; }
    public int TransactionCode { get; set; }
    public decimal Price { get; set; }
    public ValidityPeriodType ValidityPeriod {get; set; }
    public int ValidityDays { get; set; }
}