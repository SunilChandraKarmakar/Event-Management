using System.ComponentModel.DataAnnotations;

namespace EventManagementService.Model.ViewModels.Food
{
    public class FoodUpdateViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please, provied any title.")]
        [StringLength(50, MinimumLength = 2)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please, provied user id.")]
        [Display(Name = "User Id")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Please, select food type.")]
        [Display(Name = "Food Type")]
        public int FoodTypeId { get; set; }

        [Required(ErrorMessage = "Please, select meal type.")]
        [Display(Name = "Meal Type")]
        public int MealTypeId { get; set; }

        [Required(ErrorMessage = "Please, select dish type.")]
        [Display(Name = "Dish Type")]
        public int DishTypeId { get; set; }

        [Display(Name = "South India Thali")]
        public bool IsSouthIndiaThali { get; set; }

        [Display(Name = "North Indian Thali")]
        public bool IsNorthIndianThali { get; set; }

        [Display(Name = "Punjab Thali")]
        public bool IsPunjabThali { get; set; }

        [Display(Name = "Maharashtrian Thali")]
        public bool IsMaharashtrianThali { get; set; }
    }
}