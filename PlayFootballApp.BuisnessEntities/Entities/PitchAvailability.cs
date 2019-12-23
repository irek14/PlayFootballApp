using System;
using System.Collections.Generic;

namespace PlayFootballApp.BuisnessEntities.Entities
{
    public partial class PitchAvailability
    {
        public PitchAvailability()
        {
            Reservation = new HashSet<Reservation>();
        }

        public Guid Id { get; set; }
        public Guid PitchId { get; set; }
        public Guid PitchOpenHoursId { get; set; }
        public DateTime OpenDate { get; set; }

        public virtual Pitch Pitch { get; set; }
        public virtual PitchOpenHours PitchOpenHours { get; set; }
        public virtual ICollection<Reservation> Reservation { get; set; }
    }
}
