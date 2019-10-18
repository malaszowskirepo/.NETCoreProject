using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentProject.Models
{
    public class RegisterViewModel
    {
        [Required]
        [MaxLength(30, ErrorMessage ="Nickname cannot exeed 30 characters.")]
        public string Nickname { get; set; }

        [Required]
        [EmailAddress]
        [Key]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name ="Confirm password")]
        [Compare("Password", ErrorMessage = "The passwords you entered do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "City cannot exeed 20 characters.")]
        public string City { get; set; }
    }
}
