using System;
using System.Collections.Generic;

namespace Cwiczenia6_mp_s21108.Models.DTO
{
    public class SomeSortOfPrescription
    {
        public int IdPrescription { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public SomeSortOfDoctor Doctor { get; set; }
        public SomeSortOfPatient Patient { get; set; }
        public IEnumerable<SomeSortOfMedicament> Medicaments { get; set; }
    }
}
