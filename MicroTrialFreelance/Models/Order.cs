using System;
using System.ComponentModel.DataAnnotations;

namespace MicroTrialFreelance.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Difficulty { get; set; }
        public int Status { get; set; }
        public int OwnerId { get; set; }
        public int CreatorId { get; set; }
        public string ExampleLink { get; set; }
        public string GitHubLink { get; set; }
        public string DbLink { get; set; }
        public string PostDate { get; set; }

        public string SecondaryTasks { get; set; }
        public string MainTask { get; set; }
        public string Description { get; set; }

    }
}
