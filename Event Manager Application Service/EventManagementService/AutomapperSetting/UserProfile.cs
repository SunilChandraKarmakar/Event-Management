using AutoMapper;
using EventManagementService.Model.Models;
using EventManagementService.Model.ViewModels.Register;
using EventManagementService.Model.ViewModels.User;

namespace EventManagementService.AutomapperSetting
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>();

            CreateMap<RegisterViewModel, User>();
            CreateMap<User, RegisterViewModel>();

            CreateMap<User, UserEditViewModel>();
            CreateMap<UserEditViewModel, User>();
        }
    }
}