namespace JustGoWebApp.Web.Api.Models.RealEstates
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Constants;
    using Data.Models;
    using Infrastructure.Mappings;
    using System;
    public class EventResponseModel : IMapFrom<Events>
    {
        [Required]
        [MinLength(EventConstants.TitleMinLength)]
        [MaxLength(EventConstants.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(EventConstants.DescriptionMinLength)]
        [MaxLength(EventConstants.DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public string Address { get; set; }

        public DateTime EventData { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (!this.SellingPrice.HasValue && !this.RentingPrice.HasValue)
        //    {
        //        yield return new ValidationResult("Real estate must be marked as available for selling or available for renting!");
        //    }
        //}
    }
}
