using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BJAT.Web.Models
{
    public class UserModel
    {
        [Required]
        [Display(Name="Vardas")]
        [StringLength(20)]
        public string DisplayName { get; set; }
        [Required]
        [Display(Name = "El. paštas")]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Vartotojo vardas")]
        [StringLength(20)]
        public string LoginName { get; set; }
        [Required]
        [Display(Name = "Slaptažodis")]
        [DataType(DataType.Password)]
        [StringLength(20,MinimumLength = 6)]
        public string Password { get; set; }
    }
}