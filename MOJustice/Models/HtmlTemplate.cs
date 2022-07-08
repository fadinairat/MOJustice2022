using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOE.Models
{
    public class HtmlTemplate
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [DisplayName("Template Name")]
        public string Name { get; set; } = String.Empty;

        [DisplayName("Template Arabic Name")]
        [StringLength(50)]
        public string ArName { get; set; } = String.Empty;


        [ForeignKey("HtmlTemplatesType")]
        [DisplayName("Template Type")]
        public int? Type { get; set; } = 0;

        public virtual HtmlTemplatesType? HtmlTemplatesType { get; set; }   

        [StringLength(250)]
        [DisplayName("File Path")]
        public string? FilePath { get; set; } = String.Empty;

        [DisplayName("Language")]
        [ForeignKey("Language")]
        public Nullable<int> LangId { get; set; } = 0;

        public virtual Language? Language { get; set; }

        [DisplayName("Added By")]
        [ForeignKey("User")]
        public Nullable<int> UserId { get; set; } = null;

        public virtual User? User { get; set; }

        public byte Deleted { get; set; } = 0;

        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Page> Pages { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }

    }
}
