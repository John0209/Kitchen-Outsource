using Hangfire;
using Kitchen.Application.Handler.Transaction;

namespace Kitchen.MiddleWare;

public class HangfireJobScheduler
{
    private readonly CakeTransactionHandler _handler;

    public HangfireJobScheduler(CakeTransactionHandler handler)
    {
        _handler = handler;
    }

    public void ScheduleJobs()
    {
        var options = new RecurringJobOptions
        {
            TimeZone = TimeZoneInfo.Local
        };

        RecurringJob.AddOrUpdate("check-cake-email-job", 
            () => _handler.CheckCakeEmail(), 
            "*/2 * * * *", 
            options);
    }
}