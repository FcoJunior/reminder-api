using AutoMapper;
using Reminder.Domain;
using Reminder.Presentation.Api.ViewModel;

namespace Reminder.Presentation.Api.Config
{
    public class AutoMapperViewModelProfile : Profile
    {
        public AutoMapperViewModelProfile() {
            CreateMap<ReminderDomain, ReminderViewModel>().ReverseMap();
        }
    }
}