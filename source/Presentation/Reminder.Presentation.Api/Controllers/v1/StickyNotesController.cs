using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Reminder.Domain.Interfaces.AppService;
using Reminder.Presentation.Api.ViewModel;
using Reminder.Domain;
using Reminder.Domain.Selector;

namespace Reminder.Presentation.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/stickynotes")]
    public class StickyNotesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IReminderAppService _reminderAppService;

        public StickyNotesController(IMapper mapper, IReminderAppService reminderAppService) {
            this._mapper = mapper;
            this._reminderAppService = reminderAppService;
        }

        [HttpPost]
        public ActionResult Create ([FromBody]ReminderViewModel reminder) {
            try {
                var result = this._reminderAppService.Create(this._mapper.Map<ReminderDomain>(reminder));
                return StatusCode(201, new ResponseViewModel { Data = this._mapper.Map<ReminderViewModel>(result) });
            } catch(Exception ex) {
                return StatusCode(500, new ResponseViewModel { ErrorMessage = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult Get([FromQuery]ReminderSelector selector) {
            try {
                var result = this._mapper.Map<IEnumerable<ReminderViewModel>>(this._reminderAppService.Get(selector));
                return Ok(new ResponseViewModel { Data = result });
            } catch(Exception ex) {
                return StatusCode(500, new ResponseViewModel { ErrorMessage = ex.Message });
            }
        }

        [HttpGet]
        [Route("ExpiresIn/{minutes}")]
        public ActionResult GetForNotify(int minutes) {
            try {
                var result = this._mapper.Map<IEnumerable<ReminderViewModel>>(this._reminderAppService.GetForNotify(minutes));
                return Ok(new ResponseViewModel { Data = result });
            } catch(Exception ex) {
                return StatusCode(500, new ResponseViewModel { ErrorMessage = ex.Message });
            }
        }
    }
}