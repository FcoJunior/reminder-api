using System;

namespace Reminder.Domain
{
    public class ReminderDomain
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Sponsor { get; set; }
        public bool Expired {
            get {
                return DateTime.Now > this.Date ? true : false;
            }
        }
    }
}