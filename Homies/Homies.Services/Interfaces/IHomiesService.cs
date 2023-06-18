using Homies.Web.ViewModels.Event;
using Homies.Web.ViewModels.Type;
using System.Threading.Tasks;

namespace Homies.Services.Interfaces
{
    public interface IHomiesService
    {
        Task<IEnumerable<AllEventViewModel>> GetAllEventsAsync();

        Task<IEnumerable<TypeViewModel>> GetAllTypesAsync();

        Task AddEventToAllCollectionAsync(AddEventViewModel model, string userId);

        Task<IEnumerable<JoinedEventViewModel>> GetJoinedEventsAsync(string userId);

        Task EditEventAllCollectionAsync(EditEventViewModel model, int eventId);
        Task<EditEventViewModel?> GetEventByIdAsync(int id);

        Task JoinEventAsync(string userId, int eventId);

        Task LeaveEventAsync(string userId, int eventId);

        Task<DetailsEventViewModel?> GetDetailsAsync();
    }
}
