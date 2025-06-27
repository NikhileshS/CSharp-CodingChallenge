using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dao;
using entity;
using exceptions;

namespace HospitalManagementDb
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool Case = true;
            IHospitalServiceImp repo = new IHospitalServiceImp();
            while (Case)
            {
                try
                {
                    Console.WriteLine("");
                    Console.WriteLine("---------- Hospital Management ----------");
                    Console.WriteLine("");
                    Console.WriteLine("1.  Get Appointment by Id");
                    Console.WriteLine("2.  Get Appointment by Patients");
                    Console.WriteLine("3.  Get Appointment by Doctors");
                    Console.WriteLine("4.  Schedule Appointment");
                    Console.WriteLine("5.  Update Appointment");
                    Console.WriteLine("6.  Cancel Appointment");
                    Console.WriteLine("7.  Exit Program");
                    Console.WriteLine("");
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine("");
                    Console.WriteLine("Enter Your Choice Please :");
                    int choice = int.Parse(Console.ReadLine());
                    Console.Clear();
                    switch (choice)
                    {
                        case 1:
                            {
                                Console.WriteLine("---- Getting Appointment by ID ----");
                                Console.WriteLine("Please Enter Your Appointment ID :");
                                int id = int.Parse(Console.ReadLine());
                                Appointment appointment = repo.GetAppointment(id);
                                Console.WriteLine($"{appointment.AppointmentId}  |  {appointment.PatientId}  |  {appointment.doctorId}  |  {appointment.appointmentDate}  |  {appointment.description}  |");
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine("---- Getting Appointment by Patient ID ----");
                                Console.WriteLine("Please Enter Your Patient Id :");
                                int id = int.Parse(Console.ReadLine());
                                List<Appointment> appointmentList = repo.GetAppointmentForPatients(id);
                                foreach (Appointment appointment in appointmentList)
                                {
                                    Console.WriteLine($"{appointment.AppointmentId}  |  {appointment.PatientId}  |  {appointment.doctorId}  |  {appointment.appointmentDate}  |  {appointment.description}  |");
                                }
                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine("---- Getting Appointment by Doctor ID ----");
                                Console.WriteLine("Please Enter Your Doctor Id :");
                                int id = int.Parse(Console.ReadLine());
                                List<Appointment> appointmentList = repo.GetAppointmentForDoctors(id);
                                foreach (Appointment appointment in appointmentList)
                                {
                                    Console.WriteLine($"{appointment.AppointmentId}  |  {appointment.PatientId}  |  {appointment.doctorId}  |  {appointment.appointmentDate}  |  {appointment.description}  |");
                                }
                                break;
                            }
                        case 4:
                            {
                                Console.WriteLine("---- Creating a Scedule ----");
                                Appointment appointment = new Appointment();
                                Console.WriteLine("Please Enter Your Patient Id : ");
                                appointment.PatientId = int.Parse(Console.ReadLine());
                                Console.WriteLine("Please Enter Your Doctor Id : ");
                                appointment.doctorId = int.Parse(Console.ReadLine());
                                appointment.appointmentDate = DateTime.Now;
                                Console.WriteLine("Please Enter Your Description : ");
                                appointment.description = Console.ReadLine();
                                bool value = repo.ScheduleAppointment(appointment);
                                if (value != true)
                                {
                                    throw new Exception();
                                }
                                break;
                            }
                        case 5:
                            {
                                Console.WriteLine("---- Updating the Appointment ----");
                                Appointment appointment = new Appointment();
                                Console.WriteLine("Please Enter Your Appointment Id : ");
                                appointment.AppointmentId = int.Parse(Console.ReadLine());
                                Console.WriteLine("Please Enter Your Patient Id : ");
                                appointment.PatientId = int.Parse(Console.ReadLine());
                                Console.WriteLine("Please Enter Your Doctor Id : ");
                                appointment.doctorId = int.Parse(Console.ReadLine());
                                Console.WriteLine("Please Enter Appointment Date : ( Format - MM/DD/YYYY )");
                                appointment.appointmentDate = DateTime.Parse(Console.ReadLine());
                                Console.WriteLine("Please Enter Appointment Description : ");
                                appointment.description = Console.ReadLine();
                                bool value = repo.UpdateAppointment(appointment);
                                if (value != true)
                                {
                                    throw new Exception();
                                }
                                break;
                            }
                        case 6:
                            {
                                Console.WriteLine("---- Cancelling the Scedule ----");
                                Console.WriteLine("Please Enter Your Appointment ID :");
                                int id = int.Parse(Console.ReadLine());
                                bool value = repo.CancelAppointment(id);
                                if (value != true) { throw new Exception(); }
                                break;
                            }
                        case 7:
                            {
                                Console.WriteLine("---- Exiting the Program ----");
                                Console.WriteLine("---- Thank you for using ----");
                                Case = false;
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Please Enter the value in Range 1-7");
                                break;
                            }

                    }
                }

                catch (AppointmentNotFoundException ex)
                {
                    Console.WriteLine("Appointment Error : " + ex.Message);
                }
                catch (PatientNumberNotFoundException ex)
                {
                    Console.WriteLine("Patient Error : " + ex.Message);
                }
                catch (DoctorNotFoundException ex)
                {
                    Console.WriteLine("Doctor Error : " + ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Format Error : " + ex.Message);
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Unexpected Error : " + ex.Message);
                }
            }

        }
    }
}

