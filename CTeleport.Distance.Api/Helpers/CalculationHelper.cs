using CTeleport.Distance.Api.Exceptions;
using System;

namespace CTeleport.Distance.Api.Model
{
    public static class CalculationHelper
    {
        private const double EarthRadius = 6378.137;
        private const double MilesCof = 0.62137;

        public static double MeasureDistance(double firstLat, double firstLon, double secondLat, double secondLon)
        {
            try
            {
                var lat1 = firstLat * Math.PI / 180;
                var lat2 = secondLat * Math.PI / 180;
                var lon1 = firstLon * Math.PI / 180;
                var lon2 = secondLon * Math.PI / 180;

                var cosLatFirst = Math.Cos(lat1);
                var cosLatSecond = Math.Cos(lat2);

                var sinLatFirst = Math.Sin(lat1);
                var sinLatSecond = Math.Sin(lat2);

                var delta = lon2 - lon1;
                var cosDelta = Math.Cos(delta);
                var sinDelta = Math.Sin(delta);

                var x = sinLatFirst * sinLatSecond + cosLatFirst * cosLatSecond * cosDelta;
                var y = Math.Sqrt(Math.Pow(cosLatSecond * sinDelta, 2) + Math.Pow(cosLatFirst * sinLatSecond - sinLatFirst * cosLatSecond * cosDelta, 2));

                var ad = Math.Atan2(y, x);
                var distanceKm = ad * EarthRadius;

                return distanceKm * MilesCof;
            }
            catch (Exception e)
            {
                throw new InvalidCalculationException(e);
            }
        }
    }
}
