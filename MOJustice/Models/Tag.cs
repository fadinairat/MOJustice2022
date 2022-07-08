using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOE.Models
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Tag Name")]
        [StringLength(50)]
        public string Name { get; set; } = String.Empty;

        [DisplayName("Slug")]
        [StringLength(250)]
        public string? Url { get; set; } = String.Empty;

        [ForeignKey("Language")]
        public Nullable<int> LangId { get; set; } = 1;
        public virtual Language? Language { get; set; }

        [ForeignKey("HtmlTemplate")]
        [DisplayName("Template")]
        public Nullable<int> TempId { get; set; }

        public virtual HtmlTemplate? HtmlTemplate { get; set; }

        [DisplayName("Arabic Name")]
        [StringLength(50)]
        public string ArName { get; set; } = String.Empty;

        [StringLength(250)]
        public string? Thumb { get; set; } 

        [ForeignKey("User")]
        public Nullable<int> UserId { get; set; } = null;

        public virtual User? User { get; set; }

        [DisplayName("Items Per Page")]
        public int ItemsPerPage { get; set; } = 20;

        public byte Deleted { get; set; } = 0;

        //public virtual ICollection<TagRel> TagRels { get; set; }
    }
}
