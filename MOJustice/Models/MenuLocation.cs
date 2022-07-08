using System.ComponentModel.DataAnnotations;

namespace MOE.Models
{
    public class MenuLocation
    {
        [Key]
        public int Id { get; set; }

        [StringLength(25)]
        public string Title { get; set; } = String.Empty;

        public string ArTitle { get; set; } = String.Empty;

        public virtual ICollection<Menu> Menus { get; set; }
    }
}
