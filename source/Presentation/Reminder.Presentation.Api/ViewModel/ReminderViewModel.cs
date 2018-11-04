using System;

namespace Reminder.Presentation.Api.ViewModel
{
    public class ReminderViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Sponsor { get; set; }
        public bool Expired { get; set; }
    }
}