using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AsterMimsWebApplication2022.Models
{
    public partial class Patient
    {
        public Patient()
        {
            Appointment = new HashSet<Appointment>();
            AppointmentBill = new HashSet<AppointmentBill>();
            LabTestBill = new HashSet<LabTestBill>();
            LabTestPrescription = new HashSet<LabTestPrescription>();
            LabTestReport = new HashSet<LabTestReport>();
            MedicineBill = new HashSet<MedicineBill>();
            MedicinePrescription = new HashSet<MedicinePrescription>();
            TreatmentHistoryTable = new HashSet<TreatmentHistoryTable>();
        }

        public int PatientId { get; set; }
        public string PatientFullName { get; set; }
        public string PatientGender { get; set; }
        public DateTime? PatientDob { get; set; }
        public string PatientMobileNumber { get; set; }
        public string PatientAddress { get; set; }
        public DateTime? PatientCreatedDate { get; set; }
        public bool? PatientIsActive { get; set; }
        public int? BloodGroupId { get; set; }

        public virtual BloodGroup BloodGroup { get; set; }
        public virtual ICollection<Appointment> Appointment { get; set; }
        public virtual ICollection<AppointmentBill> AppointmentBill { get; set; }
        public virtual ICollection<LabTestBill> LabTestBill { get; set; }
        public virtual ICollection<LabTestPrescription> LabTestPrescription { get; set; }
        public virtual ICollection<LabTestReport> LabTestReport { get; set; }
        public virtual ICollection<MedicineBill> MedicineBill { get; set; }
        public virtual ICollection<MedicinePrescription> MedicinePrescription { get; set; }
        public virtual ICollection<TreatmentHistoryTable> TreatmentHistoryTable { get; set; }
    }
}
