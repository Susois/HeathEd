using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeathEdAPI.Models
{
    [Table("Modules")]
    public class Module
    {
        [Key]
        public int ModuleID { get; set; }

        [Required]
        [StringLength(20)]
        public string ModuleCode { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string ModuleName { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        public int LecturerID { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [ForeignKey("LecturerID")]
        public virtual User? Lecturer { get; set; }

        public virtual ICollection<StudentModule> StudentModules { get; set; } = new List<StudentModule>();
        public virtual ICollection<CaseStudy> CaseStudies { get; set; } = new List<CaseStudy>();
    }
}
