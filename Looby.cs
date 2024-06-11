using GOAT.Formes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GOAT
{
    public partial class Looby : Form
    {
        public Looby()
        {
            InitializeComponent();
        }

        private void gameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New_game new_Game=new New_game();
            new_Game.Show();
            this.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Looby_Load(object sender, EventArgs e)
        {

        }

        private void newSoccerPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile();
            profile.Show();
            this.Hide();
            
        }

        private void currentProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New_game new_Game=new New_game();
            new_Game.Show();
            this.Hide();
        }

        
    }
}
