using EventManagementService.Model.ViewModels.Food;

namespace EventManagementService.Model.ViewModels.FoodType
{
    public class FoodTypeViewModel
    {
        public FoodTypeViewModel()
        {
            Foods = new HashSet<FoodViewModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<FoodViewModel> Foods { get; set; }
    }
}
