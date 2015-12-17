namespace JustGoWebApp.Services.Data.Contracts
{
    using System.Linq;
    using JustGoWebApp.Data.Models;

    public interface IUsersService
    {
        IQueryable<User> GetByUserName(string username);
    }
}
