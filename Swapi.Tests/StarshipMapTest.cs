using System;
using System.Collections;
using System.Collections.Generic;
using Swapi.CrossCutting;
using Swapi.Integration.Spec;
using Xunit;

namespace Swapi.Tests
{
    public class StarshipDataGenerator : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {"Days", "3 days", "1", "Days", TimeSpan.FromDays(3d), 1L},
            new object[] {"Weeks", "3 weeks", "1", "Weeks", TimeSpan.FromDays(21d), 1L},
            new object[] {"Months", "3 months", "1", "Months", TimeSpan.FromDays(90d), 1L},
            new object[] {"Years", "3 years", "1", "Years", TimeSpan.FromDays(1095d), 1L},
            new object[] {"Invalid MGLT", "1 day", "unknown", "Invalid MGLT", TimeSpan.FromDays(1d), null}
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class StarshipMapTest
    {
        [Theory]
        [ClassData(typeof(StarshipDataGenerator))]
        public void StarshipMapping_IsValid(string actualName, string actualConsumables,
            string actualMglt, string expectedName, TimeSpan? expectedConsumables, long? expectedMglt)
        {
            var integrationStarship = new Starship
            {
                Name = actualName,
                Consumables = actualConsumables,
                Mglt = actualMglt
            };

            var mapper = AutoMapperConfig.Config();
            var actual = mapper.Map<Domain.Starship>(integrationStarship);

            var expected = new Domain.Starship
            {
                Name = expectedName,
                Consumables = expectedConsumables,
                Mglt = expectedMglt
            };

            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.Mglt, actual.Mglt);
            Assert.Equal(expected.Consumables, actual.Consumables);
        }
    }
}