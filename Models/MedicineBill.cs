using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AsterMimsWebApplication2022.Models
{
    public partial class MedicineBill
    {
        public int MedicineBillId { get; set; }
        public int? AppointmentId { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        public int? MedicinePrescId { get; set; }
        public string MedicineBillAmount { get; set; }
        public DateTime? MedicineBillDate { get; set; }

        public virtual Appointment Appointment { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual MedicinePrescription MedicinePresc { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
