using Application.ErrorHandlers;
using Kitchen.Application.ErrorHandlers;
using Kitchen.Application.Models.Requests.Momo;
using Kitchen.Application.UnitOfWork;
using Kitchen.Application.Utils;
using Kitchen.Infrastructure.Enum;
using MediatR;

namespace Kitchen.Application.Handler.Transaction;

public class UpdateTransactionHandler : IRequestHandler<MomoResultRequest, Unit>
{
    private readonly IUnitOfWork _unit;

    public UpdateTransactionHandler(IUnitOfWork unit)
    {
        _unit = unit;
    }

    public async Task<Unit> Handle(MomoResultRequest request, CancellationToken cancellationToken)
    {
        var transactionId = StringUtils.GetMomoId(request.orderId);

        var transaction = await _unit.TransactionRepository.GetByIdAsync(transactionId) ??
                          throw new BadRequestException("TransactionId is not found, failed in the MomoResponseHandler");

        var period = (int)transaction.Membership!.ValidityPeriod;
        var expireDate = DateTime.Now.AddDays(period);
        var startDate = DateTime.Now;

        transaction.Status = TransactionStatus.Successful;
        transaction.User!.StartDateMember = startDate;
        transaction.User!.ExpireDateMember = expireDate;
        transaction.User!.TotalDays = (expireDate - startDate).Days;
        transaction.User!.IsMember = true;

        _unit.TransactionRepository.Update(transaction);
        if (await _unit.SaveChangeAsync() < 0) throw new NotImplementException("Update transaction to DB failed");

        return Unit.Value;
    }
}