using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TimeManager.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Ad Soyad")]
        public string FullName { get; set; }
        public ICollection<Task> Tasks { get; set; }
        public ICollection<TimeSpending> TimeSpendings { get; set; }
        public decimal TotalTimeSpent { get { return TimeSpendings.Sum(s => s.TimeSpent); } }
        public int TaskCount { get { return Tasks.Count(); } }
        public int CompletedTaskCount { get { return Tasks.Where(t=>t.Status == Status.Completed).Count(); } }
    }
}
