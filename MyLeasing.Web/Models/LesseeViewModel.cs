using Microsoft.AspNetCore.Http;
using MyLeasing.Web.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MyLeasing.Web.Models
{
    public class LesseeViewModel : Lessee
    {
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }
    }
}
