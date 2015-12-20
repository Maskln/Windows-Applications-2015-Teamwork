namespace JustGoWebApp.Web.Api.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using AutoMapper.QueryableExtensions;
    using Models.Users;
    using Services.Data.Contracts;

    public class UsersController : ApiController
    {
        private readonly IUsersService users;

        public UsersController(IUsersService users)
        {
            this.users = users;
        }

        [Authorize]
        public IHttpActionResult Get()
        {
            string username = this.User.Identity.Name.ToString();

            var result = this.users
                .GetByUserName(username)
                .ProjectTo<DataForUserResponseModel>()
                .FirstOrDefault();

            return this.Ok(result);
        }
    }
}
