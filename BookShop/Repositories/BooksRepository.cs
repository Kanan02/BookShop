using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShop.Repositories
{
    public class BooksRepository
    {
        BooksDBContext dbContext;

        public BooksRepository(BooksDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Books> GetAll()
        {
            return dbContext.Books.ToList();
        }
        public void Add(Books book)
        {
            dbContext.Books.Add(book);
            dbContext.SaveChanges();
        }
        public void Remove(Books book)
        {
            dbContext.Books.Remove(book);
            dbContext.SaveChanges();

        }


    }
}
