using Application.ErrorHandlers;
using DataAccess.Enum;
using Kitchen.Application.ErrorHandlers;
using Kitchen.Application.UnitOfWork;
using Kitchen.Application.Utils;

namespace Kitchen.Application.Handler.Transaction;

public class CakeTransactionHandler
{
    private readonly IServiceScopeFactory _scopeFactory;

    public CakeTransactionHandler(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public async Task CheckCakeEmail()
    {
        if (EmailUtils.IsReadMail)
        {
            try
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    var unit = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                    var transaction = await unit.TransactionRepository.GetLastTransaction() ??
                                      throw new NotFoundException("Database has not the last transaction");

                    var code = await EmailUtils.ReadEmailAsync(transaction.TransactionCode);

                    if (String.IsNullOrEmpty(code))
                    {
                        LogUtils.LogWarning("CakeTransactionHandler", "Transaction Content is empty", "Not Found");
                        return;
                    }

                    await TransactionHandlerUtils.UpdateTransaction(unit, code, PaymentType.Cake);
                    LogUtils.LogWarning("CakeTransactionHandler", "Payment By Cake Successful", "Successful");
                    EmailUtils.IsReadMail = false;
                }
            }
            catch (Exception e)
            {
                throw new BadRequestException("Message: " + e);
            }
        }

        LogUtils.LogWarning("Read-Cake-Mail", "No transaction yet", "Failed");
        throw new BadRequestException("No transaction yet");
    }
}