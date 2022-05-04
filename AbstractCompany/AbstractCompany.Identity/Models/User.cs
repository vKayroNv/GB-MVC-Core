using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbstractCompany.Identity.Models
{
    public class User : IdentityUser
    {
        [NotMapped]
        public override string PhoneNumber { get; set; } = null!;
        [NotMapped]
        public override bool PhoneNumberConfirmed { get; set; }
        [NotMapped]
        public override bool TwoFactorEnabled { get; set; }
    }
}
