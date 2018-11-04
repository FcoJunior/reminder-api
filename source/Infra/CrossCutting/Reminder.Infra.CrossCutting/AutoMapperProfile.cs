using AutoMapper;
using Reminder.Domain;
using Reminder.Infra.Data.Entities;

namespace Reminder.Infra.CrossCutting
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            CreateMap<ReminderDomain, ReminderEntity>().ReverseMap();
        }
    }
}