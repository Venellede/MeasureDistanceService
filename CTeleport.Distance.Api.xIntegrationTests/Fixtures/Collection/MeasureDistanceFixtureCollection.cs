using Xunit;

namespace CTeleport.Distance.Api.xIntegrationTests.Fixtures.Collection
{
    [CollectionDefinition("Measure Distance Fixture", DisableParallelization = true)]
    public class MeasureDistanceFixtureCollection : ICollectionFixture<MeasureDistanceFixture<Startup>>
    {
    }
}
