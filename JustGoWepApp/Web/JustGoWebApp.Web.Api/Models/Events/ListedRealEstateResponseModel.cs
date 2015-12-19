namespace JustGoWebApp.Web.Api.Models.RealEstates
{
    using System;
    using Data.Models;
    using Infrastructure.Mappings;
  
    public class ListedEventsResponseModel : IMapFrom<Events>
    {
        public int Id { get; set; }

        public string Title { get; set; }
                      
        public string Description { get; set; }

        public string Address{ get; set; }

        public DateTime EventData { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
