using System;
using System.ComponentModel;
using Swapi.Core;
using Xunit;

namespace Swapi.Tests
{
    public class StarshipTest
    {
        [Fact]
        [Description("AmmoutOfStops must return unknown if MGLT, Consumables are null or zero.")]
        public void AmmountOfStops_MustReturnNullWhenStarshipDataIsInvalid()
        {
            var starship = new Starship
            {
                Name = "Test",
                Consumables = TimeSpan.Zero,
                Mglt = 0
            };

            Assert.Equal("unknown", starship.AmmountOfStops(1_000_000));
        }
    }
}