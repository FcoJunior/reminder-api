using System.Collections.Generic;
using Reminder.Domain;
using Reminder.Domain.Selector;

namespace Reminder.Domain.Interfaces.Repository
{
    public interface IReminderRepository
    {
        IEnumerable<ReminderDomain> GetAll();
        IEnumerable<ReminderDomain> Get(ReminderSelector selector);
        IEnumerable<ReminderDomain> GetExpiresTo(int minutes);
        ReminderDomain Create(ReminderDomain reminder);
    }
}