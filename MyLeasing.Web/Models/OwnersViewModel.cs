using Microsoft.AspNetCore.Http;
using MyLeasing.Web.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace MyLeasing.Web.Models
{
    public class OwnersViewModel : Owner
    {
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }
    }
}
