namespace JustGoWebApp.Web.Api.Models.Users
{
    using System.Collections.Generic;
    using Data.Models;
    using Infrastructure.Mappings;   
    using RealEstates;

    public class UserResponseModel : IMapFrom<User>
    {
        public string UserName { get; set; }

        public IEnumerable<EventResponseModel> Events { get; set; }
    }
}
