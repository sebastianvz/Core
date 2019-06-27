using System;
using System.Collections.Generic;

namespace DatosCore.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? IdPeson { get; set; }
        public string Ditalfinger { get; set; }

        public Person person { get; set; }
    }
}
