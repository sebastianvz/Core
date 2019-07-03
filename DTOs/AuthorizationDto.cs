using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs
{
    public class AuthorizationDto
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string Username { get; set; }
        //public List<MenuDto> Menus { get; set; }
        public personDTO PersonInfo { private get; set; }

        //No official properties
        public string FullName => this.PersonInfo != null ? string.Format("{0} {1}", PersonInfo.Name, PersonInfo.LastName) : string.Empty;
    }
}
