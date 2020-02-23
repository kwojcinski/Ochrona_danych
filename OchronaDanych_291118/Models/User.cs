using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OchronaDanych_291118.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Pole nie może pozostać puste.")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Niepoprawna długość loginu. Login musi mieć więcej niż 4 oraz mniej niż 20 znaków.")]
        [Display(Name = "Login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Pole nie może pozostać puste.")]
        [StringLength(50, ErrorMessage = "Maksymalna długość adresu email to 50 znaków.")]
        [Display(Name = "Adres email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Pole nie może pozostać puste.")]
        [MinLength(8, ErrorMessage = "Minimalna długość hasła to 8 znaków.")]
        [Display(Name = "Hasło")]
        public string Password { get; set; }
        public List<Note> Notes { get; set; }
        public int LogTries { get; set; }
        public bool IsLocked { get; set; }
    }
}
