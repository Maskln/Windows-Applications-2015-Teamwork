namespace JustGoApp.DataModel
{
    public class Event
    {
        public string Title { get; set; }

        public string EventData { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }
        public string Location { get; set; }

        public Event()
        : this(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty)
        {

        }

        public Event(Event eventModel)
            : this(eventModel.Title, eventModel.EventData, eventModel.Address, eventModel.Description, eventModel.Location)
        {

        }

        public Event(string title, string data, string address, string description, string location)
        {
            this.Title = title;
            this.EventData = data;
            this.Address = address;
            this.Description = description;
            this.Location = location;
        }
    }
}
