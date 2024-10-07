using Application.ErrorHandlers;
using Kitchen.Application.Models.Requests.Transaction;
using Kitchen.Application.UnitOfWork;
using Kitchen.Application.Utils;
using Kitchen.Infrastructure.Enum;
using MediatR;

namespace Kitchen.Application.Handler.Transaction;

public class CreateTransactionHandler : IRequestHandler<CreateTransactionRequest, int>
{
    private readonly IUnitOfWork _unit;

    public CreateTransactionHandler(IUnitOfWork unit)
    {
        _unit = unit;
    }

    public async Task<int> Handle(CreateTransactionRequest request, CancellationToken cancellationToken)
    {
        var transaction = new Infrastructure.Entities.Transaction()
        {
            MembershipId = request.MembershipId,
            UserId = request.UserId,
            TransactionDate = DateTime.Now,
            TransactionCode = StringUtils.GenerateRandomNumber(8),
            Status = TransactionStatus.Processing
        };

        await _unit.TransactionRepository.AddAsync(transaction);
        if (await _unit.SaveChangeAsync() < 0) throw new NotImplementException("Add new transaction to DB failed");

        return transaction.Id;
    }
}