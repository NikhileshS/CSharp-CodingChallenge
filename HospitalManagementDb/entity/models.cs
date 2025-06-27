using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity
{
    public class Patient
    {

        public int PatientId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string gender { get; set; }  
        public string contactno { get; set; }  

    }

    public class Doctors
    {
        public int DoctorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string specialization { get; set; }
        public string contactno { get; set; }
    }

    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int doctorId { get; set; }
        public DateTime appointmentDate { get; set; }
        public string description { get; set; }

    }
}
