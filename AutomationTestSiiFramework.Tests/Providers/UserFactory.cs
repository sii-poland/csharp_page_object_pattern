using System;
using AutomationTestSiiFramework.Tests.Models.User;
using Bogus;
using Bogus.DataSets;
using Address = AutomationTestSiiFramework.Tests.Models.User.Address;

namespace AutomationTestSiiFramework.Tests.Providers
{
    public class UserFactory
    {
        public static User RandomUser => new Faker<User>()
            .RuleFor(u => u.Gender, f => f.PickRandom<Name.Gender>())
            .RuleFor(c => c.FirstName, x => x.Name.FirstName())
            .RuleFor(c => c.LastName, x => x.Name.LastName())
            .RuleFor(c => c.Credentials, x => RandomCredentials)
            .RuleFor(c => c.Address, x => RandomAddress)
            .Generate();

        private static Credentials RandomCredentials => new Faker<Credentials>()
            .RuleFor(c => c.Email, x => x.Internet.Email())
            .RuleFor(c => c.Password, x => x.Internet.Password())
            .Generate();

        private static Address RandomAddress => new Faker<Address>()
            .RuleFor(c => c.Street, x => x.Address.StreetAddress())
            .RuleFor(c => c.PostalCode, x => x.Address.ZipCode(String.Format("#####")))
            .RuleFor(c => c.City, x => x.Address.City())
            .RuleFor(c => c.State, x => x.Random.Int(1, 56).ToString())
            .Generate();
    }
}