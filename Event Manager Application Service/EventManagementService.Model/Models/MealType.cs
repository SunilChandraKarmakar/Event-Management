using System.ComponentModel.DataAnnotations;

namespace EventManagementService.Model.Models
{
    public class MealType
    {
        public MealType()
        {
            Foods = new HashSet<Food>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Please, provied name.")]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        public ICollection<Food> Foods { get; set; }
    }
}