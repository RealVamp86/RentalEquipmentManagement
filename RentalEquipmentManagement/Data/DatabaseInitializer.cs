using System.Data.Entity;
using System.Data.Entity.Migrations;
using RentalEquipmentManagement.Models;

namespace RentalEquipmentManagement.Data
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<RentalDbContext>
    {
        protected override void Seed(RentalDbContext context)
        {
            // Добавление начальных данных для Users
            context.Users.AddOrUpdate(
                u => u.Name,
                new User { Name = "Admin", Role = "Manager" },
                new User { Name = "User1", Role = "Renter" },
                new User { Name = "User2", Role = "Lessor" }
            );

            // Добавление начальных данных для Equipment
            context.Equipment.AddOrUpdate(
                e => e.Name,
                new Equipment { Name = "Drill", Category = "Tools", Description = "A powerful drill", Cost = 50.00m },
                new Equipment { Name = "Saw", Category = "Tools", Description = "A sharp saw", Cost = 70.00m },
                new Equipment { Name = "Hammer", Category = "Tools", Description = "A sturdy hammer", Cost = 20.00m }
            );

            // Добавление начальных данных для Rentals
            context.Rentals.AddOrUpdate(
                r => r.Id,
                new Rental { UserId = 1, EquipmentId = 1, RentalDate = System.DateTime.Now, ReturnDate = System.DateTime.Now.AddDays(5) },
                new Rental { UserId = 2, EquipmentId = 2, RentalDate = System.DateTime.Now, ReturnDate = System.DateTime.Now.AddDays(3) }
            );

            // Добавление начальных данных для Notifications
            context.Notifications.AddOrUpdate(
                n => n.Id,
                new Notification { UserId = 1, Message = "Your rental is due soon.", Date = System.DateTime.Now },
                new Notification { UserId = 2, Message = "Your equipment is overdue.", Date = System.DateTime.Now }
            );

            // Добавление начальных данных для FinancialReports
            context.FinancialReports.AddOrUpdate(
                f => f.Id,
                new FinancialReport { Date = System.DateTime.Now, Income = 150.00m, EquipmentUsage = "Drill, Saw" }
            );

            context.SaveChanges();

            base.Seed(context);
        }
    }
}




