using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PlayFootballApp.BusinessLogic.Models.Home
{
    public class PitchViewModel
    {
        public Guid PitchId { get; set; }
        [Display(Name = "Nazwa obiektu")]
        public string PitchName { get; set; }
        [Display(Name = "Liczba miejsc")]
        public int Spot { get; set; }
        public List<PitchAvabilityViewModel> PitchAvability { get; set; }
    }
}
