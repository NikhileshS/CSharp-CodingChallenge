using entity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using util;
using exceptions;

namespace dao
{
    public class IHospitalServiceImp : IHospitalService
    {
        public Appointment GetAppointment(int Id)
        {
            SqlConnection con = Databaseconnection.connectionobj();
            string command = "Select * from Appointment where appointmentId = @id";

            SqlCommand cmd = new SqlCommand(command, con);

            con.Open();
            cmd.Parameters.AddWithValue("@id",Id);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                Appointment appointment = new Appointment();
                appointment.AppointmentId = Convert.ToInt32(reader["appointmentId"]);
                appointment.PatientId = Convert.ToInt32(reader["patientId"]);
                appointment.doctorId = Convert.ToInt32(reader["doctorId"]);
                appointment.description = Convert.ToString(reader["description"]);
                appointment.appointmentDate = Convert.ToDateTime(reader["appointmentDate"]);
                reader.Close();
                con.Close();
                return appointment;
            }
              
            else
            {
                reader.Close();
                con.Close();
                throw new AppointmentNotFoundException();
            }
        }
        public List<Appointment> GetAppointmentForPatients(int PatientId)
        {
            SqlConnection con = Databaseconnection.connectionobj();
            string command = "Select * from Appointment where patientId = @id";

            SqlCommand cmd = new SqlCommand(command, con);

            con.Open(); 
            cmd.Parameters.AddWithValue("@id",PatientId);
            SqlDataReader reader = cmd.ExecuteReader();
            
                List<Appointment> list = CreateAppointmentList(reader);
                con.Close();
            if (list.Count == 0)
            {
                throw new PatientNumberNotFoundException();
            }
            else
            {
                return list;
            }
        }

        public List<Appointment> GetAppointmentForDoctors(int DoctorId)
        {
            SqlConnection con = Databaseconnection.connectionobj();
            string command = "Select * from Appointment where doctorId = @id";

            SqlCommand cmd = new SqlCommand(command, con);
            con.Open();
            cmd.Parameters.AddWithValue("@id",DoctorId);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Appointment> list = CreateAppointmentList(reader);
            con.Close();
            if(list.Count == 0)
            {
                throw new DoctorNotFoundException();
            }
            else
            {
                return list;
            }
        }

        public Boolean ScheduleAppointment(Appointment appointment)
        {
            SqlConnection con = Databaseconnection.connectionobj();
            string command = "Insert into Appointment (patientId, doctorId, appointmentDate, description) values(@patientId, @doctorId, @appointmentDate, @description)";
            SqlCommand cmd = new SqlCommand(command, con);
            appointmentfunc(cmd,con,appointment);
            return true;
        }

        public Boolean UpdateAppointment(Appointment appointment)
        {
            SqlConnection con = Databaseconnection.connectionobj();
            string command = "Update Appointment set patientId = @patientId, doctorId = @doctorId, appointmentDate = @appointmentDate, description = @description where appointmentId = @appointmentId";
            SqlCommand cmd = new SqlCommand(command, con);
            cmd.Parameters.AddWithValue("@appointmentId",appointment.AppointmentId);
            appointmentfunc(cmd, con, appointment);
            return true;
        }

        public Boolean CancelAppointment(int appointmentId)
        {
            SqlConnection con = Databaseconnection.connectionobj();
            string command = "Delete from Appointment where appointmentId = @appointmentId";
            SqlCommand cmd = new SqlCommand(command, con);
            con.Open();
            cmd.Parameters.AddWithValue("@appointmentId",appointmentId);
            cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }

        private void appointmentfunc(SqlCommand cmd,SqlConnection con, Appointment appointment)
        {
            con.Open();
            cmd.Parameters.AddWithValue("@patientId", appointment.PatientId);
            cmd.Parameters.AddWithValue("@doctorId", appointment.doctorId);
            cmd.Parameters.AddWithValue("@appointmentDate", appointment.appointmentDate);
            cmd.Parameters.AddWithValue("@description", appointment.description);
            int rows = cmd.ExecuteNonQuery();
            if(rows == 0)
            {
                throw new AppointmentNotFoundException();
            }
            con.Close();
        }

        private List<Appointment> CreateAppointmentList(SqlDataReader reader)
        {
            List<Appointment> list = new List<Appointment>();
            while (reader.Read())
            {
                list.Add(new Appointment()
                {
                    AppointmentId = Convert.ToInt32(reader["appointmentId"]),
                    PatientId = Convert.ToInt32(reader["patientId"]),
                    doctorId = Convert.ToInt32(reader["doctorId"]),
                    description = Convert.ToString(reader["description"]),
                    appointmentDate = Convert.ToDateTime(reader["appointmentDate"]),
                });
            }
            reader.Close();
            return list;
        }




    }
}
