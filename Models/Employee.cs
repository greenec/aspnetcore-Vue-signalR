using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vue2SpaSignalR.Models
{
    [Table("Employees")]
    public class Employee
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 2)]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
