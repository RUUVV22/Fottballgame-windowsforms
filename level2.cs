using GOAT.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GOAT.Formes
{
   
    public partial class level2 : Form
    {
        bool moveup, movedown,movebup, movebdown,space, go = true, go1 = true;
        int speed = 17,bspeed=10;
        int miss = 0,goal=0,heart=0,sec=0;

        public level2()
        {
            InitializeComponent();
        }

        private void KeyisDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                moveup = true;
            }
            if (e.KeyCode == Keys.S)
            {
                movedown = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                movebup = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                movebdown = true;
            }
            if (e.KeyCode == Keys.Space)
            {
                space = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                moveup = false;
            }
            if (e.KeyCode == Keys.S)
            {
                movedown = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                movebup = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                movebdown = false;
            }
            if (e.KeyCode == Keys.Space)
            {
                space = false;
                if (space == false || bspeed == 25)
                {
                   BallTimer.Start();
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (moveup == true && Goalie.Top > 177)
            {
                Goalie.Top -= speed;
            }
            if (movedown == true && Goalie.Top < 300)
            {
                Goalie.Top += speed;
            }
            
            if(space == true)
            {
               bspeed++;
            }
            int x=Ball.Location.X;  
            int y=Ball.Location.Y;
            
            foreach (Control c in this.Controls)
            {
                if (c is PictureBox && (string)c.Tag == "Hit")
                {
                    if (Ball.Bounds.IntersectsWith(c.Bounds))
                    {
                        Ball.Location = new Point(451, 257);
                        heart++;
                       // goal--;
                        BallTimer.Stop();
                        bspeed = 15;
                       //label1.Text = "Player Score: " + goal;
                        
                    }

                }
                if (c is PictureBox && (string)c.Tag == "goal")
                {
                    if (Ball.Bounds.IntersectsWith(c.Bounds))
                    {
                        Ball.Location = new Point(451, 257);
                        goal++;
                        BallTimer.Stop();
                        if (go1 == false)
                        {
                            bingbongBall.Start();
                        }
                        bspeed = 10;
                        label1.Text = "Player Score: " + goal;
                    }

                }
                if (c is PictureBox && (string)c.Tag == "miss")
                {
                    if (Ball.Bounds.IntersectsWith(c.Bounds))
                    {
                        Ball.Location = new Point(451, 257);
                        miss++;
                        BallTimer.Stop();
                        if (go1 == false)
                        {
                            bingbongBall.Start();
                        }
                        bspeed = 10;
                        label2.Text = "Goalie Score: " + miss;
                    }
                }
                }
            if (goal == 2)
            {
                donG.Stop();
                SoccerWin soccerWin = new SoccerWin();
                soccerWin.Show();
                Game.level = 3;
                this.Hide();
            }
            if (miss == 2) {
                donG.Stop();
                GolaieWin golaieWin = new GolaieWin();
                golaieWin.Show();
                Game.level = 3;
                this.Hide();
            }
            if (heart == 1)
            {
                b1.Visible= false;
            }else if (heart == 2)
            {
                b2.Visible= false;
            }else if (heart == 3)
            {
                b3.Visible= false;
                donG.Stop();
                GolaieWin golaieWin=new GolaieWin();
                golaieWin.Show();
                Game.level = 3;
                this.Hide();
            }
            
        }

        private void level2_Load(object sender, EventArgs e)
        {
            Soccer.Image = Properties.Resources.Goat;
            Goalie.Image = Properties.Resources.don;
            int av = Game.PlayerList[Game.idx].avatar;
            if (av == 1)
            {

                Soccer.Image = Properties.Resources.Goat;
            }
            else if (av == 2)
            {

                Soccer.Image = Properties.Resources.dybala;
            }
            else if (av == 3)
            {

                Soccer.Image = Properties.Resources.lefa;
            }
            else if (av == 4)
            {
                Soccer.Image = Properties.Resources.don;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {
            Machine.Enabled = true;
            donG.Enabled = false;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Machine.Enabled = false;
            donG.Enabled = true;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            go = false;
            soccert.Start();
            min5.Stop();
            
            bingbongBall.Stop();
        }

        private void Soccer_Click(object sender, EventArgs e)
        {

        }
        bool isMovingUpb=false;
        private void bingbongBall_Tick(object sender, EventArgs e)
        {
            int x = Ball.Location.X;
            int y = Ball.Location.Y;
            Ball.Location = new Point(x, y + (isMovingUpb ? -1 : 1) * 5);

            if (y <= Up.Top)
            {
                isMovingUpb = false;
            }
            if (y >= 320)//Up.Bottom - Goalie.Height
            {
                isMovingUpb = true;
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            go1 = false;
            bingbongBall.Start();
            min5.Start();
            soccert.Stop();
            

        }

        private void min5_Tick(object sender, EventArgs e)
        {
            BallTimer.Start();

            if (min5.Interval == 5000)
            {

                bingbongBall.Stop();
            }
        }

        private void soccert_Tick(object sender, EventArgs e)
        {
            if (movebup == true && Ball.Top > 177)
            {
                Ball.Top -= speed;

            }
            if (movebdown == true && Ball.Top < 320)
            {
                Ball.Top += speed;

            }
        }

        private void Time_Tick(object sender, EventArgs e)
        {
            sec++;
            label3.Text= sec.ToString();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void Goalie_Click(object sender, EventArgs e)
        {

        }
        bool isMovingUp=false;
        private void Machine_Tick(object sender, EventArgs e)
        {
            int x = Goalie.Location.X;
            int y = Goalie.Location.Y;
            Goalie.Location = new Point(x, y + (isMovingUp ? -1 : 1) * 5);

            if (y <= Up.Top)
            {
                isMovingUp = false;
            }
            if (y >= Up.Bottom - Goalie.Height)
            {
                isMovingUp = true;
            }
            foreach (Control c in this.Controls)
            {
                if (c is PictureBox && (string)c.Tag == "Hit")
                {
                    if (Ball.Bounds.IntersectsWith(c.Bounds))
                    {
                        Ball.Location = new Point(451, 257);
                        heart++;
                        // goal--;
                        BallTimer.Stop();
                        
                        bspeed = 10;
                        //label1.Text = "Player Score: " + goal;

                    }

                }
                if (c is PictureBox && (string)c.Tag == "goal")
                {
                    if (Ball.Bounds.IntersectsWith(c.Bounds))
                    {
                        Ball.Location = new Point(451, 257);
                        goal++;
                        BallTimer.Stop();
                        if (go == false)
                            bingbongBall.Enabled = false;
                        else
                            bingbongBall.Start();
                        bspeed = 10;
                        label1.Text = "Player Score: " + goal;
                    }

                }
                if (c is PictureBox && (string)c.Tag == "miss")
                {
                    if (Ball.Bounds.IntersectsWith(c.Bounds))
                    {
                        Ball.Location = new Point(451, 257);
                        miss++;
                        BallTimer.Stop();
                        if (go == false)
                            bingbongBall.Enabled = false;
                        else
                            bingbongBall.Start();
                        bspeed = 10;
                        label2.Text = "Goalie Score: " + miss;
                    }
                }
            }
            if (miss == 2)
            {
                Machine.Stop();
                GolaieWin golaieWin = new GolaieWin();
                golaieWin.Show();
                Game.level = 2;
                this.Hide();
            }
            if (goal == 2)
            {
                Machine.Stop();
                SoccerWin soccerWin = new SoccerWin();
                soccerWin.Show();
                Game.level = 2;
                this.Hide();
            }
            if (heart == 1)
            {
                b1.Visible = false;
            }
            else if (heart == 2)
            {
                b2.Visible = false;
            }
            else if (heart == 3)
            {
                b3.Visible = false;
                Machine.Stop();
                GolaieWin golaieWin = new GolaieWin();
                golaieWin.Show();
                Game.level = 3;
                this.Hide();
            }
        }

        private void BallTimer_Tick(object sender, EventArgs e)
        {
            soccert.Enabled = false;
            int x = Ball.Location.X;
            int y = Ball.Location.Y;
            if (x >= Up.Left)
                Ball.Location = new Point(x -bspeed, y);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int x = pictureBox3.Location.X;
            int y = pictureBox3.Location.Y;
            if(y>=350)
                y= 121;
            pictureBox3.Location = new Point(x, y + 3);
            int x1 = pictureBox4.Location.X;
            int y1 = pictureBox4.Location.Y;
            if (y1 >= 350)
                y1 = 121;
            pictureBox4.Location = new Point(x1, y1 + 6);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }
    }
}
