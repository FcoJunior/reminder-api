using System.Collections.Generic;
using Reminder.Domain;
using Reminder.Domain.Selector;

namespace Reminder.Domain.Interfaces.AppService
{
    public interface IReminderAppService
    {
        IEnumerable<ReminderDomain> GetAll();
        IEnumerable<ReminderDomain> Get(ReminderSelector selector);
        IEnumerable<ReminderDomain> GetForNotify(int minutes);
        ReminderDomain Create(ReminderDomain reminderDomain);
  }
}