using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookShop.Models
{
    public partial class Books
    {
        public Books()
        {
            UsersBooks = new HashSet<UsersBooks>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? AuthorId { get; set; }
        public int? Pages { get; set; }
        public int? GenreId { get; set; }
        public double? Price { get; set; }
        public bool? IsPart { get; set; }
        public int? Year { get; set; }

        public virtual Authors Author { get; set; }
        public virtual Genres Genre { get; set; }
        public virtual ICollection<UsersBooks> UsersBooks { get; set; }
    }
}
