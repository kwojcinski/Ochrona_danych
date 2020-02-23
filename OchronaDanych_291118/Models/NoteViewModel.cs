using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OchronaDanych_291118.Models
{
    public class NoteViewModel : Note
    {
        public string Emails { get; set; }
    }
}
