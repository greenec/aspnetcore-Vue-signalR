using System.ComponentModel.DataAnnotations;

namespace Vue2SpaSignalR.Models
{
    public class WorkItem
    {
        public int ID { get; set; }

        [Display(Name = "Assigned Employee")]
        public int UserID { get; set; }

        [Display(Name = "Task Name"), Required]
        public string TaskName { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
