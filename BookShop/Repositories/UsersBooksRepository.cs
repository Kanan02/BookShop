using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShop.Repositories
{
    public class UsersBooksRepository
    {
        BooksDBContext dbContext;

        public UsersBooksRepository(BooksDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Books> GetBooksByUserId(int id)
        {
            List<Books> books=new List<Books>();
            foreach (var userbook in dbContext.UsersBooks.Where(x => x.UserId == id).ToList())
            {
                books.Add(dbContext.Books.Where(x => x.Id == userbook.BookId).ToList().First());
            }

            return books;

        }
    }
}
