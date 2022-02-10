using CTeleportTestAssignment.Contracts;
using System;

namespace CTeleportTestAssignment.Services
{
    public class MeasurmentService : IMeasurmentService
    {
        public double MeasureDistanceMiles(CoordinateModel source, CoordinateModel destination)
        {
            double lat1Rad = source.Lat * Constants.M_PI / 180;
            double lat2Rad = destination.Lat * Constants.M_PI / 180;
            double long1Rad = source.Lon * Constants.M_PI / 180;
            double long2Rad = destination.Lon * Constants.M_PI / 180;

            double cl1 = Math.Cos(lat1Rad);
            double cl2 = Math.Cos(lat2Rad);
            double sl1 = Math.Sin(lat1Rad);
            double sl2 = Math.Sin(lat2Rad);
            double delta = long2Rad - long1Rad;
            double cdelta = Math.Cos(delta);
            double sdelta = Math.Sin(delta);

            double y = Math.Sqrt(Math.Pow(cl2 * sdelta, 2) + Math.Pow(cl1 * sl2 - sl1 * cl2 * cdelta, 2));
            double x = sl1 * sl2 + cl1 * cl2 * cdelta;

            double ad = Math.Atan2(y, x);
            double dist = ad * Constants.EARTH_RADIUS;

            double result = dist * 0.000621371192;

            return result;
        }
    }
}