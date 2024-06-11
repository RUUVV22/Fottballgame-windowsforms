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
    public partial class Reblay : Form
    {
        public Reblay()
        {
            InitializeComponent();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New_game new_Game = new New_game();
            new_Game.Show();
            this.Hide();
        }

        private void currentProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentProfile currentProfile = new CurrentProfile();
            currentProfile.Show();
            this.Hide();
        }

        private void newSoccerPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile();
            profile.Show();
            this.Hide();
        }

        private void newGoalieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile();
            profile.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Level1 l1 = new Level1();
            l1.Show();
            this.Visible =false;
        }
    }
}
