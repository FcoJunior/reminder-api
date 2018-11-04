using System.Collections.Generic;
using Reminder.Domain;

namespace Reminder.Domain.Interfaces.AppService
{
    public interface IReminderAppService
    {
        IEnumerable<ReminderDomain> GetAll();
        ReminderDomain Create(ReminderDomain reminderDomain);
  }
}