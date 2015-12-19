namespace JustGoWebApp.Services.Data.Contracts
{
    using System.Linq;
    using JustGoWebApp.Data.Models;

    public interface IEventsService
    {
        IQueryable<Events> GetAll(int skip, int take);

        IQueryable<Events> GetById(int id);
        
        int AddNew(Events newRealEstate, string userId);
    }
}
