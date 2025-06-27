using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity;

namespace dao
{
    public interface IHospitalService
    {

        Appointment GetAppointment(int AppointmentId);
        List<Appointment> GetAppointmentForPatients(int PatientId);
        List<Appointment> GetAppointmentForDoctors(int DoctorId);
        Boolean ScheduleAppointment(Appointment appointment);
        Boolean UpdateAppointment(Appointment appointment);
        Boolean CancelAppointment(int appointmentId);
    }
}
