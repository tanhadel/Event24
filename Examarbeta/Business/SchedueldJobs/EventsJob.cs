using Hangfire.Console;
using Hangfire.Server;
using Umbraco.Cms.Core.Services;

namespace Examarbeta.Business.SchedueldJobs;

public class EventsJob : IEventsJob
{
    private readonly IContentService _contentService;
    private readonly IContentTypeService _contentTypeService;

    public EventsJob(IContentService contentService, IContentTypeService contentTypeService)
    {
        _contentService = contentService;
        _contentTypeService = contentTypeService;
    }

    public void RemoveEvents(PerformContext context)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        var progressBar = context.WriteProgressBar();
        var today = DateTime.Now;
        var eventPageAlias = "activites";

        var contentType = _contentTypeService.GetAll().FirstOrDefault(ct => ct.Alias == eventPageAlias);

        if (contentType == null)
        {
            context.WriteLine($"Content type with alias '{eventPageAlias}' not found.");
            return;
        }

        var parentPageGuid = Guid.Parse("6404740b-e545-40bb-91fa-111c379ff4a6");

        var parentNode = _contentService.GetById(parentPageGuid);
        if (parentNode == null)
        {
            context.WriteLine("Parent page not found.");
            return;
        }

        var parentPageId = parentNode.Id;
        context.WriteLine("Fetching all events...");
        var allEvents = _contentService.GetPagedChildren(parentPageId, 0, int.MaxValue, out var total).ToList();

        var oldEvents = allEvents
            .Where(e => (today - e.CreateDate).TotalDays > 180)
            .ToList();

        foreach (var eventItem in oldEvents.WithProgress(progressBar, oldEvents.Count))
        {
            try
            {
                context.WriteLine($"Removing event: {eventItem.Name}");
                _contentService.Delete(eventItem);
            }
            catch (Exception ex)
            {
                context.WriteLine($"Failed to remove event: {eventItem.Name}. Error: {ex.Message}");
            }
        }

        context.WriteLine("Event cleanup completed.");
    }
}
