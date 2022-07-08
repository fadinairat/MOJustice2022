using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOE.Models
{
    public class Menu
    {

        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; } = String.Empty;

        [ForeignKey("MenuLocation")]
        [DisplayName("Menu Location")]
        [Required]
        public Nullable<int> LocationId { get; set; }
        public virtual MenuLocation? MenuLocation { get; set; }


        [StringLength(50)]
        public string Target { get; set; } = String.Empty;

        [ForeignKey("MenuParentRef")]
        [DisplayName("Menu Parent")]
        public int? ParentId { get; set; } = 0;
        public virtual Menu? MenuParentRef { get; set; }
         

        public int Priority { get; set; } = 999999;

        [StringLength(250)]
        public string Link { get; set; }

        [ForeignKey("Language")]
        [DisplayName("Language")]
        public int LangId { get; set; }
        public virtual Language? Language { get; set; }
        
        public byte Active { get; set; } = 1;

        [ForeignKey("User")]
        public int? UserId { get; set; } = null;
        public virtual User? User { get; set; }
        public byte Deleted { get; set; } = 0;

        public virtual ICollection<Menu>? ParentMenus { get; set; }
    }
}
