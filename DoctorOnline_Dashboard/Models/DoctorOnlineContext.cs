using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorOnline_Dashboard.Models
{
    public class DoctorOnlineContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
       // public DbSet<Patient_Doctor> Patients_Doctors { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Speciality_Service> Specialities_Services { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<OrderCostFactors> OrderCostFactors { get; set; }
        public DoctorOnlineContext(DbContextOptions options) : base(options) { }
    }
}
