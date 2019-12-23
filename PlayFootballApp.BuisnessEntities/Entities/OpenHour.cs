using System;
using System.Collections.Generic;

namespace PlayFootballApp.BuisnessEntities.Entities
{
    public partial class OpenHour
    {
        public OpenHour()
        {
            PitchOpenHours = new HashSet<PitchOpenHours>();
        }

        public Guid Id { get; set; }
        public string StartHour { get; set; }
        public string EndHour { get; set; }

        public virtual ICollection<PitchOpenHours> PitchOpenHours { get; set; }
    }
}
