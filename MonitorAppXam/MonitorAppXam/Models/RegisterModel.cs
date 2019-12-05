using System;
using System.Collections.Generic;
using System.Text;

namespace MonitorAppXam.Models
{
    class RegisterModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Country { get; set; }
        public string UserRole { get; set; }

    }
}
