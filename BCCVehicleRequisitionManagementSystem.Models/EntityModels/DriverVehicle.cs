namespace BCCVehicleRequisitionManagementSystem.Models.EntityModels
{
    public class DriverVehicle
    {
        public int Id { get; set; }
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}