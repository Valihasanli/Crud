using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mamba.Models
{
    public class Member
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(15)]
        public string Fulllname { get; set; } = null!;
        [Required]
        [MaxLength(20)]
        public string Proffesion { get; set; } = null!;

        public string? ImgUrl { get; set; }
        [NotMapped]
        public IFormFile? ImgFile { get; set; }
    }
}
