using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MOE.Models
{
    public class Language
    {
        [Key]
        public int Id { get; set; }

        [DataType("String")]
        public string Name { get; set; } = String.Empty;

        [DisplayName("Arabic Name")]
        public string ArName { get; set; } = String.Empty;

        public byte Active { get; set; } = 1;

        public byte Deleted { get; set; } = 0;

        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<HtmlTemplate> HtmlTemplates { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Files> Files1 { get; set; }
        public virtual ICollection<Page> Pages { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<TagRel> TagRels { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
    }
}
