using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PlayFootballApp.BusinessLogic.Models.Pitch
{
    public class PitchCreateViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Podaj nazwę boiska")]
        [Display(Name = "Nazwa boiska")]
        public string Name { get; set; }

        [Display(Name = "Liczba miejsc")]
        [Required(ErrorMessage = "Wpisz liczbę miejsc")]
        [Range(1,int.MaxValue, ErrorMessage = "Liczba miejsc musi być większa od 0")]
        public int SpotNumber { get; set; }

        public decimal LocalisationX { get; set; }
        public decimal LocalisationY { get; set; }

        public bool[] OpenHours { get; set; } = new bool[5];
    }
}
