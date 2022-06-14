using System;
using Microsoft.AspNetCore.Identity;

namespace EndProjectOrgani.Entities
{
    public class AppUser:IdentityUser<int>
    {
        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
