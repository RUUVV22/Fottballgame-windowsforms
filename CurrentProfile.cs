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

namespace GOAT.Formes
{
    public partial class CurrentProfile : Form
    {
        public CurrentProfile()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Looby looby=new Looby();
            looby.Show();
            this.Hide();
        }

        private void CurrentProfile_Load(object sender, EventArgs e)
        {
            
            foreach (Player X in Game.PlayerList)
            {
                comboBox1.Items.Add(X.Name);
                
            }
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
