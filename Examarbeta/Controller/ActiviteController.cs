using Examarbeta.Interface;
using Examarbeta.Models;
using Examarbeta.Models.ViewModels;
using Examarbeta.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
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
            var activite = CurrentPage as Activite;
            if (activite != null)
            {
                var model = new ActiviteViewmodel(activite, _umbracoContextAccessor);
                return View("activite", model);
            }
            return null!;
        }
    }
    


}
