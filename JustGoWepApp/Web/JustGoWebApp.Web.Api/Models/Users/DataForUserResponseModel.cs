namespace JustGoWebApp.Web.Api.Models.Users
{
    using JustGoWebApp.Data.Models;
    using JustGoWebApp.Web.Api.Infrastructure.Mappings;     

    public class DataForUserResponseModel : UserResponseModel, IMapFrom<User>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string TelephoneNumber { get; set; }
    }
}