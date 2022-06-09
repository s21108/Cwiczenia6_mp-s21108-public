using Cwiczenia6_mp_s21108.Models;
using Cwiczenia6_mp_s21108.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenia6_mp_s21108.Services
{
    public class DbService : IDbService
    {
        private readonly MainDbContext _dbContext;

        public DbService(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<SomeSortOfDoctor>> GetSomeSortOfDoctors()
        {
            var doctors = await _dbContext.Doctors
                .Select(x => new SomeSortOfDoctor
                {
                    IdDoctor = x.IdDoctor,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email
                }).ToListAsync();
            return doctors;
        }

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            var doctors = await _dbContext.Doctors.ToListAsync();
            return doctors;
        }

        public async Task<Doctor> GetDoctorById(int id)
        {
            var doctors = await GetDoctors();
            var doctor = doctors.FirstOrDefault(x => x.IdDoctor == id);
            if (doctor != null)
                return doctor;
            else throw new Exception("Nie znaleziono doktora o podanym id!");
        }

        public async Task AddDoctor(SomeSortOfDoctor doctor)
        {
            var addDoctor = new Doctor
            {
                IdDoctor = _dbContext.Doctors.Max(x => x.IdDoctor) + 1,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Email = doctor.Email              
            };

            await _dbContext.AddAsync(addDoctor);
            await _dbContext.SaveChangesAsync();
        }

        public async Task ModifyDoctor(int id, SomeSortOfDoctor2 doctor)
        {
            var d = await GetDoctorById(id);
            d.FirstName = doctor.FirstName;
            d.LastName = doctor.LastName;
            d.Email = doctor.Email;
            _dbContext.Doctors.Attach(d);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteDoctor(int id)
        {
            var doctor = await GetDoctorById(id);
            _dbContext.Doctors.Attach(doctor);
            _dbContext.Entry(doctor).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<SomeSortOfPrescription> GetPrescriptionById(int idPrescription)
        {
            var result = await _dbContext.Prescriptions
                .Include(x => x.Prescription_Medicaments)
                .Where(x => x.IdPrescription == idPrescription)
                .Select(x => new SomeSortOfPrescription
                {
                    IdPrescription = x.IdPrescription,
                    Date = x.Date,
                    DueDate = x.DueDate,
                    Doctor = new SomeSortOfDoctor 
                    {
                      IdDoctor = x.Doctor.IdDoctor,
                      FirstName = x.Doctor.FirstName,
                      LastName = x.Doctor.LastName,
                      Email = x.Doctor.Email                 
                    },
                    Patient = new SomeSortOfPatient 
                    { 
                        IdPatient = x.Patient.IdPatient,
                        FirstName = x.Patient.FirstName,
                        LastName = x.Patient.LastName,
                        Birthdate = x.Patient.Birthdate
                    },
                    Medicaments = x.Prescription_Medicaments.Select(x => new  SomeSortOfMedicament{
                        IdMedicament = x.Medicament.IdMedicament,
                        Name = x.Medicament.Name,
                        Description = x.Medicament.Description,
                        Type = x.Medicament.Type
                    })
                }).FirstAsync();
            return result;
        }
        
    }
}
