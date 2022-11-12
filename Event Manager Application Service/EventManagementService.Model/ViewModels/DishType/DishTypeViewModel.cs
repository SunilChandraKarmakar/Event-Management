using EventManagementService.Model.ViewModels.Food;

namespace EventManagementService.Model.ViewModels.DishType
{
    public class DishTypeViewModel
    {
        public DishTypeViewModel()
        {
            Foods = new HashSet<FoodViewModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<FoodViewModel> Foods { get; set; }
    }
}
