using Examarbeta.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Web;

namespace Examarbeta.Controllers
{
    [Route("api/[controller]")]
    public class EventApiController : ControllerBase
    {
        private readonly IUmbracoContextAccessor _umbracoContextAccessor;
        private readonly IPublishedContentQuery _publishedContentQuery;

        // Inject IUmbracoContextAccessor and IPublishedContentQuery
        public EventApiController(IUmbracoContextAccessor umbracoContextAccessor, IPublishedContentQuery publishedContentQuery)
        {
            _umbracoContextAccessor = umbracoContextAccessor;
            _publishedContentQuery = publishedContentQuery;
        }
        public IActionResult GetEvents()
        {
            var rootContent = _publishedContentQuery.ContentAtRoot().FirstOrDefault();
            if (rootContent == null)
            {
                return NotFound("Root content not found.");
            }

            var events = rootContent.DescendantsOrSelf("activite") // Kontrollera att detta alias är rätt
                .Select(x => new
                {
                    title = x.Name,
                    start = x.Value<DateTime>("eventDate").ToString("yyyy-MM-dd"), // Datumformat anpassat för kalender
                    description = x.Value<string>("eventDescription"),
                    location = x.Value<string>("location")
                })
                .ToList();

            return Ok(events);
        }



    }
}
