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
    public partial class New_game : Form
    {
        public New_game()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Profile profile=new Profile();
            profile.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Looby looby=new Looby();
            looby.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                for (int i = 0; i < Game.PlayerList.Count(); i++)
                {
                    Player X = Game.PlayerList[i];
                    if (comboBox1.SelectedItem == X.Name)
                    {
                        Game.idx = i;
                        //Game.cur_Duration = 0;
                        // Game.cur_Score = 0;
                        Level1 level = new Level1();
                        level.Show();
                        this.Hide();
                    }
                }


            }

            else
            {
                MessageBox.Show("You Should Selected Profile or Sign up ");
                comboBox1.SelectedItem = null;
                comboBox1.Focus();
            }
            
        }

        private void New_game_Load(object sender, EventArgs e)
        {
            foreach (Player X in Game.PlayerList)
            {
                comboBox1.Items.Add(X.Name);
            }
        }
    }
}
