using System.ComponentModel.DataAnnotations;

namespace FishingBattle.Anglers.Service.DTOs
{
    public class AnglerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Surname is required.")]
        public string? Surname { get; set; }

        [Range(16, 100)]
        public int Age { get; set; }
    }
}
