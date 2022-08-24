----------TEAM ARRAY[4]------------------



-----------------DB CREATION-------------
CREATE DATABASE AsterMimsDatabase
-----------------DB CREATION-------------

----------------USE DB-------------------
USE AsterMimsDatabase
----------------USE DB-------------------



----------------ROLE TABLE---------------
CREATE TABLE Role
(
RoleId INT PRIMARY KEY IDENTITY,
RoleName VARCHAR(50)
)

INSERT INTO Role VALUES('Admin'), ('Receptionist'), ('Doctor'), ('Pharmacist'), ('Lab Technician')

SELECT * FROM Role
----------------ROLE TABLE---------------



----------------STAFF TABLE---------------
CREATE TABLE Staff
(
StaffId INT PRIMARY KEY IDENTITY,
StaffFullName VARCHAR(50),
StaffGender VARCHAR(10),
StaffDob DATE,
StaffMobileNumber VARCHAR(10),
StaffDesignation VARCHAR(20),
StaffAddress VARCHAR(50),
StaffCreatedDate DATE DEFAULT GETDATE(),
StaffIsActive BIT
)

INSERT INTO Staff VALUES('Mejo M', 'Male', '10/11/1987', '9658741236', 'Admin', 'Marthandam', default, 'true'),
						('Mathew Sibin', 'Male', '04/05/1990', '8574965874', 'Receptionist', 'Trivandrum', default, 'true'),
						('Vishnu Surendran', 'Male', '04/03/1997', '9544775402', 'Doctor', 'Kannur', default, 'true'),
						('Mejo Mariyadhasan', 'Male', '10/11/1990', '9658741287', 'Pharmacist', 'Chennai', default, 'true'),
						('Stanlin Salomon', 'Male', '01/05/1998', '7896541235', 'Lab Technician', 'Kollam', default, 'true')

SELECT * FROM Staff
----------------STAFF TABLE---------------



----------------USER TABLE---------------
CREATE TABLE [User]
(
UserId INT PRIMARY KEY IDENTITY,
UserName VARCHAR(20),
UserPassword VARCHAR(20),
RoleId INT,
StaffId INT,
FOREIGN KEY(StaffId) REFERENCES Staff(StaffId),
FOREIGN KEY(RoleId) REFERENCES Role(RoleId)
)

INSERT INTO [User] VALUES('Admin', 'Admin@123', 1, 1),
						 ('Receptionist', 'Receptionist@123', 2, 2),
						 ('Doctor', 'Doctor@123', 3, 3),
						 ('Pharmacist', 'Pharmacist@123', 4, 4),
						 ('Labtechnician', 'LabTechnician@123', 5, 5)

SELECT * FROM [User]
----------------USER TABLE---------------



----------------SPECIALIZATION TABLE-----
CREATE TABLE Specialization
(
SpecializationId INT PRIMARY KEY IDENTITY,
SpecializationName VARCHAR(50)
)

SELECT * FROM Specialization
----------------SPECIALIZATION TABLE-----



----------------DOCTOR TABLE-------------
CREATE TABLE Doctor
(
DoctorId INT PRIMARY KEY IDENTITY,
StaffId INT,
SpecializationId INT,
ConsultationFees VARCHAR(10),
FOREIGN KEY(StaffId) REFERENCES Staff(StaffId),
FOREIGN KEY(SpecializationId) REFERENCES Specialization(SpecializationId)
)

SELECT * FROM Doctor
----------------DOCTOR TABLE-------------



----------------BLOOD GROUP TABLE-------------
CREATE TABLE BloodGroup
(
BloodGroupId INT PRIMARY KEY IDENTITY,
BloodGroupName VARCHAR(5)
)

INSERT INTO BloodGroup VALUES('A+'), ('A-'), ('B+'), ('B-'), ('O+'), ('O-'), ('AB+'), ('AB-')

SELECT * FROM BloodGroup
----------------BLOOD GROUP TABLE-------------



----------------PATIENT TABLE-----------------
CREATE TABLE Patient
(
PatientId INT PRIMARY KEY IDENTITY,
PatientFullName VARCHAR(50),
PatientGender VARCHAR(10),
PatientDob DATE,
PatientMobileNumber VARCHAR(10),
PatientAddress VARCHAR(50),
PatientCreatedDate DATE DEFAULT GETDATE(),
PatientIsActive BIT,
BloodGroupId INT,
FOREIGN KEY(BloodGroupId) REFERENCES BloodGroup(BloodGroupId)
)

SELECT * FROM Patient
----------------PATIENT TABLE-----------------



----------------APPOINTMENT TABLE-------------
CREATE TABLE Appointment
(
AppointmentId INT PRIMARY KEY IDENTITY,
PatientId INT,
DoctorId INT,
SpecializationId INT,
AppointmentDate DATE DEFAULT GETDATE(),
TokenNo INT,
FOREIGN KEY(PatientId) REFERENCES Patient(PatientId),
FOREIGN KEY(DoctorId) REFERENCES Doctor(DoctorId),
FOREIGN KEY(SpecializationId) REFERENCES Specialization(SpecializationId)
)

SELECT * FROM Appointment
----------------APPOINTMENT TABLE-------------



----------------MEDICINE TABLE----------------
CREATE TABLE Medicine
(
MedicineId INT PRIMARY KEY IDENTITY,
MedicineName VARCHAR(50),
GenericName VARCHAR(50),
CompanyName VARCHAR(50),
MedicinePrice VARCHAR(10),
MedicineIsActive BIT
)

SELECT * FROM Medicine
----------------MEDICINE TABLE----------------



----------------LAB TEST TABLE--------------------
CREATE TABLE LabTest
(
LabTestId INT PRIMARY KEY IDENTITY,
LabTestCode VARCHAR(50),
LabTestName VARCHAR(50),
LabTestPrice VARCHAR(10),
LabTestIsActive BIT
)

