using System.ComponentModel.DataAnnotations;

namespace EventManagementService.Model.ViewModels.Food
{
    public class FoodDeleteViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [Display(Name = "User Id")]
        public string UserId { get; set; }

        [Display(Name = "Food Type")]
        public int FoodTypeId { get; set; }

        [Display(Name = "Meal Type")]
        public int MealTypeId { get; set; }

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

        [Required(ErrorMessage = "Please, provied food amount.")]
        [Display(Name = "Food Amount")]
        [DataType(DataType.Currency)]
        public double FoodAmount { get; set; }
    }
}