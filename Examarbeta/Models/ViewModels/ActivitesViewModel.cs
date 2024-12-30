using System.Collections.Generic;
using Umbraco.Cms.Core.Web;

namespace Examarbeta.Models.ViewModels
{
    public class ActiviteViewModel : BasePageViewModel<Activites>
    {
        public IEnumerable<EventItemViewModel> Events { get; set; }
        public ActiviteViewModel(Activites content, IUmbracoContextAccessor umbracoContextAccessor) : base(content, umbracoContextAccessor)
        {
            Events = new List<EventItemViewModel>();
        }
    }
}
