using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayFootballApp.BuisnessEntities.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {

        }

        public int? SubscriberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
