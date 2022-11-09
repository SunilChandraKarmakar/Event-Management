namespace EventManagementService.Model.Models
{
    public class Food
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int FoodTypeId { get; set; }
        public int MealTypeId { get; set; }
        public int DeshTypeId { get; set; }
        public bool IsSouthIndiaThali { get; set; }
        public bool IsNorthIndianThali { get; set; }
        public bool IsPunjabThali { get; set; }
        public bool IsMaharashtrianThali { get; set; }

        public User User { get; set; }
        public FoodType FoodType { get; set; }
        public MealType MealType { get; set; }
        public DishType DishType { get; set; }
    }
}