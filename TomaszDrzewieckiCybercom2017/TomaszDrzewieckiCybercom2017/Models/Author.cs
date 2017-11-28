using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace TomaszDrzewieckiCybercom2017.Models
{
    public class Author
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Podaj Imię")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Podaj Nazwisko")]
        public string Surname { get; set; }
        
    }
}