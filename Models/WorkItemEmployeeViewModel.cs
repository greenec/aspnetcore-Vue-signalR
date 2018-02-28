using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Vue2SpaSignalR.Models
{
    public class WorkItemEmployeeViewModel
    {
        public int ID;

        [Display(Name = "Assigned Employee")]
        public int UserID { get; set; }

        [Display(Name = "Task Name")]
        public string TaskName { get; set; }

        public string Description { get; set; }

        public SelectList Employees { get; set; }
    }
}
