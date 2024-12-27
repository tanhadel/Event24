using Umbraco.Cms.Core.Web;

namespace Examarbeta.Models.ViewModels
{
    public class ActivitesViewModel : BasePageViewModel<Activites>
    {
        public IEnumerable<EventItemViewModel> Events { get; set; }
        public ActivitesViewModel(Activites content, IUmbracoContextAccessor umbracoContextAccessor) : base(content, umbracoContextAccessor)
        {
            Events = new List<EventItemViewModel>();
        }
    }
}
