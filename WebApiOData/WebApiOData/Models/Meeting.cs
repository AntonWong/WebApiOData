using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiOData.Models
{
    public class Meeting
    {
        public string Id { get; set; }
        public DateTime MeetingDate { get; set; }
        public string Title { get; set; }
        public string Leader { get; set; }
    }

}