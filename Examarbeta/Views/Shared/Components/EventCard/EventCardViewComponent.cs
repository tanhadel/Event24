using Examarbeta.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Web;

namespace Examarbeta.Views.Shared.Components.EventCard
{
    public class EventCardViewComponent : ViewComponent
    {
        private readonly IEventService _eventService;
        private readonly IUmbracoContextAccessor _umbracoContextAccessor;

        public EventCardViewComponent(IEventService eventService, IUmbracoContextAccessor umbracoContextAccessor)
        {
            _eventService = eventService;
            _umbracoContextAccessor = umbracoContextAccessor;
        }

        public async Task<IViewComponentResult> InvokeAsync(string viewType = "header")
        {
            var activites = await _eventService.GetactivitesAsync(); // Fetches list of events

            if (!_umbracoContextAccessor.TryGetUmbracoContext(out var umbracoContext))
            {
                throw new InvalidOperationException("Umbraco context is not available.");
            }

            var viewName = viewType switch
            {
                "Compact" => "ActivitesCard", // For a compact view
                _ => "ActiviteCard" // Default view
            };

            return View(viewName, activites); // Sends events to the view
        }
    }
}
