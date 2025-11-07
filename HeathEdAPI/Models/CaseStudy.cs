using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeathEdAPI.Models
{
    [Table("CaseStudies")]
    public class CaseStudy
    {
        [Key]
        public int CaseID { get; set; }

        [Required]
        [StringLength(200)]
        public string CaseTitle { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string? Symptoms { get; set; }

        public string? Diagnosis { get; set; }

        [Required]
        public int ModuleID { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [ForeignKey("ModuleID")]
        public virtual Module? Module { get; set; }
    }
}
