using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOE.Models
{
    public class Category
    {
      

        [Key]
        public int Id { get; set; }

        [DisplayName("English Name")]
        [StringLength(250)]
        public string Name { get; set; } = String.Empty;

        [DisplayName("Arabic Name")]
        [StringLength(250)]
        public string ArName { get; set; } = String.Empty;

        [DisplayName("Slug")]
        [StringLength(250)]
        public string? Slug { get; set; } = String.Empty;

        [DisplayName("Thumbnail Image")]
        [StringLength(250)]
        public string? Thumb { get; set; } = String.Empty;

        public int Priority { get; set; } = 999999;

        [DisplayName("Parent Category")]
        public Nullable<int> ParentId { get; set; } = 0;

        [ForeignKey("HtmlTemplate")]
        [DisplayName("Category Template")]
        public int? TemplateId { get; set; } = 0;

        public virtual HtmlTemplate? HtmlTemplate { get; set; }  

        public int ItemsPerPage { get; set; } = 20;

        public Boolean Active { get; set; } = true;

        public Boolean Publish { get; set; } = true;

        [DisplayName("Category Type")]
        [ForeignKey("CategoryTypes")]
        public Nullable<int> TypeId { get; set; }

        public virtual CategoryTypes? CategoryTypes { get; set; }

        [DisplayName("English Description")]
        [Column(TypeName = "nvarchar(max)")]
        public string? Description { get; set; } = String.Empty;

        [DisplayName("Arabic Description")]
        [Column(TypeName = "nvarchar(max)")]
        public string? ArDescription { get; set; } = String.Empty;

        [DisplayName("Language")]
        [ForeignKey("Language")]
        public int? LangId { get; set; }

        public virtual Language? Language { get; set; }

        [DisplayName("Show As Main Item")]
        public Boolean ShowAsMain { get; set; } = false;

        [DisplayName("Show in Sitemap")]
        public Boolean ShowInSiteMap { get; set; } = false;

        [DisplayName("Show Description")]
        public Boolean ShowDescription { get; set; } = true;

        [DisplayName("Show Title")]
        public Boolean ShowTitle { get; set; } = true;

        [DisplayName("Show Pages Thumb")]
        public Boolean ShowThumb { get; set; } = true;

        [DisplayName("Show In Path")]
        public Boolean ShowInPath { get; set; } = true;

        [DisplayName("Show In Search")]
        public Boolean ShowInSearch { get; set; } = true;

        [DisplayName("Show Date")]
        public Boolean ShowDate { get; set; } = false;

        [DisplayName("Show In Cat List")]
        public Boolean ShowInCatList { get; set; } = true;

        [ForeignKey("User")]
        public int? UserId { get; set; }
        [NotMapped]
        public virtual User? User { get; set; }

        public byte Deleted { get; set; } = 0;

        public virtual ICollection<Files>? Files1 { get; set; }
        public virtual ICollection<PageCategory>? PageCategories { get; set; }
        //public virtual ICollection<Page> Pages { get; set; }
        
    }
}
