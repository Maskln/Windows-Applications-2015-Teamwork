namespace JustGoWebApp.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;

    public class Events
    {
        private ICollection<User> sentUsers;

        private ICollection<User> goUsers;
        public Events()
        {
            this.sentUsers = new HashSet<User>();
            this.goUsers = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(EventConstants.TitleMinLength)]
        [MaxLength(EventConstants.TitleMaxLength)]
        public string Title { get; set; }

        //TODO: Required?
        [Required]
        [MinLength(EventConstants.DescriptionMinLength)]
        [MaxLength(EventConstants.DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public string Address { get; set; }

        public DateTime EventData { get; set; }

        public DateTime CreatedOn { get; set; } 

        [Required]
        public string Location { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<User> SentUsers
        {
            get { return this.sentUsers; }
            set { this.sentUsers = value; }
        }
        public virtual ICollection<User> GoUsers
        {
            get { return this.goUsers; }
            set { this.goUsers = value; }
        }
    }
}
