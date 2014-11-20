using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiOData.Models;
using System.Web.Http.OData.Query;

namespace WebApiOData.Controllers
{
    public class MeetingsController : ApiController
    {
        private readonly IList<Meeting> _scheduledMeetings;

        public MeetingsController()
        {
            _scheduledMeetings = new List<Meeting>
            {
                new Meeting { Id = "1", Leader = "Mark Nichols", MeetingDate = new DateTime(2013, 1, 17), Title = "Project X Planning" },
                new Meeting { Id = "3", Leader = "Jim Phelps", MeetingDate = new DateTime(2013, 2, 8), Title = "Mission Discussion" },
                new Meeting { Id = "6", Leader = "Barney Collier", MeetingDate = new DateTime(2013, 3, 12), Title = "Advanced Device Technology" },
                new Meeting { Id = "7", Leader = "Willie Armitage", MeetingDate = new DateTime(2013, 5, 28), Title = "Maintaining a Strong Presence" },
                new Meeting { Id = "9", Leader = "Cinnamon Carter", MeetingDate = new DateTime(2013, 2, 15), Title = "Company Fashion" },
                new Meeting { Id = "10", Leader = "Rollin Hand", MeetingDate = new DateTime(2013, 1, 21), Title = "Magic Selling" }
            };
        }

        // GET api/Meeting
        [Queryable(AllowedQueryOptions = AllowedQueryOptions.All)]
        public IQueryable<Meeting> Get()
        {
            return _scheduledMeetings.AsQueryable();
        }

    }
}