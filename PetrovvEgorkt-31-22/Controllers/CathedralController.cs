using Microsoft.AspNetCore.Mvc;
using PetrovvEgorkt_31_22.Interfaces;


namespace PetrovvEgorkt_31_22.Controllers
{
    public class CathedralController : ControllerBase
    {
        private readonly ILogger<CathedralController> _logger;
        private readonly ICathedralService _cathedralService;

        public CathedralController(ILogger<CathedralController> logger, ICathedralService cathedralService)
        {
            _logger = logger;
            _cathedralService = cathedralService;
        }

        [HttpGet("GetCathedrals")]
        public async Task<IActionResult> GetCathedralsAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var cathedral = await _cathedralService.GetCathedralsAsync(cancellationToken);
                return Ok(cathedral);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error catched while Getting Cathedral: {ex.Message}");
            }

        }
        [HttpPost("AddCathedral")]
        public async Task<IActionResult> AddCathedralAsync(string cathedralName, int headTeacherID, CancellationToken cancellationToken = default)
        {
            try
            {
                await _cathedralService.AddCathedralAsync(cathedralName, headTeacherID, cancellationToken);
                return Ok("The Cathedral was Added Succesfully!.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error catched while Adding Cathedral : {ex.Message}");
            }
        }
        [HttpPut("ChangeCathedral/{cathedralId}")]
        public async Task<IActionResult> ChangeCathedralAsync(int cathedralId, string newCathedralName, int headTeacherID, CancellationToken cancellationToken = default)
        {
            try
            {
                await _cathedralService.ChangeCathedralAsync(cathedralId, newCathedralName, headTeacherID, cancellationToken);
                return Ok("The Cathedral has been successfully Changed!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error catched while Changing Cathedral: {ex.Message}");
            }
        }
        [HttpDelete("RemoveCathedral/{cathedralId}")]
        public async Task<IActionResult> RemoveCathedralAsync(int cathedralId, CancellationToken cancellationToken = default)
        {
            try
            {
                
                await _cathedralService.SoftDeleteCathedralAsync(cathedralId, cancellationToken);
                return Ok("The Cathedral has been successfully removed!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error occurred while removing Cathedral: {ex.Message}");
            }
        }

    }

}
