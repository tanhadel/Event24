
using Examarbeta.Business.SchedueldJobs;
using Hangfire;
using Umbraco.Cms.Core.Composing;

namespace Examarbeta.Business.Composers
{
    public class ScheduledJobsComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            RecurringJob.AddOrUpdate<IEventsJob>(
                "Remove Events", x => x.RemoveEvents(null), Cron
                .Monthly);

            Console.WriteLine("Scheduled job 'Remove Events' has been registered.");
        }
    }
}
