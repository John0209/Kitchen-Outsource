using MediatR;

namespace Kitchen.Application.Models.Requests.Transaction;

public class CreateTransactionRequest : IRequest<int>
{
    public int UserId { get; set; }
    public int MembershipId { get; set; }
}