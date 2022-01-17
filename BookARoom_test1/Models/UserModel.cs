using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookARoom_test1.Models
{
    public class UserModel
    {
        [Display(Name ="Login")]
        [Required(ErrorMessage = "You need to enter your login")]
        public string Login { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [Required(ErrorMessage = "You must have a password")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "You need to provide long anough password")]
        public string Password { get; set; }

        [Display(Name = "ConfirmPassword")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "Passwords must match")]
        public string ConfirmPassword { get; set; }
    }
}
