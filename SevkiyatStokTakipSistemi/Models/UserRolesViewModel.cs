using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SevkiyatStokTakipSistemi.Models
{
    public class UserRolesViewModel
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public IEnumerable<string>Roles { get; set; }
    }
}
