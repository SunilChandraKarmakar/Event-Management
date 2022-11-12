namespace EventManagementService.Model.ViewModels.FoodType
{
    public class FoodTypeViewModel
    {
        public FoodTypeViewModel()
        {
            Foods = new HashSet<FoodTypeViewModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<FoodTypeViewModel> Foods { get; set; }
    }
}
