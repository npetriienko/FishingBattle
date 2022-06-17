using System.ComponentModel.DataAnnotations;

namespace FishingBattle.Anglers.Service.Models
{
    public class Angler
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Surname is required.")]
        public string? Surname { get; set; }

        [Range(16, 100)]
        public int Age { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Surname: {Surname}, Age: {Age}";
        }
    }
}
