using System.Collections.Generic;
using Reminder.Domain;
using Reminder.Domain.Interfaces.Repository;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Linq;
using System;
using AutoMapper;
using Reminder.Infra.Data.Entities;
using Reminder.Domain.Selector;

namespace Reminder.Infra.Data.Repository
{
    public class ReminderRepository : IReminderRepository
    {
        private readonly IMapper _mapper;
        private readonly Context _context; 

        public ReminderRepository(IMapper mapper, IOptions<ContextSettings> settings)
        {
            this._mapper = mapper;
            this._context = new Context(settings);
        }

        public ReminderDomain Create(ReminderDomain reminder)
        {
            reminder.Id = Guid.NewGuid().ToString();
            var entity = this._mapper.Map<ReminderEntity>(reminder);
            this._context.Reminder.InsertOne(entity);
            return reminder;
        }

        public IEnumerable<ReminderDomain> GetExpiresTo(int minutes)
        {
            var query = _context.Reminder.Find(x => x.Date >= DateTime.Now && x.Date <= DateTime.Now.AddMinutes(minutes));
            return this._mapper.Map<IEnumerable<ReminderDomain>>(query.ToList());
        }

        public IEnumerable<ReminderDomain> Get(ReminderSelector selector) {
            
            IFindFluent<ReminderEntity, ReminderEntity> query;

            if (!string.IsNullOrEmpty(selector.Title)) {
                query = _context.Reminder.Find(x => x.Title.ToLower().StartsWith(selector.Title.ToLower()));
            } else {
                query = _context.Reminder.Find(_ => true);
            }

            query = query.Skip((selector.Page - 1) * selector.RegisterPerPage);
            query = query.Limit(selector.RegisterPerPage);

            if (selector.Ordination == OrderBy.ASC) {
                query = query.Sort(Builders<ReminderEntity>.Sort.Ascending(selector.OrderByField));                
            } else {
                query = query.Sort(Builders<ReminderEntity>.Sort.Descending(selector.OrderByField));
            }

            return this._mapper.Map<IEnumerable<ReminderDomain>>(query.ToList());
        }
    }
}