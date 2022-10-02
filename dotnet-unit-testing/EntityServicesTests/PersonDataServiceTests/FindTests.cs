using Entities;

namespace EntityServicesTests.PersonDataServiceTests
{
    public class FindTests : BasePersonDataService
    {
        /*
         * We do not need to write comments in all our unit tests for:
         *      Positive | Negative Tests
         *      Arrange | Act | Assert
         * 
         * Ref: https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices?source=recommendations
         */

        //  Positive Tests:

        [Fact(DisplayName = "Basic predicate can find existing record")]
        public void BasicPredicate_CanFindExistingRecord()
        {
            //  Arrange.
            const string ID = "pete.mitchell@topgun.com.au";

            var people = new List<Person>
            {
                new Person
                {
                    Id = ID,
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
                }
            };

            InitializeData(people);

            //  Act.
            var response = Service.Find(p => p.Id == ID);

            //  Assert.
            Assert.True(response.Any());
            Assert.IsType<List<Person>>(response);

            var person = response.First();

            Assert.Equal(ID, person.Id);
            Assert.Equal(people[0].FirstName, person.FirstName);

            //  You should test all other entity properties...
        }

        [Fact(DisplayName = "Multi predicate can find existing record")]
        public void MultiPredicate_CanFindExistingRecord()
        {
            //  Arrange.
            const string ID = "pete.mitchell@topgun.com.au";
            var pilot = (PersonTypes.Pilot).ToString();

            var people = new List<Person>
            {
                new Person
                {
                    Id = ID,
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
                }
            };

            InitializeData(people);

            //  Act.
            var response = Service.Find(p => p.Id == ID && p.Type == pilot);

            //  Assert.
            Assert.True(response.Any());
            Assert.IsType<List<Person>>(response);

            var person = response.First();

            Assert.Equal(ID, person.Id);
            Assert.Equal(pilot, person.Type);
            Assert.Equal(people[0].FirstName, person.FirstName);

            //  You should test all other entity properties...
        }

        //  Negative Tests:
        [Fact(DisplayName = "Basic predicate cannot find nonexisting record")]
        public void BasicPredicate_CannotFindNonExistingRecord()
        {
            //  Arrange.
            const string ID = "non-existing-record";

            var people = new List<Person>
            {
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
                }
            };

            InitializeData(people);

            //  Act.
            var response = Service.Find(p => p.Id == ID);

            //  Assert.
            Assert.IsType<List<Person>?>(response);
            Assert.False(response.Any());
        }
    }
}
