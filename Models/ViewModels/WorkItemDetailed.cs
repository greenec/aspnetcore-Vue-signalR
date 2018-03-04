using System.ComponentModel.DataAnnotations;

namespace Vue2SpaSignalR.Models.ViewModels
{
    public class WorkItemDetailed
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [Display(Name = "Task Name")]
        public string TaskName { get; set; }

        public string Description { get; set; }

        [Display(Name = "Assigned Employee")]
        public Employee Employee { get; set; }
    }
}
