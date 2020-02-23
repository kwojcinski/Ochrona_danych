using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OchronaDanych_291118.Models
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Pole nie może pozostać puste.")]
        public string OldPassword { get; set; }
        [MinLength(8, ErrorMessage = "Minimalna długość hasła to 8 znaków.")]
        [Required(ErrorMessage = "Pole nie może pozostać puste.")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Pole nie może pozostać puste.")]
        public string NewRepeatPassword { get; set; }
    }
}
