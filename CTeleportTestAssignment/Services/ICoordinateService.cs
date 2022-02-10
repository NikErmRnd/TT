using CTeleportTestAssignment.Contracts;
using System.Threading.Tasks;

namespace CTeleportTestAssignment.Services
{
    public interface ICoordinateService
    {
        Task<CoordinateModel> GetPositionCoordinateByIATACode(string iATACode);
    }
}