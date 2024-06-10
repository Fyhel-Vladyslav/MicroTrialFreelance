using System;
using System.ComponentModel.DataAnnotations;

namespace MicroTrialFreelance.Models
{
    public class Solution
    {
        [Key]
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public int OrderId { get; set; }
        public bool wasRead { get; set; }
        public string GitHubLink { get; set; }
        public string Description { get; set; }

    }
}
