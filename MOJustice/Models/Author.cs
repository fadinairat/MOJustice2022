using System.ComponentModel.DataAnnotations;

namespace MOE.Models
{
    public class Author
    {
        public int AuthorId { get; set; } 

        [Display(Name="First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

    }
}
