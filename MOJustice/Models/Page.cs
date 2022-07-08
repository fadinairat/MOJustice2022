using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOE.Models
{
    public class Page
    {       
        [Key]
        public int PageId { get; set; } 

        public int? TranslateId { get; set; }

        [DisplayName("Page Title")]
        [StringLength(500)]
        public string Title { get; set; } = String.Empty;

        [DisplayName("Page Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime PageDate { get; set; }

        [DisplayName("Log Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy HH:mm}")]
        public DateTime AddDate { get; set; } = DateTime.Now;

        [DisplayName("Language")]
        [ForeignKey("Language")]
        public int? LangId { get; set; } = 1;

        public virtual Language? Language { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        [DisplayName("Page Body")]
        public string? Body { get; set; } = String.Empty;

        [StringLength(500)]
        public string? Slug { get; set; } = String.Empty;

        [StringLength(500)]
        public string? Url { get; set; } = String.Empty;

        [DisplayName("Redirect Url")]
        [StringLength(500)]
        public string? RedirectUrl { get; set; } = String.Empty;

        [StringLength(500)]
        public string? Thumb { get; set; } = String.Empty;

        [DisplayName("Internal Thumb")]
        [StringLength(500)]
        public string? Thumb2 { get; set; } = String.Empty;

        [DisplayName("Show Thumb")]
        public Boolean ShowThumb { get; set; } = false;

        [Column(TypeName = "nvarchar(max)")]
        [DisplayName("Meta Description")]
        public string? MetaDescription { get; set; } = String.Empty;

        [Column(TypeName = "nvarchar(max)")]
        [DisplayName("Meta Keywords")]
        public string? MetaKeywords { get; set; } = String.Empty;

        [DisplayName("Template")]
        [ForeignKey("HtmlTemplate")]
        public int? TemplateId { get; set; }

        public virtual HtmlTemplate? HtmlTemplate { get; set; }
        public int Priority { get; set; } = 999999;

        public Boolean Publish { get; set; } = true;

        public Boolean Active { get; set; } = true;

        [DisplayName("Show as Menu")]
        public Boolean AsMenu { get; set; } = false;

        [DisplayName("Show as Main")]
        public Boolean ShowAsMain { get; set; } = false;


        [DisplayName("Parent Page")]
        [ForeignKey("PageRef")]
        public int? Parent { get; set; }

        public virtual Page? PageRef { get; set; }

        [DisplayName("Show in Search")]
        public Boolean ShowInSearchPage { get; set; } = true;

        [DisplayName("Show in Sitemap")]
        public Boolean ShowInSiteMap { get; set; } = false;

        [DisplayName("Show Date")]
        public Boolean ShowDate { get; set; } = true;

        [DisplayName("Allow Comment")]
        public Boolean AllowComment { get; set; } = false;

        [DisplayName("Show as Related")]
        public Boolean ShowAsRelated { get; set; } = false;


        [Column(TypeName = "nvarchar(max)")]
        [DisplayName("Page Summary")]
        public string? Summary { get; set; } = String.Empty;

        [DisplayName("Valid Until")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime? ValidDate { get; set; }

        [DisplayName("Sub Title")]
        [StringLength(500)]
        public string? SubTitle { get; set; } = String.Empty;


        public int? Gallery { get; set; } = 0;

        [DisplayName("Show Related")]
        public Boolean ShowRelated { get; set; } = false;

        public Boolean Sticky { get; set; } = false;

        public Boolean Deleted { get; set; } = false;

        public Boolean Archive { get; set; } = false;

        public int Views { get; set; } = 0;


        public int? Video { get; set; } = 0;

        public int? Audio { get; set; } = 0;

        [DisplayName("Added By")]
        [ForeignKey("User")]
        public int? UserId { get; set; } = null;
        public virtual User? UserAdd { get; set; }

        
        public int? EditedBy { get; set; } 

        [DisplayName("Last Edit")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy HH:mm}")]
        public DateTime? LastEdit { get; set; }

        public virtual ICollection<PageCategory>? PageCategories { get; set; }
        //public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<TagRel>? TagRels { get; set; }
        public virtual ICollection<Page>? Pages { get; set; }
    }
}
