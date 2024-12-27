using Umbraco.Cms.Core.Web;

namespace Examarbeta.Models.ViewModels
{
    public class AboutusViewModel : BasePageViewModel<AboutUs>
    {
        public AboutusViewModel(AboutUs content, IUmbracoContextAccessor umbracoContextAccessor) : base(content, umbracoContextAccessor)
        {
        }
    }
}
