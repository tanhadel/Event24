using Examarbeta.Models.ViewModels;

namespace Examarbeta.Interface
{
    public interface IEventService
    {
        Task<IEnumerable<EventItemViewModel>> GetactivitesAsync();
    }
}
