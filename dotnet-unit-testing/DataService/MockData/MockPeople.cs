using Entities;

namespace DataService.MockData
{
    public static class MockPeople
    {
        public static List<Person> People = new List<Person> {
            new Person
            {
                Id = "pete.mitchell@topgun.com.au",
                LastName = "Mitchell",
                Dob = DateTime.SpecifyKind(DateTime.Parse("1964-01-01"), DateTimeKind.Utc),
                FirstName = "Pete (Maverick) Mitchell",
                Type = (PersonTypes.Pilot).ToString()
            },
            new Person
            {
                Id = "tom.kazansky@topgun.com.au",
                LastName = "Kazansky",
                Dob = DateTime.SpecifyKind(DateTime.Parse("1961-01-01"), DateTimeKind.Utc),
                FirstName = "Tom (Iceman) Kazansky",
                Type = (PersonTypes.Admiral).ToString()
            },
            new Person
            {
                Id = "bradley.bradshaw@topgun.com.au",
                LastName = "Bradley",
                Dob = DateTime.SpecifyKind(DateTime.Parse("1991-01-01"), DateTimeKind.Utc),
                FirstName = "Bradley (Rooster) Bradshaw",
                Type = (PersonTypes.Pilot).ToString()
            },
            new Person
            {
                Id = "jake.seresin@topgun.com.au",
                LastName = "Seresin",
                Dob = DateTime.SpecifyKind(DateTime.Parse("1990-01-01"), DateTimeKind.Utc),
                FirstName = "Jake (Hangman) Seresin",
                Type = (PersonTypes.Pilot).ToString()
            },
            new Person
            {
                Id = "beau.simpson@topgun.com.au",
                LastName = "Simpson",
                Dob = DateTime.SpecifyKind(DateTime.Parse("1980-01-01"), DateTimeKind.Utc),
                FirstName = "Beau (Cyclone) Simpson",
                Type = (PersonTypes.AirBoss).ToString()
            },
        };
    }
}
