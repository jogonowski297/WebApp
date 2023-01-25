using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class AddAccidentNotifiViewModel
    {

        [Required(ErrorMessage = "Wpisz tor")]
        public string Track { get; set; }

        [Required(ErrorMessage = "Opisz co się dzieje na torze")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Wpisz odleglosc na której wystepuje ubytek")]
        public int Distance { get; set; }

    }
}
