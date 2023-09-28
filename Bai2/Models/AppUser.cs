using Microsoft.AspNetCore.Identity;
using System;

namespace Bai2.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public DateTime BirthDay { get; set; }
    }
}
