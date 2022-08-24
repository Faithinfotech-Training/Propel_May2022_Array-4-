using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AsterMimsWebApplication2022.Models
{
    public partial class LabTestPrescription
    {
        public LabTestPrescription()
        {
            LabTestBill = new HashSet<LabTestBill>();
            LabTestReport = new HashSet<LabTestReport>();
            TreatmentHistoryTable = new HashSet<TreatmentHistoryTable>();
        }

        public int LabPrescId { get; set; }
        public int? LabTestId { get; set; }
        public int? PatientId { get; set; }
        public int? AppointmentId { get; set; }
        public int? DoctorId { get; set; }

        public virtual Appointment Appointment { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual LabTest LabTest { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual ICollection<LabTestBill> LabTestBill { get; set; }
        public virtual ICollection<LabTestReport> LabTestReport { get; set; }
        public virtual ICollection<TreatmentHistoryTable> TreatmentHistoryTable { get; set; }
    }
}
