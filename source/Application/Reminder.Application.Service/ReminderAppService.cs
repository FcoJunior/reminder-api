using System.Collections.Generic;
using Reminder.Domain;
using Reminder.Domain.Interfaces.AppService;
using Reminder.Domain.Interfaces.Repository;

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

    public IEnumerable<ReminderDomain> GetAll() {
      return this._reminderRepository.GetAll();
    }
  }
}