using System.ComponentModel.DataAnnotations;

namespace Vue2SpaSignalR.Models
{
    public class Employee
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
