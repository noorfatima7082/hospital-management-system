using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Management_System
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

             
        private void loginbutton_Click(object sender, EventArgs e)
        {
            string username = usernametext.Text;
            string password = passwordtext.Text;
            if (username == "Admin" && password == "Admin123")
            {
                //MessageBox.Show("You Enter a Correct Login Detail");
                this.Hide();
                Dashboard db = new Dashboard();
                db.Show();

            }
            else if (username == "" || password == "")
            {
                MessageBox.Show("Incomplete Login Feilds");
            }
            else if (username != "Admin" && password != "Admin123")
            {
                MessageBox.Show(" Enter Wrong Login Detail (Username and Password)");
            }
            else if (username != "Admin")
            {
                MessageBox.Show("Wrong Username");
            }
            else if (password != "Admin123")
            {
                MessageBox.Show("Wrong Password");
            }

        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                passwordtext.UseSystemPasswordChar = false;
            }
            else
            {
                passwordtext.UseSystemPasswordChar = true;
            }
        }
     
    }
}
