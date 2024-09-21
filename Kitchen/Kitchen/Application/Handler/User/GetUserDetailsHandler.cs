using Application.ErrorHandlers;
using Kitchen.Application.Mapper;
using Kitchen.Application.Models.Requests.User;
using Kitchen.Application.Models.Responses.User;
using Kitchen.Application.UnitOfWork;
using MediatR;

namespace Kitchen.Application.Handler.User;

public class GetUserDetailsHandler : IRequestHandler<GetUserDetailRequestDto, GetUserDetailResponseDto>
{
    private readonly IUnitOfWork _unit;

    public GetUserDetailsHandler(IUnitOfWork unit)
    {
        _unit = unit;
    }

    public async Task<GetUserDetailResponseDto> Handle(GetUserDetailRequestDto request, CancellationToken cancellationToken)
    {
        var user = await _unit.UserRepository.GetByIdAsync(request.UserId) ?? throw new NotFoundException("User information not found");

        return UserMapper.UserToUserDetailResponseDto(user);
    }
}