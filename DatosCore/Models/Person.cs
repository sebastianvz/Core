using System;
using System.Collections.Generic;

namespace DatosCore.Models
{
    public partial class Person
    {
        public Person()
        {
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public ICollection<User> User { get; set; }
    }
}
