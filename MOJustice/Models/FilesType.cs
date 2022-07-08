using System.ComponentModel.DataAnnotations;

namespace MOE.Models
{
    public class FilesType
    {
        [Key]
        public int Id { get; set; } 

        [StringLength(25)]
        public string Title { get; set; }

        [StringLength(25)]
        public string ArTitle { get; set; } = String.Empty;

        public virtual ICollection<Files> Files1 { get; set; }
    }
}
