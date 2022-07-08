using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOE.Models
{
    public class Files
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Category")]
        [DisplayName("Category")]
        public Nullable<int> CatId { get; set; }

        public virtual Category? Category { get; set; }

        [StringLength(50)]
        [DisplayName("File Title")]
        public string Name { get; set; } = String.Empty;

        [StringLength(50)]
        [DisplayName("Arabic File Title")]
        public string ArName { get; set; } = String.Empty;

        public int? Year { get; set; }

        [DisplayName("Type")]
        [ForeignKey("FileType")]
        public Nullable<int> Type { get; set; }

        public virtual FilesType? FileType { get; set; }

        public int Parent { get; set; } = 0;

        public Boolean Publish { get; set; } = true;

        public Boolean Active { get; set; } = true;

        [StringLength(250)]
        public string? Thumb { get; set; } = String.Empty;

        [DisplayName("Language")]
        [ForeignKey("Language")]
        public Nullable<int> LangId { get; set; } = 1;

        public virtual Language? Language { get; set; }


        [Column(TypeName = "nvarchar(max)")]
        [DisplayName("English Description")]
        public string? Description { get; set; } = String.Empty;

        [Column(TypeName = "nvarchar(max)")]
        [DisplayName("Arabic Description")]
        public string? ArDescription { get; set; } = String.Empty;

        [DisplayName("File")]
        [StringLength(250)]
        public string? FilePath { get; set; } = String.Empty;

        [DisplayName("Embedding Source")]
        [Column(TypeName = "nvarchar(max)")]
        public string? Source { get; set; } = String.Empty;

        public int Priority { get; set; } = 999999;

        [DisplayName("Show Home")]
        public Boolean ShowHome { get; set; } = false;

        [DisplayName("Allow Comment")]
        public Boolean AllowComment { get; set; } = false;

        [DisplayName("Added By")]
        [ForeignKey("User")]
        public Nullable<int> UserId { get; set; } = null;

        public virtual User? User { get; set; }

        [DisplayName("File Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}")]
        public DateTime? Date { get; set; }

        [DisplayName("Add Time")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy HH:mm}")]
        public DateTime AddDate { get; set; }

        [DisplayName("Updated At")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy HH:mm}")]
        public DateTime? UpdatedAt { get; set; }

        public byte Deleted { get; set; } = 0;

        public virtual ICollection<FilesList>? FileList { get; set; }
    }
}
