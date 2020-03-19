using Bogus.DataSets;

namespace AutomationTestSiiFramework.Tests.Models.User
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Name.Gender Gender { get; set; }
        public Credentials Credentials { get; set; }
        public Address Address { get; set; }
    }
}