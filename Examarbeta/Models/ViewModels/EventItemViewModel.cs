using System;
using System.Collections.Generic;

namespace Examarbeta.Models.ViewModels
{
    public class EventItemViewModel
    {
        public string Title { get; set; }
        public string EventDescription { get; set; }
        public string EventPlace { get; set; }
        public DateTime EventDate { get; set; }
        public decimal EventPrice { get; set; }
        public int EventCapacity { get; set; }
        public string EventImage { get; set; }
        public string AltImageText { get; set; }
        public string EventOwner { get; set; }
        public List<string> AdditionalImages { get; set; }
        public string EventsInfo { get; set; }
        public string EventInfolongtext{ get; set; }

        public string EventUrl { get; set; }

    }
}
