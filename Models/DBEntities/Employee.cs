using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace employeedata.Models.DBEntities
{
    public class Employee    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public DateTime DateofBirth {  get; set; }
        public string Email { get; set; }
        public string Salary { get; set; }

            
   }
}
