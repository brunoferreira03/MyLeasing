using System.ComponentModel.DataAnnotations;

namespace MyLeasing.Web.Data.Entity
{
    public class Owner
    {
        public int Id { get; set; }

        [Required]
        public string Document { get; set; }

        [Required]
        public string Name { get; set; }

        [MaxLength(9)]
        [Display(Name = "Home Phone")]
        public string Fixed_Phone { get; set; }

        [Required]
        [MaxLength(9)]
        [Display(Name = "Cell Phone")]
        public string Cell_Phone { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
