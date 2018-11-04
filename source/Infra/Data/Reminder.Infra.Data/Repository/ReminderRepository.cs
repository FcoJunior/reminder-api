using System.Collections.Generic;
using Reminder.Domain;
using Reminder.Domain.Interfaces.Repository;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Linq;
using System;
using AutoMapper;
using Reminder.Infra.Data.Entities;

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

        public IEnumerable<ReminderDomain> GetAll()
        {
            var result = _context.Reminder.Find(_ => true).ToList();
            return this._mapper.Map<IEnumerable<ReminderDomain>>(result);
        }
    }
}