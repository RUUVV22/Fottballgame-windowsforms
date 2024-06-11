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
    public partial class GolaieWin : Form
    {
        public GolaieWin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Game.level == 2)
            {
                level2 level2 = new level2();
                level2.Show();
                this.Hide();
            }
            if (Game.level == 3)
            {
                level3 level3 = new level3();
                level3.Show();
                this.Hide();
            }
            if (Game.level == 4)
            {
                button1.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Looby looby = new Looby();
            looby.Show();
            this.Hide();
        }
    }
}
