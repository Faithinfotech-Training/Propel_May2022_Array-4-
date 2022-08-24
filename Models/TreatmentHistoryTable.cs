using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AsterMimsWebApplication2022.Models
{
    public partial class TreatmentHistoryTable
    {
        public int TreatmentHistoryId { get; set; }
        public int? PatientId { get; set; }
        public int? AppointmentId { get; set; }
        public int? DoctorId { get; set; }
        public int? LabPrescId { get; set; }
        public int? MedicinePrescId { get; set; }
        public string Diagnosis { get; set; }
        public string TreatmentHistoryNote { get; set; }
        public DateTime? TreatmentHistoryCreatedDate { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual LabTestPrescription LabPresc { get; set; }
        public virtual MedicinePrescription MedicinePresc { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
