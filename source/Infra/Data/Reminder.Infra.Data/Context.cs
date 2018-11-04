using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Reminder.Infra.Data.Entities;

namespace Reminder.Infra.Data
{
    public class Context
    {
        private readonly IMongoDatabase _database;

        public Context(IOptions<ContextSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<ReminderEntity> Reminder {
            get {
                return _database.GetCollection<ReminderEntity>("Reminder");
            }
        }
    }

    public class ContextSettings {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
    }
}