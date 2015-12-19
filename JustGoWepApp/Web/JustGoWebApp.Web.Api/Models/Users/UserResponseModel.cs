namespace JustGoWebApp.Web.Api.Models.Users
{
    using System.Linq;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mappings;
    using System.Collections.Generic;
    using RealEstates;

    public class UserResponseModel : IMapFrom<User>
    {
        public string UserName { get; set; }

        public IEnumerable<EventResponseModel> Events { get; set; }
    }
}
