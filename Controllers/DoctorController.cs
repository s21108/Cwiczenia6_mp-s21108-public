using Cwiczenia6_mp_s21108.Models;
using Cwiczenia6_mp_s21108.Models.DTO;
using Cwiczenia6_mp_s21108.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cwiczenia6_mp_s21108.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDbService _dbService;
        public DoctorController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetDoctors()
        {
            var doctors = await _dbService.GetSomeSortOfDoctors();
            return Ok(doctors);
        }

        [HttpGet()]
        [Route("{idDoctor}")]
        public async Task<IActionResult> GetDoctorById(int idDoctor)
        {
            var doctor = await _dbService.GetDoctorById(idDoctor);
            return Ok(doctor);
        }

        [HttpPost]
        [Route("{idDoctor}")]
        public async Task<IActionResult> PostDoctor(int idDoctor,SomeSortOfDoctor2 newDoctor)
        {
            await _dbService.ModifyDoctor(idDoctor, newDoctor);
            return Ok("Poprawnie zmodyfikowano dane");
        }

        [HttpPut]
        public async Task<IActionResult> PutDoctor(SomeSortOfDoctor doctor)
        {
            await _dbService.AddDoctor(doctor);
            return Ok("Poprawnie dodano doktora do bazy danych");
        }

        [HttpDelete]
        [Route("{idDoctor}")]
        public async Task<IActionResult> DeleteDoctor(int idDoctor)
        {
            await _dbService.DeleteDoctor(idDoctor);
            return Ok($"Poprawnie usunięto doktora o id {idDoctor}");
        }
    }
}
