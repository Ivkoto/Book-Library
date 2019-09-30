using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Book_library.Models
{
    public class UserLogin
    {
        [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email required!")]
        public string Email { get; private set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password required!")]
        [DataType(DataType.Password)]
        public string Password { get; private set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; private set; }
    }
}
