using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOE.Models
{
    public class TagRel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Tag")]
        public Nullable<int> TagId { get; set; }

        public virtual Tag? Tag { get; set;  }

        [ForeignKey("Page")]
        public Nullable<int> PageId { get; set; } 

        public virtual Page? Page { get; set;  }

        [ForeignKey("Language")]
        public Nullable<int> LangId { get; set; }

        public virtual Language? Language { get; set;  }
        public int RelType { get; set; } = 1;

        public byte Deleted { get; set; } = 0;
    }
}
