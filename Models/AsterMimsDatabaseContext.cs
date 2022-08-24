using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AsterMimsWebApplication2022.Models
{
    public partial class AsterMimsDatabaseContext : DbContext
    {
        public AsterMimsDatabaseContext()
        {
        }

        public AsterMimsDatabaseContext(DbContextOptions<AsterMimsDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointment { get; set; }
        public virtual DbSet<AppointmentBill> AppointmentBill { get; set; }
        public virtual DbSet<BloodGroup> BloodGroup { get; set; }
        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<LabTest> LabTest { get; set; }
        public virtual DbSet<LabTestBill> LabTestBill { get; set; }
        public virtual DbSet<LabTestPrescription> LabTestPrescription { get; set; }
        public virtual DbSet<LabTestReport> LabTestReport { get; set; }
        public virtual DbSet<Medicine> Medicine { get; set; }
        public virtual DbSet<MedicineBill> MedicineBill { get; set; }
        public virtual DbSet<MedicinePrescription> MedicinePrescription { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Specialization> Specialization { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<TreatmentHistoryTable> TreatmentHistoryTable { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
////#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
////                optionsBuilder.UseSqlServer("Server = LAPTOP-MH8KP4CK\\SQLEXPRESS;Database=AsterMimsDatabase;Trusted_Connection=True;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.Property(e => e.AppointmentDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Appointment)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__Appointme__Docto__4CA06362");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Appointment)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__Appointme__Patie__4BAC3F29");

                entity.HasOne(d => d.Specialization)
                    .WithMany(p => p.Appointment)
                    .HasForeignKey(d => d.SpecializationId)
                    .HasConstraintName("FK__Appointme__Speci__4D94879B");
            });

            modelBuilder.Entity<AppointmentBill>(entity =>
            {
                entity.Property(e => e.AppointmentBillAmount)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AppointmentBillDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.AppointmentBill)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("FK__Appointme__Appoi__6C190EBB");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.AppointmentBill)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__Appointme__Docto__6E01572D");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.AppointmentBill)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__Appointme__Patie__6D0D32F4");
            });

            modelBuilder.Entity<BloodGroup>(entity =>
            {
                entity.Property(e => e.BloodGroupName)
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.Property(e => e.ConsultationFees)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Specialization)
                    .WithMany(p => p.Doctor)
                    .HasForeignKey(d => d.SpecializationId)
                    .HasConstraintName("FK__Doctor__Speciali__4222D4EF");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Doctor)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK__Doctor__StaffId__412EB0B6");
            });

            modelBuilder.Entity<LabTest>(entity =>
            {
                entity.Property(e => e.LabTestCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LabTestName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LabTestPrice)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LabTestBill>(entity =>
            {
                entity.Property(e => e.LabTestBillAmount)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LabTestBillDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.LabTestBill)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("FK__LabTestBi__Appoi__71D1E811");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.LabTestBill)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__LabTestBi__Docto__73BA3083");

                entity.HasOne(d => d.LabPresc)
                    .WithMany(p => p.LabTestBill)
                    .HasForeignKey(d => d.LabPrescId)
                    .HasConstraintName("FK__LabTestBi__LabPr__74AE54BC");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.LabTestBill)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__LabTestBi__Patie__72C60C4A");
            });

            modelBuilder.Entity<LabTestPrescription>(entity =>
            {
                entity.HasKey(e => e.LabPrescId)
                    .HasName("PK__LabTestP__8E0F6263C5ABCBFC");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.LabTestPrescription)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("FK__LabTestPr__Appoi__5BE2A6F2");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.LabTestPrescription)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__LabTestPr__Docto__5CD6CB2B");

                entity.HasOne(d => d.LabTest)
                    .WithMany(p => p.LabTestPrescription)
                    .HasForeignKey(d => d.LabTestId)
                    .HasConstraintName("FK__LabTestPr__LabTe__59FA5E80");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.LabTestPrescription)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__LabTestPr__Patie__5AEE82B9");
            });

            modelBuilder.Entity<LabTestReport>(entity =>
            {
                entity.Property(e => e.HighRange)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LabTestReportPrice)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LabTestReportRemark)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LowRange)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.LabTestReport)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__LabTestRe__Docto__619B8048");

                entity.HasOne(d => d.LabPresc)
                    .WithMany(p => p.LabTestReport)
                    .HasForeignKey(d => d.LabPrescId)
                    .HasConstraintName("FK__LabTestRe__LabPr__60A75C0F");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.LabTestReport)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__LabTestRe__Patie__5FB337D6");
            });

            modelBuilder.Entity<Medicine>(entity =>
            {
                entity.Property(e => e.CompanyName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GenericName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MedicineName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MedicinePrice)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MedicineBill>(entity =>
            {
                entity.Property(e => e.MedicineBillAmount)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MedicineBillDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.MedicineBill)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("FK__MedicineB__Appoi__787EE5A0");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.MedicineBill)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__MedicineB__Docto__7A672E12");

                entity.HasOne(d => d.MedicinePresc)
                    .WithMany(p => p.MedicineBill)
                    .HasForeignKey(d => d.MedicinePrescId)
                    .HasConstraintName("FK__MedicineB__Medic__7B5B524B");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.MedicineBill)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__MedicineB__Patie__797309D9");
            });

            modelBuilder.Entity<MedicinePrescription>(entity =>
            {
                entity.HasKey(e => e.MedicinePrescId)
                    .HasName("PK__Medicine__12B0A476EF84C123");

                entity.Property(e => e.Dosage)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoOfDays)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.MedicinePrescription)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("FK__MedicineP__Appoi__5629CD9C");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.MedicinePrescription)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__MedicineP__Docto__571DF1D5");

                entity.HasOne(d => d.Medicine)
                    .WithMany(p => p.MedicinePrescription)
                    .HasForeignKey(d => d.MedicineId)
                    .HasConstraintName("FK__MedicineP__Medic__5441852A");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.MedicinePrescription)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__MedicineP__Patie__5535A963");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.PatientAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PatientCreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PatientDob).HasColumnType("date");

                entity.Property(e => e.PatientFullName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PatientGender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PatientMobileNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.BloodGroup)
                    .WithMany(p => p.Patient)
                    .HasForeignKey(d => d.BloodGroupId)
                    .HasConstraintName("FK__Patient__BloodGr__47DBAE45");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Specialization>(entity =>
            {
                entity.Property(e => e.SpecializationName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.Property(e => e.StaffAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StaffCreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StaffDesignation)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StaffDob).HasColumnType("date");

                entity.Property(e => e.StaffFullName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StaffGender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StaffMobileNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TreatmentHistoryTable>(entity =>
            {
                entity.HasKey(e => e.TreatmentHistoryId)
                    .HasName("PK__Treatmen__DEF805EACECC7EC1");

                entity.Property(e => e.Diagnosis)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TreatmentHistoryCreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TreatmentHistoryNote)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.TreatmentHistoryTable)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__Treatment__Docto__66603565");

                entity.HasOne(d => d.LabPresc)
                    .WithMany(p => p.TreatmentHistoryTable)
                    .HasForeignKey(d => d.LabPrescId)
                    .HasConstraintName("FK__Treatment__LabPr__6754599E");

                entity.HasOne(d => d.MedicinePresc)
                    .WithMany(p => p.TreatmentHistoryTable)
                    .HasForeignKey(d => d.MedicinePrescId)
                    .HasConstraintName("FK__Treatment__Medic__68487DD7");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.TreatmentHistoryTable)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__Treatment__Treat__656C112C");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__User__RoleId__3C69FB99");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK__User__StaffId__3B75D760");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
