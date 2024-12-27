using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using Examarbeta.Models;
using Examarbeta.Models.ViewModels;

namespace Examarbeta.Controller
{
    public class AboutUsController : RenderController
    {
        private readonly ILogger<AboutUsController> _logger;
        private readonly IUmbracoContextAccessor _umbracoContextAccessor;

        public AboutUsController(ILogger<AboutUsController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor)
            : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
            _logger = logger;
            _umbracoContextAccessor = umbracoContextAccessor;
        }

        public override IActionResult Index()
        {
            var Aboutus = CurrentPage as AboutUs;

            if (Aboutus != null)
            {

                var model = new AboutusViewModel(Aboutus, _umbracoContextAccessor);
                return View("aboutUs", model);

            }

            _logger.LogWarning("about page not found.");

            return NotFound();

        }
    
    }
}
