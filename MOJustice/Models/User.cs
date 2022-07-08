using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOE.Models
{
    public class User
    {
        public int Id { get; set; }

        [DisplayName("Full Name")]
        [StringLength(50)]
        public string Fullname { get; set; } = String.Empty;

        [DisplayName("Nickname")]
        [StringLength(50)]
        public string Nickname { get; set; } = String.Empty;

        [DisplayName("Group")]
        [ForeignKey("Group")]
        public Nullable<int> GroupId { get; set; }

        public virtual Group? Group { get; set; }

        [DisplayName("Login Name (username)")]
        [StringLength(20)]
        public string LoginName { get; set; } = String.Empty;

        [StringLength(250)]
        public string Password { get; set; } = String.Empty;

        [StringLength(50)]
        public string? Email { get; set; } = String.Empty;

        [DisplayName("Language")]
        [ForeignKey("Language")]
        public Nullable<int> LangId { get; set; }

        public virtual Language? Language { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy HH:mm}")]
        public DateTime LastLogin { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy HH:mm}")]
        public DateTime AddDate { get; set; } = DateTime.Now;

        [ForeignKey("UserAddedRef")]
        [DisplayName("Added By")]
        public int? AddedBy { get; set; }
        public virtual User? UserAddedRef { get; set; }
        //[ForeignKey("UserRef")]
        //public int? AddedBy { get; set; }
        //public virtual User? UserRef { get; set; }
        public byte Active { get; set; } = 1;

        public byte Deleted { get; set; } = 0;

        public virtual ICollection<AdminLog>? AdminLogs { get; set; } 
        public virtual ICollection<HtmlTemplate>? HtmlTemplates { get; set; }    
        public virtual ICollection<Category>? Category { get; set; }
        public virtual ICollection<Files>? Files1 { get; set; }

        [InverseProperty("UserAdd")]
        public virtual ICollection<Page>? UserAdds { get; set; }

        public virtual ICollection<Menu>? Menus { get; set; }
        public virtual ICollection<Tag>? Tags { get; set; }

        //public virtual ICollection<Category>? Categorys { get; set; }
        [InverseProperty("GroupUser")]
        public virtual ICollection<Group>? Groups { get; set; }

        public virtual ICollection<User>? Users { get; set; }

        //public virtual ICollection<User>? Users { get; set; }

    }
}
