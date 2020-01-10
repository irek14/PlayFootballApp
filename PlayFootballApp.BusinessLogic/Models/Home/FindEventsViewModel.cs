using System;
using System.Collections.Generic;
using System.Text;

namespace PlayFootballApp.BusinessLogic.Models.Home
{
    public class FindEventsViewModel
    {
        public SearchPitchViewModel Search { get; set; }
        public List<PitchViewModel> Pitches { get; set; }
    }
}
