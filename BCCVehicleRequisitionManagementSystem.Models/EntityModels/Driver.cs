namespace BCCVehicleRequisitionManagementSystem.Models.EntityModels
{
    public class Driver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LicenceNo { get; set; }
        public string NID { get; set; }
        public string Address { get; set; }
        public bool IsDelete { get; set; }
    }
}