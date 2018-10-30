using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace AspnetCoreIdentityAndAuthentication.Models
{
    public class CustomUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SocialNum { get; set; }

       // public new int Id { get; set; }
        //public override string Id { get => base.Id; set => base.Id = value; }
    }

    public class AuditUser
    {
        public int RecordStatus { get; set; }
    }
}
