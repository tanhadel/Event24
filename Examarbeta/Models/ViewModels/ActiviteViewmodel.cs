using Umbraco.Cms.Core.Web;

namespace Examarbeta.Models.ViewModels
{
    public class ActiviteViewmodel : BasePageViewModel<Activite>
    {
        public ActiviteViewmodel(Activite content, IUmbracoContextAccessor umbracoContextAccessor) : base(content, umbracoContextAccessor)
        {
        }

        public IEnumerable<EventItemViewModel> Events { get; internal set; }
    }
}
