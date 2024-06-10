using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MicroTrialFreelance.Entities
{
    public class DbUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Birthday { get; set; }
        public string Messager { get; set; }
        public string GitHubPageLink { get; set; }
        public int FinishedOrders { get; set; }
    }
}
