using System;
using System.Collections.Generic;

namespace PlayFootballApp.BuisnessEntities.Entities
{
    public partial class PitchOpenHours
    {
        public PitchOpenHours()
        {
            PitchAvailability = new HashSet<PitchAvailability>();
        }

        public Guid Id { get; set; }
        public Guid PitchId { get; set; }
        public Guid OpenHourId { get; set; }

        public virtual OpenHour OpenHour { get; set; }
        public virtual Pitch Pitch { get; set; }
        public virtual ICollection<PitchAvailability> PitchAvailability { get; set; }
    }
}
