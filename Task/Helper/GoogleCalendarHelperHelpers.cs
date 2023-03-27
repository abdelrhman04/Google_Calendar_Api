using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google_Calendar.Helper;
using System;
using Task.Models;

internal static class GoogleCalendarHelperHelpers
{
    public static async Task<CalendarService> CreateCalendarService()
    {
        string[] Scopes = { "https://www.googleapis.com/auth/calendar" };
        string ApplicationName = "Google Canlendar Api";
        UserCredential credential;
        using (var stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "Cre", "cre.json"), FileMode.Open, FileAccess.Read))
        {
            string credPath = "token.json";
            credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                GoogleClientSecrets.Load(stream).Secrets,
                Scopes,
                "user",
                CancellationToken.None,
                new FileDataStore(credPath, true)).Result;
        }
        // define services
        var services = new CalendarService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = ApplicationName,
        });
        return services;
        // define request

    }
        //public static async Task<Event> reminders(UpdateGoogleCalendar request)
        //{
        //    var services = await GoogleCalendarHelperHelpers.CreateCalendarService();
        //    var eventItem = await GetGoogleCalendar(request);
        //    var reminders = new Event.RemindersData();
        //    reminders.UseDefault = false;
        //    reminders.Overrides = new List<EventReminder>
        //    {
        //             new EventReminder { Method = "email", Minutes = 60 }
        //    };
        //    eventItem.Reminders = reminders;
        //    var updateRequest = services.Events.Update(eventItem, "primary", eventItem.Id);
        //    var updatedEvent = updateRequest.Execute();

        //    return updatedEvent;
        //}
}