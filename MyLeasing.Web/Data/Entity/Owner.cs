using System.ComponentModel.DataAnnotations;

namespace MyLeasing.Web.Data.Entity
{
    public class Owner : IEntity
    {
        public int Id { get; set; }

        [Required]
        public string Document { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [MaxLength(9)]
        [Display(Name = "Home Phone")]
        public string Fixed_Phone { get; set; }

        [Required]
        [MaxLength(9)]
        [Display(Name = "Cell Phone")]
        public string Cell_Phone { get; set; }

        [Required]
        public string Address { get; set; }

        [Display(Name = "Image")]
        public string ImageURL { get; set; }

        public string Name
        {
            get
            {
                return $"{FirstName} {LastName}";
            }

        }

        public User user { get; set; }

        public string ImageFullPath
        {
            get
            {
                if (string.IsNullOrEmpty(ImageURL))
                {
                    return null;
                }
                return $"https://localhost:44326{ImageURL.Substring(1)}";
            }
        }
    }
}
