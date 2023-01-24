using System.ComponentModel.DataAnnotations;


namespace WebApp.Models
{
    public class AddTrainingFeesViewModel
    {

        [Required(ErrorMessage = "Wypełnij datę")]
        public DateOnly TrainingDate { get; set; }

        [Required(ErrorMessage = "Wypełnij opłatę")]
        public string Fee { get; set; }
    }
}
