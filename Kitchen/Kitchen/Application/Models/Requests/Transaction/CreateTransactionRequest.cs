using MediatR;

namespace Kitchen.Application.Models.Requests.Transaction;

public class CreateTransactionRequest : IRequest<Infrastructure.Entities.Transaction>
{
    public int UserId { get; set; }
    public int MembershipId { get; set; }
}