using AutoMapper;
using EventManagementService.Model.Models;
using EventManagementService.Model.ViewModels.EventType;
using EventManagementService.Model.ViewModels.Register;
using EventManagementService.Model.ViewModels.User;
using EventManagementService.Model.ViewModels.Venue;
using EventManagementService.Model.ViewModels.VenueType;

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

            CreateMap<Venue, VenueViewModel>();
            CreateMap<VenueCreateViewModel, Venue>();
            CreateMap<Venue, VenueUpdateViewModel>();
            CreateMap<VenueUpdateViewModel, Venue>();

            CreateMap<EventType, EventTypeViewModel>();
            CreateMap<VenueType, VenueTypeViewModel>();
        }
    }
}