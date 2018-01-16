using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimeManager.Models
{
    public class Project
    {
        public Project()
        {
            CreateDate = DateTime.Now;
            Tasks = new HashSet<Task>();
            TimeSpendings = new HashSet<TimeSpending>();
        }
        public int Id { get; set; }
        [Required]
        [Display(Name="Proje Adı")]
        public string Name { get; set; }
        [Display(Name="Açıklama")]
        public string Description { get; set; }
        [Display(Name = "Yöneticiler")]
        public string Managers { get; set; }
        [Display(Name = "İş Analistleri")]
        public string BussinessAnalyists { get; set; }
        [Display(Name = "Geliştiriciler")]
        public string Developers { get; set; }
        [Display(Name = "Başlangıç Tarihi")]
        public DateTime? StartDate { get; set; }
        [Display(Name="Durum")]
        public Status Status { get; set; }
        public ICollection<Task> Tasks { get; set; }
        public ICollection<TimeSpending> TimeSpendings { get; set; }
        [Display(Name = "Oluşturulma Tarihi")]
        public DateTime CreateDate { get; set; }
        public decimal TotalTimeSpent { get { return TimeSpendings.Sum(s => s.TimeSpent); } }
    }
}
