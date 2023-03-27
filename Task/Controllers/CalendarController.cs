using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google_Calendar.Helper;
using Task.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task;

namespace Google_Calendar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        [HttpPost("CreateGoogleCalendar")]
        public async Task<IActionResult> CreateGoogleCalendar([FromBody] GoogleCalendar request)
        {
            return Ok(await GoogleCalendarHelper.CreateGoogleCalendar(request));
        }
        [HttpPost("updateGoogleCalendar")]
        public async Task<IActionResult> updateGoogleCalendar([FromBody] UpdateGoogleCalendar request)
        {
            return Ok(await GoogleCalendarHelper.UpdateGoogleCalendar(request));
        }
        [HttpGet("ListGoogleCalendar")]
        public async Task<IActionResult> ListGoogleCalendar()
        {
            return Ok(await GoogleCalendarHelper.GetAllGoogleCalendar());
        }
        
        [HttpGet("SearchGoogleCalendar")]
        public async Task<IActionResult> ListGoSearchGoogleCalendarogleCalendar(string Description,
                      DateTime End, DateTime Start)
        {
            return Ok(await GoogleCalendarHelper.SearchGoogleCalendar(new GoogleCalendarSearch
            {
                Description= Description,
                End= End,
                Start= Start,
            }));
        }
        [HttpDelete("DeleteGoogleCalendar")]
        public async Task<IActionResult> DeleteSearchGoogleCalendarogleCalendar(string request)
        {
            return Ok(await GoogleCalendarHelper.deleteGoogleCalendar(request));
        }

        
       
    }
}