using Hangfire.Server;

namespace Examarbeta.Business.SchedueldJobs;

public interface IEventsJob
{
    void RemoveEvents (PerformContext context);
}
