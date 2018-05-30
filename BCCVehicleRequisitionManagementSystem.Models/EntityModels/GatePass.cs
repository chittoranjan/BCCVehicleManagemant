namespace BCCVehicleRequisitionManagementSystem.Models.EntityModels
{
    public class GatePass
    {
        public int Id { get; set; }
        public int DriverVehicleId { get; set; }
        public DriverVehicle DriverVehicle { get; set; }
        public bool CheckStatus { get; set; }
    }
}