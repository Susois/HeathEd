using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeathEdAPI.Models
{
    [Table("StudentModules")]
    public class StudentModule
    {
        [Key]
        public int StudentModuleID { get; set; }

        [Required]
        public int StudentID { get; set; }

        [Required]
        public int ModuleID { get; set; }

        public DateTime EnrolledDate { get; set; } = DateTime.Now;

        [ForeignKey("StudentID")]
        public virtual User? Student { get; set; }

        [ForeignKey("ModuleID")]
        public virtual Module? Module { get; set; }
    }
}
