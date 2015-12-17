using JustGoWebApp.Data.Models;
using JustGoWebApp.Web.Api.Infrastructure.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JustGoWebApp.Web.Api.Models.Users
{
    public class DataForUserResponseModel : UserResponseModel, IMapFrom<User>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string TelephonNumber { get; set; }
    }
}