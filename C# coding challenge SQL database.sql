Create database hospitalmanagementdb;

use hospitalmanagementdb;

create table Patient(
	patientId  int identity(50,50) primary key,
	firstName nvarchar(100) not null,
	lastName nvarchar(100),
	dateOfBirth date not null,
	gender nvarchar(10) not null check(gender in ('male','female')),
	contactno nvarchar(50),
	address nvarchar(200) not null,
)

create table Doctor(
	doctorId int identity(1,1) primary key,
	firstName nvarchar(50) not null,
	lastName nvarchar(50),
	specialization nvarchar(100) not null,
	contactno nvarchar(50),
)

create table Appointment(
	appointmentId int identity(100,100) primary key,
	patientId int,
	doctorId int,
	appointmentDate date,
	description nvarchar(500),
	foreign key(patientId) references Patient(PatientId),
	foreign key(doctorId) references Doctor(DoctorId)
)


select * from Patient
select * from Doctor
select * from Appointment	

insert into Patient values ('Suresh','Babu','2004/04/27','male','sureshbabu@gmail.com','ramapuram,chennai')
insert into Patient values ('Santhosh',null,'2012/06/21','male','santhosh@gmail.com','Sholinganallur')
insert into Patient values ('Unnathi','Suresh','2008/01/06','female','unnathigowda@gmail.com','Bangalore')
insert into Patient values ('Vaishnavi','Illangovan','2001/05/19','female','vaishu@gmail.com','Koomapatti')

insert into Doctor values ('Nikhilesh','S','General','example@gmail.com')
insert into Doctor values ('Prasanna','Kumar','Ortho','example@gmail.com')
insert into Doctor values ('Ramesh','V','Dentist','example@gmail.com')
insert into Doctor values ('Raghul','S','Physiotherapist','example@gmail.com')

insert into Appointment values (50,1,'2024/04/06','Example description here')
insert into Appointment values (150,1,'2024/04/06','Example description here')
insert into Appointment values (50,2,'2024/04/06','Example description here')
insert into Appointment values (200,4,'2024/04/06','Example description here')