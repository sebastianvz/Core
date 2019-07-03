using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatosCore.Models
{
    public class Person
    {
        public Person()
        {
            User = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public ICollection<User> User { get; set; }
    }
}
