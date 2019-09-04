using System;
using System.ComponentModel.DataAnnotations;

namespace Book_library.Models
{
    public partial class User
    {
        [Key]
        public int UserID { get; set; }

        [Display(Name = "First name:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "First name is required!")]
        public string FirstName { get; set; }

        [Display(Name = "Last name:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last name is required!")]
        public string LastName { get; set; }

        [Display(Name = "Email:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required!")]
        public string Email { get; set; }

        [Display(Name = "Date of birth:")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfBirth { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required!")]
        [DataType(DataType.Password)]
        [MinLength(4, ErrorMessage = "Min 4 characters required")]
        public string Password { get; set; }

        [Display(Name = "Confirm password:")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password do not match")]
        public string ConfirmPassword { get; set; }

        [Required]
        public bool IsEmailVerified { get; set; }

        [Required]
        public System.Guid ActivationCode { get; set; }
    }
}
