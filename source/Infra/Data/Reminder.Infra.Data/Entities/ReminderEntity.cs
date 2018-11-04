using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Reminder.Infra.Data.Entities
{
    public class ReminderEntity
    {
        [BsonId]
        public ObjectId InternalId { get; set; }
        
        [BsonRequired]
        public string Id { get; set; }
        
        [BsonRequired]
        public string Title { get; set; }
        
        [BsonRequired]
        public string Description { get; set; }

        [BsonDateTimeOptions]
        public DateTime Date { get; set; }
        
        [BsonRequired]
        public string Sponsor { get; set; }
    }
}