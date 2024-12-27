using Examarbeta.Models.PublishedModel;
using Umbraco.Cms.Core.Web;

namespace Examarbeta.Models.ViewModels
{
    public class StartPageViewModel : BasePageViewModel<Start>
    {
        public StartPageViewModel(Start content, IUmbracoContextAccessor umbracoContextAccessor) : base(content, umbracoContextAccessor)
        {
        }
    }
}
