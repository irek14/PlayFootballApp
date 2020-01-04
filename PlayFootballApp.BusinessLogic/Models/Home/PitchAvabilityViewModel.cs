using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PlayFootballApp.BusinessLogic.Models.Home
{
    public class PitchAvabilityViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "Nazwa obiektu")]
        public string PitchName { get; set; }
        public Guid PitchId { get; set; }
        [Display(Name = "Dzień")]
        public DateTime Date { get; set; }
        [Display(Name = "Godzina rozpoczęcia")]
        public string StartHour { get; set; }
        [Display(Name = "Godzina zakończenia")]
        public string EndHour { get; set; }
        [Display(Name = "Liczba miejsca")]
        public int Spot { get; set; }
        [Display(Name = "Zajęte miejsca")]
        public int ReservedSpot { get; set; }
        [Display(Name = "Wolne miejsce")]
        public int FreeSpot { get; set; }
    }
}
