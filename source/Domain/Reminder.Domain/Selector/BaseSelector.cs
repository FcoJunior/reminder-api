namespace Reminder.Domain.Selector
{
    public enum OrderBy { ASC, DESC }

    public class BaseSelector
    {
        public BaseSelector() {
            this.OrderByField = "Date";
            this.Ordination = OrderBy.DESC;
            this.Page = 1;
            this.RegisterPerPage = 10;
        }

        public int RegisterPerPage { get; set; }
        public int Page { get; set; }
        public string OrderByField { get; set; }
        public OrderBy Ordination { get; set; }
    }
}