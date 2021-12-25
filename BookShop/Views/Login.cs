using BookShop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BookShop.Views
{
    public partial class Login : Form
    {
        BooksDBContext db;
        public Login()
        {
            InitializeComponent();
            db = new BooksDBContext();
            textBox2.PasswordChar = '*';
            textBox1.MaxLength = 14;
            textBox2.MaxLength = 14;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Login and password cannot be empty!");
                return;
            }
            checkDB();

        }
        private void checkDB()
        {
            bool found = false;
            foreach (var user in db.Users.ToList())
            {

                if (user.Username == textBox1.Text && user.Password == textBox2.Text)
                {
                    Mainpage mainpage = new Mainpage(db,user);
                    mainpage.ShowDialog();
                    found = true;
                }
            }
            if (!found)
            {
                MessageBox.Show("Wrong credentials!");
            }
            
        }

       
    }
}
