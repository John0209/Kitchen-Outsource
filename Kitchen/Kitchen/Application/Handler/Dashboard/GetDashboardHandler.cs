using Kitchen.Application.Mapper;
using Kitchen.Application.Models.Requests.Dashboard;
using Kitchen.Application.Models.Responses.Dashboard;
using Kitchen.Application.UnitOfWork;
using MediatR;

namespace Kitchen.Application.Handler.Dashboard;

public class GetDashboardHandler : IRequestHandler<EmptyRequest, GetDashboardResponse>
{
    private readonly IUnitOfWork _unit;

    public GetDashboardHandler(IUnitOfWork unit)
    {
        _unit = unit;
    }

    public async Task<GetDashboardResponse> Handle(EmptyRequest request, CancellationToken cancellationToken)
    {
        var transactions = await _unit.TransactionRepository.GetAsync();
        var users = await _unit.UserRepository.GetAsync();

        return DashboardMapper.GetDashboardMapper(users, transactions);
    }
}