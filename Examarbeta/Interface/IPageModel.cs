using Umbraco.Cms.Core.Models.PublishedContent;

namespace Examarbeta.Interface
{
    public interface IPageModel : IPublishedContent
    {
        IPublishedContent Content { get; }
    }
}
