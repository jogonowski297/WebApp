using System.ComponentModel.DataAnnotations;


namespace WebApp.Models.Domain
{
    public class TrainingFees
    {
        public Guid Id { get; set; }

        public Guid MemberId { get; set; }

        public string Track { get; set; }

        public string TrainingDate { get; set; }

        public string Fee { get; set; }



    }
}
