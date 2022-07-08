using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOE.Models
{
    public class Group
    {        
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; } = String.Empty;

        [StringLength(50)]
        public string ArName { get; set; } = String.Empty;

        [ForeignKey("Language")]
        [DisplayName("Language")]
        [Required]
        public int LangId { get; set; } = 0;

        public virtual Language? Language { get; set; }

        [DisplayName("Create Page")]
        public Boolean P1 { get; set; } = false;


        [DisplayName("Editing Page")]
        public Boolean P2 { get; set; } = false;


        [DisplayName("Deleting Page")]
        public Boolean P3 { get; set; } = false;


        [DisplayName("Create Category")]
        public Boolean P4 { get; set; } = false;


        [DisplayName("Editing Category")]
        public Boolean P5 { get; set; } = false;

        [DisplayName("Deleting Category")]
        public Boolean P6 { get; set; } = false;

        [DisplayName("Control Files")]
        public Boolean P7 { get; set; } = false;

        [DisplayName("Control Tags")]
        public Boolean P8 { get; set; } = false;

        [DisplayName("Control Menus")]
        public Boolean P9 { get; set; } = false;

        [DisplayName("Control Templates")]
        public Boolean P10 { get; set; } = false;

        [DisplayName("Control Users")]
        public Boolean P11 { get; set; } = false;

        [DisplayName("Control Groups")]
        public Boolean P12 { get; set; } = false;
        public Boolean P13 { get; set; } = false;
        public Boolean P14 { get; set; } = false;
        public Boolean P15 { get; set; } = false;
        public Boolean P16 { get; set; } = false;

        public Boolean P17 { get; set; } = false;

        public Boolean P18 { get; set; } = false;

        //public Boolean P19 { get; set; } = false;
        public Boolean P20 { get; set; } = false;

        public byte? Active { get; set; } = 1;   //To allow null for this column

        [ForeignKey("User")]
        public int? UserId { get; set; }
        public virtual User? GroupUser { get; set; }
        public byte Deleted { get; set; } = 0;

        
        public virtual ICollection<User>? Users { get; set; }
    }
}
