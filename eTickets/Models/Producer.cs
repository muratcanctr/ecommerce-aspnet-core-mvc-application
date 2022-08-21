using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Producer
    {
        [Key]
        public int ProducerId { get; set; }

        [Display(Name = "Profile Picture URL")]
        [Required(ErrorMessage = "Profile Picture URL required")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = ("Full Name is between 3 and 50 chars"))]
        public string FullName { get; set; }

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography required")]
        public string Bio { get; set; }

        //Relationships
        public List<Movie>? Movies { get; set; }


    }
}
