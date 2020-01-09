using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PlayFootballApp.BusinessLogic.Models.Home
{
    public class SearchPitchViewModel
    {
        [Required(ErrorMessage = "Wprowadź datę początkową")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Wprowadź datę końcową")]
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage ="Podaj liczbę miejsc")]
        public int SpotNumber { get; set; }
        public decimal LocalisationX { get; set; }
        public decimal LocalisationY { get; set; }
        public string Distance { get; set; }
    }
}
