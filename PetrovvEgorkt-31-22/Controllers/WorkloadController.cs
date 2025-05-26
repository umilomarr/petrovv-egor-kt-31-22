using Microsoft.AspNetCore.Mvc;
using PetrovvEgorkt_31_22.Interfaces;


namespace PetrovvEgorkt_31_22.Controllers
{
    public class WorkloadController : ControllerBase
    {
        private readonly ILogger<WorkloadController> _logger;
        private readonly IWorkloadService _workloadService;

        public WorkloadController(ILogger<WorkloadController> logger, IWorkloadService workloadService)
        {
            _logger = logger;
            _workloadService = workloadService;
        }

        [HttpGet("GetWorkloads")]
        public async Task<IActionResult> GetWorkloadsAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var workload = await _workloadService.GetWorkloadsAsync(cancellationToken);
                return Ok(workload);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error catched while Getting Workload: {ex.Message}");
            }

        }
        [HttpPost("AddWorkloads")]
        public async Task<IActionResult> AddWorkloadAsync(int teacherId, int disciplineId, string lessonType, int hours, CancellationToken cancellationToken = default)
        {
            try
            {
                await _workloadService.AddWorkloadAsync(teacherId, disciplineId, lessonType, hours, cancellationToken);
                return Ok("The Workload was Added Succesfully!.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error catched while Adding Workload : {ex.Message}");
            }
        }
        [HttpPut("ChangeWorkload/{workloadId}")]
        public async Task<IActionResult> ChangeWorkloadAsync(int workloadId, int teacherId, int disciplineId, string lessonType, int hours, CancellationToken cancellationToken=default)
        {
            try
            {
                await _workloadService.ChangeWorkloadAsync(workloadId, teacherId, disciplineId, lessonType, hours, cancellationToken);
                return Ok("The Workload has been successfully Changed!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error catched while Changing Workload: {ex.Message}");
            }
        }
        [HttpDelete("RemoveWorkload/{workloadId}")]
        public async Task<IActionResult> SoftDeleteWorkloadAsync(int workloadId, CancellationToken cancellationToken = default)
        {
            try
            {
                await _workloadService.SoftDeleteWorkloadAsync(workloadId, cancellationToken);
                return Ok("The Workload has been successfully Removed!!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error catched while Removing Workload: {ex.Message}");
            }
        }

    }
}
