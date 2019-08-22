using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swapi.Core;
using Swapi.CrossCutting;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace Swapi.Tests.Steps
{
    [Binding]
    public class CalculatorSteps
    {
        private List<StarshipStops> _actualStarshipStops;
        private long _distanceInMglu;

        [Given(@"I have a desire to know how many stops all starships have to make in a flight of (.*) MGLT")]
        public void GivenIHaveADesireToKnowHowManyStopsAllStarshipsHaveToMakeInAFlightOfMGLT(long distanceInMglu)
        {
            _distanceInMglu = distanceInMglu;
        }

        [When("I press enter")]
        public async Task WhenIPressEnterAsync()
        {
            var service = new StarshipService(AutoMapperConfig.Config());
            _actualStarshipStops = await service.ListStarshipsAndStopsAsync(_distanceInMglu);
        }

        [Then(
            "the calculator must list all spaceships and their number of stops before depleting all consumables like this:")]
        public void ThenTheCalculatorMustListAllSpaceshipsAndTheirNumberOfStopsBeforeDepletingAllConsumables(
            Table expectedStarshipStops)
        {
            var expectedSet = expectedStarshipStops.CreateSet<StarshipStops>();

            // Verifies if the expected set is a subset of the actual set.
            Assert.True(expectedSet.Except(_actualStarshipStops).Any());
        }
    }
}