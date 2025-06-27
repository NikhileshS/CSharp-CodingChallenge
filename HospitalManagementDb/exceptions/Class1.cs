using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exceptions
{
    public class PatientNumberNotFoundException : Exception
    {
        public PatientNumberNotFoundException() : base("Patient Id Not Found") { }
    }
    public class AppointmentNotFoundException : Exception 
    { 
        public AppointmentNotFoundException() : base("Appointment Id Not Found") { }
    }
    public class DoctorNotFoundException : Exception
    {
        public DoctorNotFoundException() : base("Doctor Id Not Found") { }
    }
}
