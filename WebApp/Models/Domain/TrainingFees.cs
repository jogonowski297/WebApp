using System.ComponentModel.DataAnnotations;


namespace WebApp.Models.Domain
{
    public class TrainingFees
    {
        public Guid Id { get; set; }

        public Guid MemberId { get; set; }

        public string Track { get; set; }


        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [DataType(DataType.Date)]
        public DateTime TrainingDate { get; set; }

        public string Fee { get; set; }



    }
}
