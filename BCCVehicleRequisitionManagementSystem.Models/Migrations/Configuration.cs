namespace BCCVehicleRequisitionManagementSystem.Models.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BCCVehicleRequisitionManagementSystem.Models.DatabaseContext.VehicleDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "BCCVehicleRequisitionManagementSystem.Models.DatabaseContext.VehicleDbContext";
        }

        protected override void Seed(BCCVehicleRequisitionManagementSystem.Models.DatabaseContext.VehicleDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            
        }
    }
}
