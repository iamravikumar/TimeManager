using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TimeManager.Models
{
    public class Task
    {
        public Task()
        {
            CreateDate = DateTime.Now;
            TimeSpendings = new HashSet<TimeSpending>();
        }
        public int Id { get; set; }
        [Required]
        [Display(Name="Görev Adı")]
        public string Name { get; set; }
        [Display(Name="Açıklama")]
        public string Description { get; set; }
        [Display(Name="Atanan")]
        public string AssignedTo { get; set; }
        [Display(Name="Atanan")]
        [ForeignKey("AssignedTo")]
        public ApplicationUser AssignedToUser{ get; set; }
        [Display(Name="Başlangıç Tarihi")]
        public DateTime? StartDate { get; set; }
        [Display(Name="Bitiş Tarihi")]
        public DateTime? EndDate { get; set; }
        [Display(Name="Kategori")]
        public string Category { get; set; }
        [Display(Name="Durum")]
        public Status Status { get; set; }
        [Display(Name="Proje")]
        public int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        [Display(Name="Proje")]
        public Project Project { get; set; }
        public ICollection<TimeSpending> TimeSpendings { get; set; }
        [Display(Name="Oluşturulma Tarihi")]
        public DateTime CreateDate { get; set; }
        public decimal TotalTimeSpent { get { return TimeSpendings.Sum(s => s.TimeSpent); } }
    }
}
