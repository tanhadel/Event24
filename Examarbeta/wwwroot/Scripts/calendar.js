$(document).ready(function () {
    $('#calendar').fullCalendar({
        events: '/api/EventApi/GetEvents', // Your API URL for fetching events
        eventRender: function (event, element) {
            // Show description when hovering over an event
            element.qtip({
                content: event.description,
                style: {
                    classes: 'qtip-dark qtip-rounded'
                }
            });
        },
        eventColor: '#378006', // Event color in the calendar
    });
});
