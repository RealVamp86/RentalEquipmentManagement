using System.Data.Entity;
using RentalEquipmentManagement.Models;

namespace RentalEquipmentManagement.Data
{
    public class RentalDbContext : DbContext
    {
        public RentalDbContext() : base("name=RentalDbContext")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<FinancialReport> FinancialReports { get; set; }
    }
}
