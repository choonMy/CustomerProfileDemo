using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class CustomerProfileDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Mobile { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Occupation { get; set; }

    }
}