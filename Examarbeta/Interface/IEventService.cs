using Examarbeta.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examarbeta.Interface
{
    public interface IEventService
    {
        Task<IEnumerable<EventItemViewModel>> GetactivitesAsync();
    }
}
