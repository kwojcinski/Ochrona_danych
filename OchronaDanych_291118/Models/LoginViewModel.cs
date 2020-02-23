using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OchronaDanych_291118.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Pole nie może pozostać puste.")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Pole nie może pozostać puste.")]
        public string Password { get; set; }
        public int Attempts { get; set; }
    }
}
