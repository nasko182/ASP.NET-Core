using Homies.Data;
using Homies.Data.Models;
using Homies.Services.Interfaces;
using Homies.Web.ViewModels.Event;
using Homies.Web.ViewModels.Type;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Homies.Services
{
    public class HomiesService : IHomiesService
    {
        private readonly HomiesDbContext _dbContext;

        public HomiesService(HomiesDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IEnumerable<AllEventViewModel>> GetAllEventsAsync()
        {
            return await _dbContext
                .Events
                .Select(e => new AllEventViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Organiser = e.Organizer.UserName,
                    Start = e.Start.ToString("yyyy-MM-dd H:mm"),
                    Type = e.Type.Name
                })
                .ToListAsync();
        }

        public async Task<DetailsEventViewModel?> GetDetailsAsync()
        {
            return await _dbContext
                .Events
                .Select(e => new DetailsEventViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Organiser = e.Organizer.UserName,
                    Start = e.Start.ToString("yyyy-MM-dd H:mm"),
                    End = e.End.ToString("yyyy-MM-dd H:mm"),
                    CreatedOn = e.CreatedOn.ToString("yyyy-MM-dd H:mm"),
                    Type = e.Type.Name,
                    Description = e.Description,
                    
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TypeViewModel>> GetAllTypesAsync()
        {
            return await _dbContext
                .Types
                .Select(t => new TypeViewModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                })
                .ToListAsync();
        }

        public async Task AddEventToAllCollectionAsync(AddEventViewModel model, string userId)
        {
            await _dbContext.AddAsync(new Event()
            {
                Name = model.Name,
                OrganizerId = userId,
                Start = model.Start,
                End = model.End,
                TypeId = model.TypeId,
                Description = model.Description
            });

            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<JoinedEventViewModel>> GetJoinedEventsAsync(string userId)
        {
            return await _dbContext
                .EventsParticipants
                .Where(ep => ep.HelperId == userId)
                .Select(ep => new JoinedEventViewModel()
                {
                    Id = ep.Event.Id,
                    Name = ep.Event.Name,
                    Start = ep.Event.Start.ToString("yyyy-MM-dd H:mm"),
                    Type = ep.Event.Type.Name,
                    Organiser = ep.Event.OrganizerId
                })
                .ToListAsync();
        }

        public async Task EditEventAllCollectionAsync(EditEventViewModel model, int eventId)
        {
            var @event = await _dbContext.Events.FindAsync(eventId);

            if (@event != null)
            {
                @event.Name=model.Name;
                @event.Start = DateTime.Parse(model.Start);
                @event.Description = model.Description;
                @event.End = DateTime.Parse(model.End);
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task<EditEventViewModel?> GetEventByIdAsync(int id)
        {
           return await _dbContext
               .Events
               .Where(e=>e.Id==id)
               .Select(e=> new EditEventViewModel()
               {
                   Description = e.Description,
                   End= e.End.ToString("dd/MM/yyyy H:mm"),
                   Name = e.Name,
                   Start = e.Start.ToString("dd/MM/yyyy H:mm"),
                   TypeId = e.TypeId
               })
               .FirstOrDefaultAsync();
        }

        public async Task JoinEventAsync(string userId, int eventId)
        {
            bool alreadyJoined = await _dbContext
                .EventsParticipants
                .AnyAsync(ub => ub.HelperId == userId
                                && ub.EventId == eventId);

            if (!alreadyJoined)
            {
                var eventHelper = new EventParticipant()
                {
                    EventId = eventId,
                    HelperId = userId
                };

                await _dbContext.EventsParticipants.AddAsync(eventHelper);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task LeaveEventAsync(string userId, int eventId)
        {
            bool alreadyJoined = await _dbContext
                .EventsParticipants
                .AnyAsync(ub => ub.HelperId == userId
                                && ub.EventId == eventId);

            if (alreadyJoined)
            {
                var eventHelper = new EventParticipant()
                {
                    EventId = eventId,
                    HelperId = userId
                };

                _dbContext.EventsParticipants.Remove(eventHelper);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}