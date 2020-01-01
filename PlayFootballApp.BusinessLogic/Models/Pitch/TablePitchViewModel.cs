using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PlayFootballApp.BusinessLogic.Models.Pitch
{
    public class TablePitchViewModel
    {
        public Guid Id { get; set; }
        public decimal LocalisationX { get; set; }
        public decimal LocalisationY { get; set; }
        [Display(Name = "Nazwa obiektu")]
        public string Name { get; set; }
        [Display(Name = "Liczba miejsc")]
        public int SpotNumber { get; set; }
    }
}
