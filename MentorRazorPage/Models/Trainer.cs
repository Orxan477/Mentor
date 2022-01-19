using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MentorRazorPage.Models
{
    public class Trainer
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Position { get; set; }
        public string Image { get; set; }
        [Required]
        public string Content { get; set; }
        public bool IsDeleted { get; set; }
        [NotMapped][Required]
        public IFormFile Photo { get; set; }

    }
}
