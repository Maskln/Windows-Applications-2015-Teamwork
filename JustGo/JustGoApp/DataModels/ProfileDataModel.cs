namespace JustGoApp.DataModels
{
    public class ProfileDataModel
    {
        public ProfileDataModel()
            : this(string.Empty, string.Empty, string.Empty, string.Empty)
        {

        }

        public ProfileDataModel(ProfileDataModel profile)
            : this(profile.FirstName, profile.LastName, profile.TelephoneNumber, profile.UserName)
        {

        }

        public ProfileDataModel(string firstName, string lastName, string telephoneNumber, string userName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.TelephoneNumber = telephoneNumber;
            this.UserName = userName;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string TelephoneNumber { get; set; }

        public string UserName { get; set; }
    }
}
