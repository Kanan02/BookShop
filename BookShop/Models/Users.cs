using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookShop.Models
{
    public partial class Users
    {
        public Users()
        {
            UsersBooks = new HashSet<UsersBooks>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? Balance { get; set; }

        public virtual ICollection<UsersBooks> UsersBooks { get; set; }
    }
}
