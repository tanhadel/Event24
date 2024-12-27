using Examarbeta.Interface;
using Examarbeta.Models;
using Examarbeta.Models.ViewModels;
using Examarbeta.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace Examarbeta.Controller
{
    public class ActiviteController : RenderController
    {
        private readonly ILogger<ActiviteController> _logger;
        private readonly IUmbracoContextAccessor _umbracoContextAccessor;
        private readonly IEventService _eventService;
        public ActiviteController(ILogger<ActiviteController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor, IEventService eventService)
            : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
            _logger = logger;
            _umbracoContextAccessor = umbracoContextAccessor;
            _eventService = eventService;
        }
        public override IActionResult Index()
        {
            // Kontrollera om eventservice är korrekt injicerad
            if (_eventService == null)
            {
                _logger.LogError("Event service is not initialized.");
                return StatusCode(500, "Internal server error");
            }

            var createPage = CurrentPage as Activite;
            if (createPage != null)
            {
                try
                {
                    // Hämta eventdata asynkront
                    var events = _eventService.GetactivitesAsync().Result;
                    if (events == null || !events.Any())
                    {
                        _logger.LogWarning("No events found.");
                        return NotFound();
                    }

                    var model = new ActiviteViewmodel(createPage, _umbracoContextAccessor)
                    {
                        Events = events
                    };

                    return View("activite", model);
                }
                catch (Exception ex)
                {
                    // Logga eventuella undantag som uppstår
                    _logger.LogError(ex, "An error occurred while retrieving events.");
                    return StatusCode(500, "An error occurred while retrieving events.");
                }
            }

            _logger.LogWarning("Activite page not found.");
            return NotFound();
        }
    }


}
