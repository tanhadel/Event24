
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;

namespace Examarbeta.Models.PublishedModel
{
    public class BaseContentModel : PublishedContentModel
    {
        private readonly IUmbracoContextAccessor _umbracoContextAccessor;

        public BaseContentModel(IPublishedContent content, IPublishedValueFallback publishedValueFallback)
            : base(content, publishedValueFallback)
        {
            _umbracoContextAccessor = StaticServiceProvider.Instance.GetService<IUmbracoContextAccessor>();
        }

        // Du kan här definiera gemensamma funktioner som används i flera sidor
        public Start StartPage
        {
            get
            {
                if (_umbracoContextAccessor.TryGetUmbracoContext(out var umbracoContext))
                {
                    var content = umbracoContext.Content;
                    return content.GetAtRoot().DescendantsOrSelf<Start>().FirstOrDefault();
                }
                return null;
            }
        }
    }
}
