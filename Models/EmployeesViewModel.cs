using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace employeedata.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        
        [DisplayName("FirstName")]
        public string FirstName { get; set; }
        
        [DisplayName("LastName")]
        public string LastName { get; set; }

        [DisplayName("DateofBirth")]
        public DateTime DateofBirth { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }
        
        public string Salary { get; set; }
        [DisplayName("Name")]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }
}
