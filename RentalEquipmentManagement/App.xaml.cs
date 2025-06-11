using System.Data.Entity;
using System.Windows;
using RentalEquipmentManagement.Data;
using RentalEquipmentManagement.Migrations;
using RentalEquipmentManagement.Views;

namespace RentalEquipmentManagement
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<RentalDbContext, Configuration>());
            using (var context = new RentalDbContext())
            {
                context.Database.Initialize(force: true);
            }

            var loginWindow = new LoginWindow();
            loginWindow.Show();
        }
    }
}




