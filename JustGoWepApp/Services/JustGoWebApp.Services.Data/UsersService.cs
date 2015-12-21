namespace JustGoWebApp.Services.Data
{          
    using System.Linq;
    using Contracts;
    using JustGoWebApp.Data.Models;
    using JustGoWebApp.Data.Repositories;

    public class UsersService : IUsersService
    {
        private readonly IRepository<User> users;
        private readonly IRepository<Events> eventUser;

        public UsersService(IRepository<User> users, IRepository<Events> eventUser)
        {
            this.users = users;
            this.eventUser = eventUser;
        }

        public IQueryable<User> GetByUserName(string username)
        {
            return this.users
                .All()
                .Where(u => u.UserName == username);
        }
    }
}
