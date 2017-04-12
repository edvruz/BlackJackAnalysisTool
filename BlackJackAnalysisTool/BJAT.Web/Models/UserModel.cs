using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BJAT.Web.Models
{
    public class UserRegisterModel
    {
        [Required]
        [Display(Name="Name")]
        [StringLength(20)]
        public string DisplayName { get; set; }

        [Required]
        [Display(Name = "E-Mail")]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "User name")]
        [StringLength(20)]
        public string LoginName { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6)]
        public string Password { get; set; }
        
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Slaptažodžiai nesutampa")]
        [DataType(DataType.Password)]
        public string ReenterPassword { get; set; }
    }

    public class UserLoginModel
    {
        [Required]
        [Display(Name = "User name or E-Mail")]
        [StringLength(100)]
        public string UserNameOrEmail { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6)]
        public string Password { get; set; }
    }
}