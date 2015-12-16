namespace JustGoWebApp.Services.Data
{
    using System;
    using System.Linq;
    using Contracts;
    using JustGoWebApp.Data.Models;
    using JustGoWebApp.Data.Repositories;

    public class RealEstatesService : IRealEstatesService
    {
        private readonly IRepository<Events> realEstates;

        public RealEstatesService(IRepository<Events> realEstates)
        {
            this.realEstates = realEstates;
        }
        
        public IQueryable<Events> GetAll(int skip, int take)
        {
            return this.realEstates
                .All()
                .OrderByDescending(r => r.CreatedOn)
                .Skip(skip)
                .Take(take);
        }

        public IQueryable<Events> GetById(int id)
        {
            return this.realEstates
                .All()
                .Where(r => r.Id == id);
        }

        public int AddNew(Events newRealEstate, string userId)
        {
            newRealEstate.CreatedOn = DateTime.UtcNow;
            newRealEstate.UserId = userId;

            this.realEstates.Add(newRealEstate);
            this.realEstates.SaveChanges();

            return newRealEstate.Id;
        }
    }
}
