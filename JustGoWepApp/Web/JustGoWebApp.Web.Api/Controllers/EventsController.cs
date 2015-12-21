namespace JustGoWebApp.Web.Api.Controllers
{
    using System.Collections;
    using System.Linq;
    using System.Web.Http;
    using AutoMapper;
    using Common.Constants;
    using Infrastructure.Validation;
    using Services.Data.Contracts;
    using AutoMapper.QueryableExtensions;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Models.RealEstates;

    public class EventsController : ApiController
    {
        private readonly IEventsService events;

        public EventsController(IEventsService events)
        {
            this.events = events;
        }

        [ValidateTake]
        public IHttpActionResult Get(
            int skip = EventConstants.DefaultEventsSkip,
            int take = EventConstants.DefaultEventsTake)
        {
            var result = this.events
                .GetAll(skip, take)
                .ProjectTo<ListedEventsResponseModel>()
                .ToList();

            return this.Ok(result);
        }   

        [Authorize]
        [ValidateModel]
        public IHttpActionResult Post(EventResponseModel model)
        {
            var newEvent = Mapper.Map<Events>(model);
            var id = this.events.AddNew(newEvent, this.User.Identity.GetUserId());

            var result = this.events
                .GetById(id)
                .ProjectTo<ListedEventsResponseModel>()
                .FirstOrDefault();

            return this.Created($"/api/Events/{id}", result);
        }
    }
}
