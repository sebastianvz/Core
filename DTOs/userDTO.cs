using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs
{
   public class userDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? IdPeson { get; set; }
        public string Ditalfinger { get; set; }
    }
}
