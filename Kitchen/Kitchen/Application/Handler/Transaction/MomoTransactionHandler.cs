using DataAccess.Enum;
using Kitchen.Application.Models.Requests.Payment;
using Kitchen.Application.UnitOfWork;
using Kitchen.Application.Utils;
using MediatR;

namespace Kitchen.Application.Handler.Transaction;

public class MomoTransactionHandler : IRequestHandler<MomoResultRequest, Unit>
{
    private readonly IUnitOfWork _unit;

    public MomoTransactionHandler(IUnitOfWork unit)
    {
        _unit = unit;
    }

    public async Task<Unit> Handle(MomoResultRequest request, CancellationToken cancellationToken)
    {
        var transactionId = StringUtils.GetMomoId(request.orderId);

        await TransactionHandlerUtils.UpdateTransaction(_unit, transactionId.ToString(), PaymentType.Momo);

        return Unit.Value;
    }
}