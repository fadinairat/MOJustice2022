using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOE.Models
{
    public class AdminLog
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("User Name")]
        [ForeignKey("User")]
        [Required]
        public Nullable<int> UserId { get; set; } = null;
        public virtual User? User { get; set; }

        [ForeignKey("AdminLogAction")]
        [DisplayName("Action")]
        [Required]
        public int ActionId { get; set; }

        [ForeignKey("AdminLogFor")]
        [Required]
        public Nullable<int> LogFor { get; set; }
        public virtual AdminLogFor? AdminLogFor { get; set; }

        [StringLength(50)]
        [DisplayName("Log Title")]
        public string? LogTitle { get; set; } = String.Empty;

        [DisplayName("Log Details")]
        [StringLength(250)]
        public string? LogDetails { get; set; } = String.Empty;

        public int ItemId { get; set; }

        [DisplayName("Log Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime LogDate { get; set; } = DateTime.Now;

        [DisplayName("IP Address")]
        [StringLength(15)]
        public string IpAddress { get; set; } = String.Empty;
    }
}
