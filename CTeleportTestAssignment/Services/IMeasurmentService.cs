using CTeleportTestAssignment.Contracts;

namespace CTeleportTestAssignment.Services
{
    public interface IMeasurmentService
    {
        double MeasureDistanceMiles(CoordinateModel source, CoordinateModel destination);
    }
}