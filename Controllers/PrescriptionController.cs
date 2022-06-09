using Cwiczenia6_mp_s21108.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cwiczenia6_mp_s21108.Controllers
{
    [Route("api/prescriptions")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly IDbService _dbService;

        public PrescriptionController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        [Route("{idPrescription}")]
        public async Task<IActionResult> GetPrescriptionById(int idPrescription)
        {
            var prescription = await _dbService.GetPrescriptionById(idPrescription);
            return Ok(prescription);
        }
    }
}
