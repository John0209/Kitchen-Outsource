using Kitchen.Application.Models.Responses.User;
using MediatR;

namespace Kitchen.Application.Models.Requests.User;

public class GetUserDetailRequest : IRequest<GetUserDetailResponse>
{
    public int UserId { get; set; }
}