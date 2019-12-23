using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PlayFootballApp.BusinessLogic.Models.Account
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "To pole jest wymagane.")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "To pole jest wymagane.")]
        [Display(Name = "Imię")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane.")]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane.")]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Hasła się od siebie różnią.")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "To pole jest wymagane.")]
        [Display(Name = "Powtórz hasło")]
        public string PasswordConfirmation { get; set; }
    }
}
