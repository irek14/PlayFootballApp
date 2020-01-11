using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Text;

namespace PlayFootballApp.BusinessLogic.Models.Home
{
    public class FindEventsViewModel
    {
        public SearchPitchViewModel Search { get; set; }
        public List<PitchViewModel> Pitches { get; set; }
        public GeoCoordinate ClosestPitch { get; set; }
    }
}
