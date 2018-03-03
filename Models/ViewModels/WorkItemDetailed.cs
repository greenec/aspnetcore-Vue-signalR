using System.ComponentModel.DataAnnotations;

namespace Vue2SpaSignalR.Models.ViewModels
{
    public class WorkItemDetailed
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        [Display(Name = "Task Name")]
        public string TaskName { get; set; }

        public string Description { get; set; }

        [Display(Name = "Assigned Employee")]
        public string EmployeeName { get; set; }
    }
}