SELECT * FROM LabTest
----------------LAB TEST TABLE--------------------



----------------MEDICINE PRESCRIPTION TABLE-------
CREATE TABLE MedicinePrescription
(
MedicinePrescId INT PRIMARY KEY IDENTITY,
MedicineId INT,
PatientId INT,
AppointmentId INT,
DoctorId INT,
Dosage VARCHAR(50),
NoOfDays VARCHAR(50),
FOREIGN KEY(MedicineId) REFERENCES Medicine(MedicineId),
FOREIGN KEY(PatientId) REFERENCES Patient(PatientId),
FOREIGN KEY(AppointmentId) REFERENCES Appointment(AppointmentId),
FOREIGN KEY(DoctorId) REFERENCES Doctor(DoctorId)
)

SELECT * FROM MedicinePrescription
----------------MEDICINE PRESCRIPTION TABLE-------



----------------LAB TEST PRESCRIPTION TABLE-------
CREATE TABLE LabTestPrescription
(
LabPrescId INT PRIMARY KEY IDENTITY,
LabTestId INT,
PatientId INT,
AppointmentId INT,
DoctorId INT,
FOREIGN KEY(LabTestId) REFERENCES LabTest(LabTestId),
FOREIGN KEY(PatientId) REFERENCES Patient(PatientId),
FOREIGN KEY(AppointmentId) REFERENCES Appointment(AppointmentId),
FOREIGN KEY(DoctorId) REFERENCES Doctor(DoctorId)
)

SELECT * FROM LabTestPrescription
----------------LAB TEST PRESCRIPTION TABLE-------



----------------LAB TEST REPORT TABLE-------------
CREATE TABLE LabTestReport
(
LabTestReportId INT PRIMARY KEY IDENTITY,
PatientId INT,
LabPrescId INT,
DoctorId INT,
LowRange VARCHAR(50),
HighRange VARCHAR(50),
LabTestReportPrice VARCHAR(10),
LabTestReportRemark VARCHAR(50),
FOREIGN KEY(PatientId) REFERENCES Patient(PatientId),
FOREIGN KEY(LabPrescId) REFERENCES LabTestPrescription(LabPrescId),
FOREIGN KEY(DoctorId) REFERENCES Doctor(DoctorId),
)

SELECT * FROM LabTestReport
----------------LAB TEST REPORT TABLE-------------



----------------TREATMENT HISTORY TABLE-------------
CREATE TABLE TreatmentHistoryTable
(
TreatmentHistoryId INT PRIMARY KEY IDENTITY,
PatientId INT,
AppointmentId INT,
DoctorId INT,
LabPrescId INT,
MedicinePrescId INT,
Diagnosis VARCHAR(100),
TreatmentHistoryNote VARCHAR(100),
TreatmentHistoryCreatedDate DATE DEFAULT GETDATE()
FOREIGN KEY(PatientId) REFERENCES Patient(PatientId),
FOREIGN KEY(DoctorId) REFERENCES Doctor(DoctorId),
FOREIGN KEY(LabPrescId) REFERENCES LabTestPrescription(LabPrescId),
FOREIGN KEY(MedicinePrescId) REFERENCES MedicinePrescription(MedicinePrescId)
)

SELECT * FROM TreatmentHistoryTable
----------------TREATMENT HISTORY TABLE-------------



----------------APPOINTMENT BILL TABLE-------------
CREATE TABLE AppointmentBill
(
AppointmentBillId INT PRIMARY KEY IDENTITY,
AppointmentId INT,
PatientId INT,
DoctorId INT,
AppointmentBillAmount VARCHAR(10),
AppointmentBillDate DATE DEFAULT GETDATE(),
FOREIGN KEY(AppointmentId) REFERENCES Appointment(AppointmentId),
FOREIGN KEY(PatientId) REFERENCES Patient(PatientId),
FOREIGN KEY(DoctorId) REFERENCES Doctor(DoctorId)
)

SELECT * FROM AppointmentBill
----------------APPOINTMENT BILL TABLE-------------



----------------LAB TEST BILL TABLE-------------
CREATE TABLE LabTestBill
(
LabTestBillId INT PRIMARY KEY IDENTITY,
AppointmentId INT,
PatientId INT,
DoctorId INT,
LabPrescId INT,
LabTestBillAmount VARCHAR(10),
LabTestBillDate DATE DEFAULT GETDATE(),
FOREIGN KEY(AppointmentId) REFERENCES Appointment(AppointmentId),
FOREIGN KEY(PatientId) REFERENCES Patient(PatientId),
FOREIGN KEY(DoctorId) REFERENCES Doctor(DoctorId),
FOREIGN KEY(LabPrescId) REFERENCES LabTestPrescription(LabPrescId)
)

SELECT * FROM LabTestBill
----------------LAB TEST BILL TABLE-----------------



----------------MEDICINE BILL TABLE-----------------
CREATE TABLE MedicineBill
(
MedicineBillId INT PRIMARY KEY IDENTITY,
AppointmentId INT,
PatientId INT,
DoctorId INT,
MedicinePrescId INT,
MedicineBillAmount VARCHAR(10),
MedicineBillDate DATE DEFAULT GETDATE(),
FOREIGN KEY(AppointmentId) REFERENCES Appointment(AppointmentId),
FOREIGN KEY(PatientId) REFERENCES Patient(PatientId),
FOREIGN KEY(DoctorId) REFERENCES Doctor(DoctorId),
FOREIGN KEY(MedicinePrescId) REFERENCES MedicinePrescription(MedicinePrescId)
)

SELECT * FROM MedicineBill
----------------MEDICINE BILL TABLE-------------------






































































