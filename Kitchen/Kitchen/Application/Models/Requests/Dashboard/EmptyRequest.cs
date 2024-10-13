using Kitchen.Application.Models.Responses.Dashboard;
using MediatR;

namespace Kitchen.Application.Models.Requests.Dashboard;

public class EmptyRequest : IRequest<GetDashboardResponse>
{
}