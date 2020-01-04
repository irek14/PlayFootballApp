using System;
using System.Collections.Generic;

namespace PlayFootballApp.BuisnessEntities.Entities
{
    public partial class Reservation
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public Guid PitchAvailabilityId { get; set; }
        public DateTime Date { get; set; }
        public int ReservedSpots { get; set; }

        public virtual PitchAvailability PitchAvailability { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
