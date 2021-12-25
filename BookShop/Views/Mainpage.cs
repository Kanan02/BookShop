using BookShop.Models;
using BookShop.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BookShop.Views
{
    public partial class Mainpage : Form
    {

        Users _user;
        BooksDBContext _db;
      
        public Mainpage(BooksDBContext db,Users user)
        {
            InitializeComponent();
            _user = user;
            _db = db;
            LoadBooks();
            label2.Text = $"{user.Username}'s account";
        }

        private void label2_Click(object sender, EventArgs e)
        {


        }
        void LoadBooks()
        {
            UsersBooksRepository repository = new UsersBooksRepository(_db);
            listBox1.Items.AddRange(repository.GetBooksByUserId(_user.Id).ToArray());
        }
    }
}
