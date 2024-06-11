using GOAT.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GOAT.Formes
{
    public partial class Profile : Form
    {
        int avatar = 0;
        string gender = "",Type="";
        public Profile()
        {
            InitializeComponent();
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Profile_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            gender = "Male";
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            avatar= 4;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            gender = "FeMale";
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            avatar = 1;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            avatar = 2;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            avatar = 3;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Type = "Soccer ";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Type = "Goalie ";
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = UserName.Text;
            string age = Age.Text;
            if (Type == "" || UserName.Text == null || Age.Text == null || gender == "" || avatar == 0)
            {
                MessageBox.Show("Please Fill in All Fields");
            }
            else
            {
                Player p = new Player(Type,name, gender, age, avatar);
                Game.PlayerList.Add(p);
                new Looby().Show();
                this.Hide();
            }
        }
    }
}
