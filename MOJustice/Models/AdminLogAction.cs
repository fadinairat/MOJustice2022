using System.ComponentModel.DataAnnotations;

namespace MOE.Models
{
    public class AdminLogAction
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Title { get; set; } = String.Empty;

        [StringLength(50)]
        public string ArTitle { get; set; } = String.Empty;

        public virtual ICollection<AdminLog> AdminLogs { get; set; }

    }
}
