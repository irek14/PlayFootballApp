using System;
using System.Collections.Generic;
using System.Text;

namespace PlayFootballApp.BusinessLogic.Models.Home
{
    public class PitchAvabilityViewModel
    {
        public string PitchName { get; set; }
        public DateTime Date { get; set; }
        public string StartHour { get; set; }
        public string EndHour { get; set; }
        public int Spot { get; set; }
        public int ReservedSpot { get; set; }
        public int FreeSpot { get; set; }
    }
}
