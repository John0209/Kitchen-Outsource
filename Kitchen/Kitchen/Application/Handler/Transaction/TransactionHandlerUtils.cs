using System.Globalization;
using Application.ErrorHandlers;
using DataAccess.Enum;
using Kitchen.Application.ErrorHandlers;
using Kitchen.Application.UnitOfWork;
using Kitchen.Application.Utils;
using Kitchen.Infrastructure.Enum;

namespace Kitchen.Application.Handler.Transaction;

public static class TransactionHandlerUtils
{
    public static async Task UpdateTransaction(IUnitOfWork unit, string identity, PaymentType type)
    {
        Infrastructure.Entities.Transaction? transaction = new Infrastructure.Entities.Transaction();
        string error = "";
        switch (type)
        {
            case PaymentType.Momo:
                transaction = await unit.TransactionRepository.GetByIdAsync(Int16.Parse(identity)) ??
                              throw new BadRequestException(
                                  "TransactionId is not found, failed in the MomoResponseHandler");
                break;
            case PaymentType.Cake:
                transaction = await unit.TransactionRepository.GetTransactionByCode(identity);
                if (transaction == null)
                {
                    error = $"TransactionCode {identity} is not found, failed in the UpdateTransaction";
                    LogUtils.LogWarning("UpdateTransaction", error, "BadRequestException");
                    throw new BadRequestException(error);
                }

                break;
        }

        var period = (int)transaction.Membership!.ValidityPeriod;
        var expireDate = DateTime.Now.AddDays(period);
        var startDate = DateTime.Now;

        transaction.Status = TransactionStatus.Successful;
        if (String.IsNullOrEmpty(transaction.User?.StartDateMember.ToString()))
        {
            transaction.User!.StartDateMember = startDate;
        }

        if (String.IsNullOrEmpty(transaction.User?.ExpireDateMember.ToString()))
        {
            transaction.User!.ExpireDateMember = expireDate;
        }
        else
        {
            
            transaction.User!.ExpireDateMember = transaction.User!.ExpireDateMember.Value.AddDays(period);
        }

        transaction.User.TotalDays += (expireDate - startDate).Days;
        transaction.User.IsMember = true;

        unit.TransactionRepository.Update(transaction);
        if (await unit.SaveChangeAsync() < 0)
        {
            error = "Update transaction to DB failed";
            LogUtils.LogWarning("UpdateTransaction", error, "NotImplemented");
            throw new NotImplementException("Update transaction to DB failed");
        }
    }
}