using System.ComponentModel.DataAnnotations;


namespace WebApp.Models.Domain
{
    public class AccidentNotifi
    {

        public Guid Id { get; set; }

        public string Track { get; set; }

        public string Description { get; set; }

        public int Distance { get; set; }


    }
}
