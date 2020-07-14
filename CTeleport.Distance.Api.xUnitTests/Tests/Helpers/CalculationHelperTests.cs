using CTeleport.Distance.Api.Model;
using Xunit;

namespace CTeleport.Distance.Api.xUnitTests.Tests.Model
{
    public class CalculationHelperTests
    {
        [Fact, Trait("Owner", "AndreyK")]
        public void MeasureDistance_DMEandSVO_CorrectDistance()
        {
            var svoLon = 37.416574d;
            var svoLat = 55.966324d;

            var dmeLon = 37.899494d;
            var dmeLat = 55.414566d;

            var result = CalculationHelper.MeasureDistance(svoLat, svoLon, dmeLat, dmeLon);
            Assert.Equal(42.5569296364556, result);
        }

        [Fact, Trait("Owner", "AndreyK")]
        public void MeasureDistance_CDGandSVO_CorrectDistance()
        {
            var svoLon = 37.416574d;
            var svoLat = 55.966324d;

            var cdgLon = 2.567023d;
            var cdgLat = 49.003196d;

            var result = CalculationHelper.MeasureDistance(svoLat, svoLon, cdgLat, cdgLon);
            Assert.Equal(1526.0594570691769, result);
        }

        [Fact, Trait("Owner", "AndreyK")]
        public void MeasureDistance_JFKandSVO_CorrectDistance()
        {
            var svoLon = 37.416574d;
            var svoLat = 55.966324d;

            var jfkLon = -73.78817d;
            var jfkLat = 40.642335d;

            var result = CalculationHelper.MeasureDistance(svoLat, svoLon, jfkLat, jfkLon);
            Assert.Equal(4654.091351466679, result);
        }

        [Fact, Trait("Owner", "AndreyK")]
        public void MeasureDistance_EZEandSVO_CorrectDistance()
        {
            var svoLon = 37.416574d;
            var svoLat = 55.966324d;

            var ezeLon = -58.539834d;
            var ezeLat = -34.81273d;

            var result = CalculationHelper.MeasureDistance(svoLat, svoLon, ezeLat, ezeLon);
            Assert.Equal(8396.2932694884112, result);
        }

        [Fact, Trait("Owner", "AndreyK")]
        public void MeasureDistance_SVOandSVO_CorrectDistance()
        {
            var svoLon = 37.416574d;
            var svoLat = 55.966324d;

            var result = CalculationHelper.MeasureDistance(svoLat, svoLon, svoLat, svoLon);
            Assert.Equal(0, result);
        }

        [Fact, Trait("Owner", "AndreyK")]
        public void MeasureDistance_0_CorrectDistance()
        {
            var result = CalculationHelper.MeasureDistance(0, 0, 0, 0);
            Assert.Equal(0, result);
        }
    }
}
