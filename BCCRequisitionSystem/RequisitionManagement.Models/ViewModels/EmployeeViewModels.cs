using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RequisitionManagement.Models.EntityModels;

namespace RequisitionManagement.Models.ViewModels
{
    public class EmployeeViewModels
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DesignationId { get; set; }
        public Designation Designation { get; set; }
        public string Address { get; set; }
        public string Nid { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
    }
}
