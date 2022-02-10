using CTeleportTestAssignment.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace CTeleportTestAssignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DistanceMeasurementController : ControllerBase
    {
        private readonly ICoordinateService coordinateService;
        private readonly IMeasurmentService measurmentService;

        public DistanceMeasurementController(ICoordinateService coordinateService,
                                             IMeasurmentService measurmentService)
        {
            this.coordinateService = coordinateService;
            this.measurmentService = measurmentService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([StringLength(3, MinimumLength = 3, ErrorMessage = "IATACode should have 3 characters")] string sourceIATACode,
                                             [StringLength(3, MinimumLength = 3, ErrorMessage = "IATACode should have 3 characters")] string destinationIATACode)
        {
            var source = await coordinateService.GetPositionCoordinateByIATACode(sourceIATACode);
            var destination = await coordinateService.GetPositionCoordinateByIATACode(destinationIATACode);
            if (source == null || destination == null)
            {
                string errorMessage = "IATACodes incorrect";
                return ValidationProblem(errorMessage);
            }
            var distance = measurmentService.MeasureDistanceMiles(source, destination);
            return Ok(distance);
        }
    }
}