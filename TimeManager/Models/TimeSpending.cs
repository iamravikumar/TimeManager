using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TimeManager.Models
{
    public class TimeSpending
    {
        public TimeSpending()
        {
            CreateDate = DateTime.Now;
        }
        public int Id { get; set; }
        [Required]
        [Display(Name="Ad")]
        public string Name { get; set; }
        [Display(Name="Proje")]
        public int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        [Display(Name="Proje")]
        public Project Project { get; set; }
        [Display(Name="Görev")]
        public int? TaskId { get; set; }
        [ForeignKey("TaskId")]
        [Display(Name="Görev")]
        public Task Task { get; set; }
        [Display(Name="Çalışan")]
        public string Worker { get; set; }
        [Display(Name="Çalışan")]
        [ForeignKey("Worker")]
        public ApplicationUser WorkerUser { get; set; }
        [Display(Name="Harcanan Zaman (Saat)")]
        public decimal TimeSpent { get; set; }
        [Display(Name="Durum")]
        public Status Status { get; set; }
        [Display(Name = "Oluşturulma Tarihi")]
        public DateTime CreateDate { get; set; }

    }
}
