using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OchronaDanych_291118.Models
{
    public class UserViewModel : User
    {
        [Required(ErrorMessage = "Pole nie może pozostać puste")]
        [StringLength(16, MinimumLength = 8)]
        [Display(Name = "Powtórz hasło.")]
        public string RepeatPassword { get; set; }
    }
}
