using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MOE.Models
{
    public class AdminLogFor
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Title")]
        [StringLength(50)]
        public string Title { get; set; } = String.Empty;

        [DisplayName("Arabic Title")]
        [StringLength(50)]
        public string ArTitle { get; set; } = String.Empty;

        public virtual ICollection<AdminLog> AdminLogs { get; set; }

    }
}
