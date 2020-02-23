using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OchronaDanych_291118.Models
{
    public class Note
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Podaj tytuł.")]
        [StringLength(120, MinimumLength = 4, ErrorMessage = "Tytuł notatki powinien mieć więcej niż 4 znaki i mniej niż 120.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Wypełnij notatkę")]
        public string Description { get; set; }
        [Required]
        public bool IsForEveryone { get; set; }
        public User Author { get; set; }
        public List<Email> AcceptedUsersEmails { get; set; }
    }
}
