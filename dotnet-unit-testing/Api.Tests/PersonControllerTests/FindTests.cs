using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Api.Tests.PersonControllerTests
{
    public class FindTests : BasePersonController
    {
        [Fact(DisplayName = "Ok Can find existing record")]
        public void Ok_CanFindExistingRecord()
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
            var response = Controller.Find(ID);

            //  Assert.
            Assert.NotNull(response);
            var okObjectResult = Assert.IsType<OkObjectResult>(response);
            Assert.Equal((int)HttpStatusCode.OK, okObjectResult.StatusCode);

            /*  In this context, we don't need to test the person value because we have:
             *      1. Already tested the data service separately
             *      2. Not performed any further functionality such as data shaping
             *      3. We have mocked the data
             *      
             *  All we need to test for is we get an OK 200 result.
             */
            var person = Assert.IsAssignableFrom<Person>(okObjectResult.Value);

            Assert.Equal(ID, person.Id);
        }

        [Fact(DisplayName = "Notfound Cannot find nonexisting record")]
        public void Notfound_FindNonExistingRecord()
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
            var response = Controller.Find(ID);

            //  Assert.
            Assert.NotNull(response);
            var notFoundResult = Assert.IsType<NotFoundResult>(response);
            Assert.Equal((int)HttpStatusCode.NotFound, notFoundResult.StatusCode);
        }
    }
}
