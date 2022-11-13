using EventManagementService.Model.ViewModels.DishType;
using EventManagementService.Model.ViewModels.FoodType;
using EventManagementService.Model.ViewModels.MealType;
using EventManagementService.Model.ViewModels.Payment;
using EventManagementService.Model.ViewModels.User;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EventManagementService.Model.ViewModels.Food
{
    public class FoodViewModel
    {
        public FoodViewModel()
        {
            Payments = new HashSet<PaymentViewModel>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string UserId { get; set; }
        public int FoodTypeId { get; set; }
        public int MealTypeId { get; set; }
        public int DishTypeId { get; set; }
        public bool IsSouthIndiaThali { get; set; }
        public bool IsNorthIndianThali { get; set; }
        public bool IsPunjabThali { get; set; }
        public bool IsMaharashtrianThali { get; set; }
        public double FoodAmount { get; set; }

        public UserViewModel User { get; set; }
        public FoodTypeViewModel FoodType { get; set; }
        public MealTypeViewModel MealType { get; set; }
        public DishTypeViewModel DishType { get; set; }
        public ICollection<PaymentViewModel> Payments { get; set; }
    }
}
