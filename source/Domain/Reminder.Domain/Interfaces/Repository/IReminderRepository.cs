using System.Collections.Generic;
using Reminder.Domain;

namespace Reminder.Domain.Interfaces.Repository
{
    public interface IReminderRepository
    {
        IEnumerable<ReminderDomain> GetAll();
        ReminderDomain Create(ReminderDomain reminder);
    }
}