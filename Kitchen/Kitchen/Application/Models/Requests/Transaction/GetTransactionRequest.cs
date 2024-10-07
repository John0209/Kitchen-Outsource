using Kitchen.Application.Models.Responses.Transaction;
using MediatR;

namespace Kitchen.Application.Models.Requests.Transaction;

public class GetTransactionRequest:IRequest<GetTransactionResponse>
{
    public int UserId { get; set; }
}