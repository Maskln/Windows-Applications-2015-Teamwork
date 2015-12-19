namespace JustGoWebApp.Services.Data
{
    using System;
    using System.Linq;
    using Contracts;
    using JustGoWebApp.Data.Models;
    using JustGoWebApp.Data.Repositories;

    public class EventsService : IEventsService
    {
        private readonly IRepository<Events> Events;

        public EventsService(IRepository<Events> events)
        {
            this.Events = events;
        }
        
        public IQueryable<Events> GetAll(int skip, int take)
        {
            return this.Events
                .All()
                .OrderByDescending(r => r.CreatedOn)
                .Skip(skip)
                .Take(take);
        }

        public IQueryable<Events> GetById(int id)
        {
            return this.Events
                .All()
                .Where(r => r.Id == id);
        }

        public int AddNew(Events newEvent, string userId)
        {
            newEvent.CreatedOn = DateTime.UtcNow;
            newEvent.UserId = userId;

            this.Events.Add(newEvent);
            this.Events.SaveChanges();

            return newEvent.Id;
        }
    }
}
