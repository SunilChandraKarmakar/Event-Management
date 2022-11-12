using EventManagementService.Model.ViewModels.Food;

namespace EventManagementService.Model.ViewModels.MealType
{
    public class MealTypeViewModel
    {
        public MealTypeViewModel()
        {
            Foods = new HashSet<FoodViewModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<FoodViewModel> Foods { get; set; }
    }
}
