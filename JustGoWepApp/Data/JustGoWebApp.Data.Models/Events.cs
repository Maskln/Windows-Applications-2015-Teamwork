namespace JustGoWebApp.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;

    public class Events
    {
        private ICollection<User> sentUsers;

        public Events()
        {
            this.sentUsers = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(RealEstateConstants.TitleMinLength)]
        [MaxLength(RealEstateConstants.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(RealEstateConstants.DescriptionMinLength)]
        [MaxLength(RealEstateConstants.DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Contact { get; set; }
        
        [Range(RealEstateConstants.MinConstructionYear, int.MaxValue)]
        public int ConstructionYear { get; set; }

        public DateTime EventData { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<User> SentUsers
        {
            get { return this.sentUsers; }
            set { this.sentUsers = value; }
        } 
    }
}
