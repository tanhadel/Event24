using Examarbeta.Models;
using Examarbeta.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace Examarbeta.Controller;

public class ActivitesController : RenderController
{
    private readonly IUmbracoContextAccessor _umbracoContextAccessor;

    public ActivitesController(ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor) : base(logger, compositeViewEngine, umbracoContextAccessor)
    {
        _umbracoContextAccessor = umbracoContextAccessor;
    }
    public override IActionResult Index()
    {
        var activites = CurrentPage as Activites;
        if (activites != null)
        {
            var model = new ActivitesViewModel(activites, _umbracoContextAccessor);
            return View("activites", model);
        }
        return null!;
    }
}
