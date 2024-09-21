using Kitchen.Application.Models.Responses.User;
using MediatR;

namespace Kitchen.Application.Models.Requests.User;

public class GetUserDetailRequestDto : IRequest<GetUserDetailResponseDto>
{
    public int UserId { get; set; }
}