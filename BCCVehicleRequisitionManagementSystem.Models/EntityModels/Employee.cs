namespace BCCVehicleRequisitionManagementSystem.Models.EntityModels
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte EmployeeDesignationId { get; set; }
        public EmployeeDesignation EmployeeDesignation { get; set; }
        public string   Email { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public bool IsDelete { get; set; }
    }
}