using System;
using System.Collections.Generic;

namespace PlayFootballApp.BuisnessEntities.Entities
{
    public partial class Pitch
    {
        public Pitch()
        {
            PitchAvailability = new HashSet<PitchAvailability>();
            PitchOpenHours = new HashSet<PitchOpenHours>();
        }

        public Guid Id { get; set; }
        public decimal LocalisationX { get; set; }
        public decimal LocalisationY { get; set; }
        public decimal SpotNumber { get; set; }
        public string Name { get; set; }
        public Guid? OpenHoursId { get; set; }
        public bool IsArchived { get; set; }

        public virtual ICollection<PitchAvailability> PitchAvailability { get; set; }
        public virtual ICollection<PitchOpenHours> PitchOpenHours { get; set; }
    }
}
