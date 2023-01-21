using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class AddMemberViewModel
    {
        [Required(ErrorMessage = "Wypełnij imię")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Wypełnij nazwisko")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Wypełnij email")]
        public string Email { get; set; }

        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Wprowadz poprawny numer telefonu ( 111-222-333 )")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Wypełnij rodzaj pojazdu")]
        public string Vehicle { get; set; }

        [Required(ErrorMessage = "Wypełnij markę")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Wypełnij model")]
        public string Model { get; set; }
    }
}
