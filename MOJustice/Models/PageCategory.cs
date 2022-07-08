using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOE.Models
{
    public class PageCategory
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Language")]
        [Required]
        public Nullable<int> LangId { get; set; } = 0;

        public virtual Language? Language { get; set; } 

        [ForeignKey("Page")]
        [Required]
        public Nullable<int> PageId { get; set; }

        public virtual Page? Page { get; set; }

        [ForeignKey("Category")]
        [Required]
        public int CategoryId { get; set; }

        public virtual Category? Category { get; set; } 


    }
}
