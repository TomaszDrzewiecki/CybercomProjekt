using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace TomaszDrzewieckiCybercom2017.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Display(Name = "Nazwisko Autora")]
        public int AuthorId { get; set; }
        [Display(Name = "Tytuł Książki")]
        [Required(ErrorMessage = "Podaj Tytuł")]
        public string Title { get; set; }
        [Display(Name = "Numer ISBN")]
        [Required(ErrorMessage = "Podaj numer ISBN")]
        public int ISBN { get; set; }
        //data wydania w zakresie 1705-2080 ustawiona także w datepicker'ze!
        [Required(ErrorMessage = "Podaj liczba z zakresu 1905-2080")]
        [Range(1705, 2080, ErrorMessage = "tylko wartość z określonego przedziału")]
        [Display(Name = "Data Wydania")]
        public int ReleaseDate { get; set; }

    }
}