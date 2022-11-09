namespace EventManagementService.Model.Models
{
    public class FoodType
    {
        public FoodType()
        {
            Foods = new List<Food>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Food> Foods { get; set; }
    }
}