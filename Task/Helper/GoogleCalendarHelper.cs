using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Task.Models;
using System;
using Task;
using Humanizer;

namespace Google_Calendar.Helper
{
    public class GoogleCalendarHelper
    {

        public static async Task<APIResponse> CreateGoogleCalendar(GoogleCalendar request)
        {
            try
            {
                var services = await GoogleCalendarHelperHelpers.CreateCalendarService();
                Event eventCalendar = new Event()
                {
                    Summary = request.Summary,
                    Location = request.Location,
                    Start = new EventDateTime
                    {
                        DateTime = request.Start,
                    },
                    End = new EventDateTime
                    {
                        DateTime = request.End,
                    },
                    Description = request.Description,
                    Reminders = new Event.RemindersData()
                    {
                        UseDefault = false,
                        Overrides = new List<EventReminder>
                    {
                        new EventReminder { Method = "email", Minutes = 30 }
                    }
                    },
                };
                var eventRequest = services.Events.Insert(eventCalendar, "primary");
                eventRequest.SendNotifications = true;
                var requestCreate = await eventRequest.ExecuteAsync();
                Email.sendMaile(requestCreate.Creator.Email);
                return new APIResponse
                {

                    Code = 200,
                    Data = requestCreate,
                    IsError = false,
                    Message = "Create Event",
                }; 
            }
            catch( Exception ex)
            {
                return new APIResponse
                {
                    
                   Code=400,
                   Data=ex,
                   IsError=true,
                   Message="",
                };
            }
            
        }
        public static async Task<APIResponse> UpdateGoogleCalendar(UpdateGoogleCalendar request)
        {
            try
            {
                var services = await GoogleCalendarHelperHelpers.CreateCalendarService();
                Event eventCalendar = new Event()
            {

                Summary = request.Summary,
                Location = request.Location,
                Start = new EventDateTime
                {
                    DateTime = request.Start,
                    TimeZone = "Asia/Ho_Chi_Minh"
                },
                End = new EventDateTime
                {
                    DateTime = request.End,
                    TimeZone = "Asia/Ho_Chi_Minh"
                },
                Description = request.Description
            };
                var eventRequest = services.Events.Update(eventCalendar, "primary", request.Id);
                var requestCreate = await eventRequest.ExecuteAsync();
            
                return new APIResponse
                {

                    Code = 200,
                    Data = requestCreate,
                    IsError = false,
                    Message = "update Event",
                };
            }
            catch(Exception ex)
            {
                return new APIResponse
                {
                    
                   Code=400,
                   Data=ex,
                   IsError=true,
                   Message="",
                };
            }
        }
        public static async Task<APIResponse> GetAllGoogleCalendar()
        {
            try
            {
                var services = await GoogleCalendarHelperHelpers.CreateCalendarService();
                var eventRequest = services.Events.List("primary");
                var requestCreate = (await eventRequest.ExecuteAsync());
           
                return new APIResponse
                {

                    Code = 200,
                    Data = requestCreate.Items.Select(x => new
                    {
                        x.Id,
                        x.Description,
                        Start= x.Start.DateTime.Humanize(),
                        End=  x.End.DateTime.Humanize(),
                        x.Summary,
                    }).ToList(),
                    IsError = false,
                    Message = "Get All Event",
                };
            }
            catch (Exception ex)
            {
                return new APIResponse
                {

                    Code = 400,
                    Data = ex,
                    IsError = true,
                    Message = "",
                };
            }
        }
        public static async Task<APIResponse> deleteGoogleCalendar(string request)
        {
            try
            {
                var services = await GoogleCalendarHelperHelpers.CreateCalendarService();
                var eventRequest = services.Events.Delete("primary", request);
                var requestCreate = await eventRequest.ExecuteAsync();
                return new APIResponse
                {
                    Code = 200,
                    Data = requestCreate,
                    IsError = false,
                    Message = "Get All Event",
                };
            }
            catch (Exception ex)
            {
                return new APIResponse
                {

                    Code = 400,
                    Data = ex,
                    IsError = true,
                    Message = "",
                };
            }
        }
        public static async Task<APIResponse> SearchGoogleCalendar(GoogleCalendarSearch request)
        {
            try
            {
                var services = await GoogleCalendarHelperHelpers.CreateCalendarService();
                var eventRequest = services.Events.List("primary");
                eventRequest.Q = request.Description;
                if(request.Start != DateTime.MinValue)
                {
                    eventRequest.TimeMin = request.Start;
                }
                if (request.End != DateTime.MinValue)
                {
                    eventRequest.TimeMax = request.End;
                }
                var requestCreate = await eventRequest.ExecuteAsync();

               
                return new APIResponse
                {
                    Code = 200,
                    Data = requestCreate.Items,
                    IsError = false,
                    Message = "Get All Event",
                };
             }
            catch (Exception ex)
            {
                return new APIResponse
                {
                    Code = 400,
                    Data = ex,
                    IsError = true,
                    Message = "",
                };
            }
        }
        public static async Task<APIResponse> GetGoogleCalendar(string request)
        {
            try
            {
                var services = await GoogleCalendarHelperHelpers.CreateCalendarService();
                var eventRequest = services.Events.Get("primary", request);
                var requestCreate = await eventRequest.ExecuteAsync();
                return new APIResponse
                {
                    Code = 200,
                    Data = requestCreate,
                    IsError = false,
                    Message = "Get All Event",
                };
            }
            catch (Exception ex)
            {
                return new APIResponse
                {
                    Code = 400,
                    Data = ex,
                    IsError = true,
                    Message = "",
                };
            }
        }
    }
}