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

        [HttpGet]
        public ActionResult Get() {
            try {
                var result = this._reminderAppService.GetAll();
                return Ok(new ResponseViewModel { Data = this._mapper.Map<IEnumerable<ReminderViewModel>>(result) });
            } catch(Exception ex) {
                return StatusCode(500, new ResponseViewModel { ErrorMessage = ex.Message });
            }
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
    }
}