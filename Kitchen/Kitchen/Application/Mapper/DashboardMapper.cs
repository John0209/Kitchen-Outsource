using Kitchen.Application.Models.Responses.Dashboard;
using Kitchen.Application.Models.Responses.Transaction;
using Kitchen.Application.Utils;
using Kitchen.Infrastructure.Entities;

namespace Kitchen.Application.Mapper;

public static class DashboardMapper
{
    private static DateTime _today = DateTime.Today;

    public static GetDashboardResponse GetDashboardMapper(List<User> user, List<Transaction> transactions) =>
        new GetDashboardResponse()
        {
            TotalUser = user.Count,
            TotalUserToday = user.Count(x => x.CreateDate.Date == _today),
            TotalMemberShip = user.Count(x => x.IsMember),
            TotalMemberShipToday =
                user.Count(x => x.IsMember && x.Transactions!.Any(z => z.TransactionDate.Date == _today)),
            TotalTransaction = transactions.Count,
            TotalTransactionToday = transactions.Count(x => x.TransactionDate.Date == _today),
            TotalIncome = transactions.Select(x => x.Membership!.Price).Sum(),
            TotalIncomeToday = transactions.Where(x => x.TransactionDate.Date == _today)
                .Select(x => x.Membership!.Price).Sum(),
            Transactions = GetTransactionDashboardDto(transactions)
        };

    private static List<TransactionDashboardDto> GetTransactionDashboardDto(List<Transaction> list)
    {
        List<TransactionDashboardDto> dashboards = new List<TransactionDashboardDto>();
        var transactions = list.GroupBy(x => x.Status).ToList();

        foreach (var group in transactions)
        {
            List<GetTransactionResponse> transactionResponses = group.Select(x => new GetTransactionResponse()
            {
                Id = x.Id,
                UserName = x.User!.UserName,
                TransactionDate = DateUtils.FormatDateTimeToDateV1(x.TransactionDate),
                Price = x.Membership!.Price,
                ValidityPeriod = x.Membership!.ValidityPeriod,
                ValidityDays = (int)x.Membership!.ValidityPeriod,
                TransactionCode = x.TransactionCode,
                Status = x.Status
            }).ToList();

            TransactionDashboardDto transactionDto = new TransactionDashboardDto()
            {
                TransactionStatus = group.Key,
                TotalTransactionByStatus = group.Count(),
                Transactions = transactionResponses
            };

            dashboards.Add(transactionDto);
        }

        return dashboards;
    }
}