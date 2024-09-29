using Application.ErrorHandlers;
using Kitchen.Application.Mapper;
using Kitchen.Application.Models.Requests.Authenticate;
using Kitchen.Application.Models.Responses.Authenticate;
using Kitchen.Application.UnitOfWork;
using MediatR;

namespace Kitchen.Application.Handler.Authentication;

public class ExpertLoginHandler : IRequestHandler<ExpertLoginRequest, string>
{
    private readonly IUnitOfWork _unit;

    public ExpertLoginHandler(IUnitOfWork unit)
    {
        _unit = unit;
    }

    public Task<string> Handle(ExpertLoginRequest request, CancellationToken cancellationToken)
    {
        var expert = _unit.ExpertRepository.CheckLogin(request) ??
                     throw new UnauthorizedException("Account or password is wrong");

        return Task.FromResult(expert.Name);
    }
}