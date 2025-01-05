
using Examarbeta.Interface;
using Examarbeta.Models.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Umbraco.Extensions;

namespace Examarbeta.Services;

public class EventService : IEventService
{
    private readonly IUmbracoContextAccessor _umbracoContextAccessor;
    private readonly ILogger<EventService> _logger;

    public EventService(IUmbracoContextAccessor umbracoContextAccessor, ILogger<EventService> logger)
    {
        _umbracoContextAccessor = umbracoContextAccessor;
        _logger = logger;
    }

    public async Task<IEnumerable<EventItemViewModel>> GetactivitesAsync()
    {
        try
        {
            if (!_umbracoContextAccessor.TryGetUmbracoContext(out var umbracoContext))
            {
                _logger.LogError("Could not access Umbraco Context");
                return Enumerable.Empty<EventItemViewModel>();
            }

            var rootContent = umbracoContext.Content?.GetAtRoot()?.FirstOrDefault();
            if (rootContent == null)
            {
                _logger.LogWarning("Root content is null.");
                return Enumerable.Empty<EventItemViewModel>();
            }

            var activites = rootContent.DescendantsOrSelfOfType("activite")
                .Where(e => e.IsPublished())
                .Select(e => new EventItemViewModel
                {
                    Title = e.Value<string>("title"),
                    EventDescription = e.Value<string>("eventDescription"),
                    EventPlace = e.Value<string>("eventPlace"),
                    EventPrice = e.Value<int>("eventprice"),
                    EventCapacity = e.Value<int>("eventcapacity"),
                    EventDate = e.Value<DateTime>("eventDate"),
                    EventImage = e.Value<IPublishedContent>("eventImage")?.Url() ?? string.Empty,
                    EventUrl = e.Url(),
                    AltImageText = e.Value<string>("altImageText"),
                    textlong = e.Value<string>("textLong"),
                    EventOwner = e.Value<string>("eventOwner"),
                    AdditionalImages = e.Value<IEnumerable<IPublishedContent>>("additionalImages")
                        ?.Select(img => img.Url())
                        .ToList() ?? new List<string>(),
                    EventsInfo = e.Value<string>("eventsInfo"),
                    EventInfolongtext = e.Value<string>("eventInfoLongText"),
                    

                })
                .ToList();

            return await Task.FromResult(activites);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching events.");
            return Enumerable.Empty<EventItemViewModel>();
        }
    }



}
