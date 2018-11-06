using System.Collections.Generic;
using Reminder.Domain;
using Reminder.Domain.Interfaces.AppService;
using Reminder.Domain.Interfaces.Repository;
using Reminder.Domain.Selector;

namespace Reminder.Application.Service
{
  public class ReminderAppService : IReminderAppService
  {
    private readonly IReminderRepository _reminderRepository;

    public ReminderAppService(IReminderRepository reminderRepository) {
        this._reminderRepository = reminderRepository;
    }

    public ReminderDomain Create(ReminderDomain reminderDomain)
    {
      return this._reminderRepository.Create(reminderDomain);
    }

    public IEnumerable<ReminderDomain> Get(ReminderSelector selector)
    {
      return this._reminderRepository.Get(selector);
    }

    public IEnumerable<ReminderDomain> GetAll() {
      return this._reminderRepository.GetAll();
    }

    public IEnumerable<ReminderDomain> GetForNotify(int minutes)
    {
      return this._reminderRepository.GetExpiresTo(minutes);
    }
  }
}