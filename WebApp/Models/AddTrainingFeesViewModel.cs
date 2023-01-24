using System.ComponentModel.DataAnnotations;


namespace WebApp.Models
{
    public class AddTrainingFeesViewModel
    {

        [Range(typeof(DateTime), "01/01/1900", "01/01/2100", ErrorMessage = "Dodaj datę")]
        public DateTime TrainingDate { get; set; }

        [Required(ErrorMessage = "Wpisz tor")]
        public string Track { get; set; }

        [Required(ErrorMessage = "Wypełnij opłatę")]
        public string Fee { get; set; }
    }
}
