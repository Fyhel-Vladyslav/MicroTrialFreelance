using System.ComponentModel.DataAnnotations;

namespace MicroTrialFreelance.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public bool isRead { get; set; }
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int SolutionId { get; set; }
        public string MesText { get; set; }
        public int MesType { get; set; }

        public string PostDate { get; set; }
    }
}
