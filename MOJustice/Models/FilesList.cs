using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOE.Models
{
    public class FilesList
    {

        [Key]
        public int Id { get; set; }

        [ForeignKey("Files")]
        [Required]
        public int FileId { get; set; }
        public virtual Files? Files { get; set; }

        [StringLength(250)]
        public string? FilePath { get; set; } = String.Empty;

        public byte Deleted { get; set; } = 0;
    }
}
