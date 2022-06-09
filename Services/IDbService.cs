using Cwiczenia6_mp_s21108.Models;
using Cwiczenia6_mp_s21108.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cwiczenia6_mp_s21108.Services
{
    public interface IDbService
    {
        Task AddDoctor(SomeSortOfDoctor doctor);
        Task DeleteDoctor(int id);
        Task<Doctor> GetDoctorById(int id);
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<SomeSortOfPrescription> GetPrescriptionById(int id);
        Task<IEnumerable<SomeSortOfDoctor>> GetSomeSortOfDoctors();
        Task ModifyDoctor(int id, SomeSortOfDoctor2 doctor);
    }
}
