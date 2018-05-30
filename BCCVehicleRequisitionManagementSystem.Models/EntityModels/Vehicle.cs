namespace BCCVehicleRequisitionManagementSystem.Models.EntityModels
{
    public class Vehicle
    {
        public int Id { get; set; }
        public byte VehicleTypeId { get; set; }
        public VehicleType VehicleType { get; set; }
        public string RegistrationNo { get; set; }
        public string Description { get; set; }
        public bool IsDelete { get; set; }
    }
}