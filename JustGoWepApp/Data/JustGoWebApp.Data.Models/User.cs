namespace JustGoWebApp.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Common.Constants;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework; 

    public class User : IdentityUser
    {
        private ICollection<Events> eventsUser;     

        public User()
        {
            this.eventsUser = new HashSet<Events>();
        }
        
        public virtual ICollection<Events> EventsUser
        {
            get { return this.eventsUser; }
            set { this.eventsUser = value; }
        }                                            
        
        [MinLength(UserConstants.NameMinLength)]
        [MaxLength(UserConstants.NameMaxLength)]
        public string FirstName { get; set; }

        [MinLength(UserConstants.NameMinLength)]
        [MaxLength(UserConstants.NameMaxLength)]
        public string LastName { get; set; }

        [MinLength(UserConstants.TelephoneMinLength)]
        public string TelephoneNumber { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            return userIdentity;
        }
    }
}
