using System.ComponentModel.DataAnnotations;

namespace RepositoryPatternApi.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; }
        public string Age { get; set; }
        public string? Adrress { get; set; }
        public string? PatientType { get; set; }
        public string? bednum { get; set; } = string.Empty;
        public string? diagnosis { get; set; } = string.Empty;
    }
}
