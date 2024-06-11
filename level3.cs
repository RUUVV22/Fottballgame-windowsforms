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
    public partial class level3 : Form
    {
        bool go = true, go1 = true;
        Random rand= new Random();
        bool moveup, movedown, movebup, movebdown, space;
        bool goalieleft, golaieright, soccerleft, soccerright;
        int speed = 15,bspeed=15;
        int miss = 0, goal = 0,heart=0,sec=0;
        public level3()
        {
            InitializeComponent();
            
            this.Goalie.BringToFront();
            this.Ball.BringToFront();
            this.basket2.BringToFront();
            this.basket1.BringToFront();
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            go = false;
            Ballbing.Stop();
            min5.Stop();
            Soccermove.Start();
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
                if (space == false || bspeed == 20)
                {
                    BallTimer.Start();
                }
            }
            if (e.KeyCode == Keys.A)
            {
                goalieleft = false;
            }
            if (e.KeyCode == Keys.D)
            {
                golaieright = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                soccerleft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                soccerright = false;
            }
        }

        private void Basket_Tick(object sender, EventArgs e)
        {
            int x = basket2.Location.X;
            int y = basket2.Location.Y;
            if (y >= 350)
                y = 122;
            basket2.Location = new Point(x, y + 3);
            int x1 = basket1.Location.X;
            int y1 = basket1.Location.Y;
            if (y1 >= 350)
                y1 = 122;
            basket1.Location = new Point(x1, y1 + 6);
        }

        private void BallTimer_Tick(object sender, EventArgs e)
        {
            Soccermove.Stop();
            int x = Ball.Location.X;
            int y = Ball.Location.Y;
             if (x >= Up.Left)
            Ball.Location = new Point(x - bspeed, y);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void dont_Tick(object sender, EventArgs e)
        {
            if (moveup == true && Goalie.Top > 200)
            {
                Goalie.Top -= speed;
            }
            if (movedown == true && Goalie.Top < 330)
            {
                Goalie.Top += speed;
            }
            if (goalieleft == true && Goalie.Left > 146)
            {
                Goalie.Left -= speed;
            }
            if (golaieright == true && Goalie.Left < 200)
            {
                Goalie.Left += speed;
            }
            if (space == true)
            {
                bspeed++;
            }

            
            int x = Ball.Location.X;
            int y = Ball.Location.Y;
            int x1 = rand.Next(365, 380);
            int y1 = rand.Next(200, 337);
            int x2 = rand.Next(237,279);
            int y2 = rand.Next(200,337);
            int x3 = rand.Next(147,475);
            int y3 = rand.Next(200,337);
            foreach (Control c in this.Controls)
            {
                if (c is PictureBox && (string)c.Tag == "Hit")
                {
                    if (Ball.Bounds.IntersectsWith(c.Bounds))
                    {
                        Ball.Location = new Point(479, 284);
                        heart++;
                        //goal--;
                        BallTimer.Stop();
                        bspeed=10;
                        //label1.Text = "Player Score: " + goal;
                    }

                }
                if (c is PictureBox && (string)c.Tag == "goal")
                {
                    if (Ball.Bounds.IntersectsWith(c.Bounds))
                    {
                        Ball.Location = new Point(479, 284);
                        goal++;
                        BallTimer.Stop();
                        if (go1 == false)
                        {
                            Ballbing.Start();
                        }
                        bspeed = 10;
                        label1.Text = "Player Score: " + goal;
                    }

                }
                if (c is PictureBox && (string)c.Tag == "miss")
                {
                    if (Ball.Bounds.IntersectsWith(c.Bounds))
                    {
                        Ball.Location = new Point(479, 284);
                        miss++;
                        BallTimer.Stop();
                        if (go1 == false)
                        {
                            Ballbing.Start();
                        }
                        bspeed =10;   
                        label2.Text = "Goalie Score: " + miss;
                    }
                }
                if (c is PictureBox && (string)c.Tag == "sink")
                {
                    if (Ball.Bounds.IntersectsWith(c.Bounds))
                    {
                        Ball.Location = new Point(479, 284);
                        Sink.Location = new Point(x1,y1);
                        // miss++;
                        heart++;
                        BallTimer.Stop();
                        bspeed=10;
                        //label2.Text = "Goalie Score: " + miss;
                    }
                }
                if (c is PictureBox && (string)c.Tag == "fan")
                {

                    if (Ball.Bounds.IntersectsWith(c.Bounds))
                    {
                        fan.Location = new Point(x2, y2);
                        Ball.Location = new Point(x3, y3);
                        heart++;
                        //Ball.Location = new Point(x+10, y);
                         BallTimer.Stop();
                        //goal--;
                        BallTimer.Stop();
                        bspeed = 10;
                        //label1.Text = "Player Score: " + goal;
                    }
                }
               
                    if (c is PictureBox && (string)c.Tag == "miss")
                    {
                        if (reward1.Bounds.IntersectsWith(c.Bounds))
                        {
                        
                            reward1.Location = new Point(x, y + 5);
                            reward1.Location = new Point(177, 64);
                        
                            reward11.Stop();
                            timer1.Start();
                    }
                    }
                if (c is PictureBox && (string)c.Tag == "lefa")
                {
                    if (reward2.Bounds.IntersectsWith(c.Bounds))
                    {

                        reward2.Location = new Point(x, y + 5);
                        reward2.Location = new Point(585, 64);
                        bspeed= 15;//no
                        reward11.Stop();
                        timer1.Start();
                    }
                }

            }
            if (goal == 2)
            {
                dont.Stop();
                SoccerWin soccerWin = new SoccerWin();
                soccerWin.Show();
                Game.level = 4;
                this.Hide();
            }
            if (miss == 2)
            {
                dont.Stop();
                GolaieWin golaieWin = new GolaieWin();
                golaieWin.Show();
                Game.level = 4;
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
                dont.Stop();
                GolaieWin golaieWin = new GolaieWin();
                golaieWin.Show();
                Game.level = 4;
                this.Hide();
            }
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_2(object sender, EventArgs e)
        {

        }

        bool reward1right = false;//false = left
        bool reward1right1 = false;//false = left
        private void timer1_Tick(object sender, EventArgs e)
        {
            //reward.Stop();
            int x = reward1.Location.X;
            int y = reward1.Location.Y;
            reward1.Location = new Point(x + ((reward1right ? 1 : -1) * 5), y);

            if (x <= 146)
            {
                reward1right = true;
            }
            if (x >= 225)
            {
                reward1right = false;
            }
            
            int x1 = reward2.Location.X;
            int y1 = reward2.Location.Y;
            reward2.Location = new Point(x1 + ((reward1right1 ? 1 : -1) * 5), y1);

            if (x1 <= 525)
            {
                reward1right1 = true;
            }
            if (x1 >= 610)
            {
                reward1right1 = false;
            }
            //reward.Start();
        }

        private void reward_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            gsec.Start();
            if (reward11.Interval == 3000)
                reward11.Interval = 60;
            /////////////goalie
                int x = reward1.Location.X;
                int y = reward1.Location.Y;
                if (y <= 264)
                    reward1.Location = new Point(x, y + 5);
            ///////////soccer
            int x1 = reward2.Location.X;
            int y1 = reward2.Location.Y;
            if (y1 <= 264)
                reward2.Location = new Point(x1, y1 + 5);

        }
        bool isMovingUp = false;
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

            int x0 = Ball.Location.X;
            int y0 = Ball.Location.Y;
            int x1 = rand.Next(365, 380);
            int y1 = rand.Next(200, 337);
            int x2 = rand.Next(237, 279);
            int y2 = rand.Next(200, 337);
            int x3 = rand.Next(147, 475);
            int y3 = rand.Next(200, 337);
            foreach (Control c in this.Controls)
            {
                if (c is PictureBox && (string)c.Tag == "Hit")
                {
                    if (Ball.Bounds.IntersectsWith(c.Bounds))
                    {
                        Ball.Location = new Point(479, 284);
                        heart++;
                        //goal--;
                        BallTimer.Stop();
                        if (go == false)
                            Ballbing.Enabled = true;
                        else
                            Ballbing.Stop();
                        bspeed = 10;
                        //label1.Text = "Player Score: " + goal;
                    }

                }
                if (c is PictureBox && (string)c.Tag == "goal")
                {
                    if (Ball.Bounds.IntersectsWith(c.Bounds))
                    {
                        Ball.Location = new Point(479, 284);
                        goal++;
                        BallTimer.Stop();
                        if (go == false)
                            Ballbing.Enabled = true;
                        else
                            Ballbing.Stop();
                        bspeed = 10;
                        label1.Text = "Player Score: " + goal;
                    }

                }
                if (c is PictureBox && (string)c.Tag == "miss")
                {
                    if (Ball.Bounds.IntersectsWith(c.Bounds))
                    {
                        Ball.Location = new Point(479, 284);
                        miss++;
                        BallTimer.Stop();
                        if (go == false)
                            Ballbing.Enabled = true;
                        else
                            Ballbing.Stop();
                        bspeed = 10;
                        label2.Text = "Goalie Score: " + miss;
                    }
                }
                if (c is PictureBox && (string)c.Tag == "sink")
                {
                    if (Ball.Bounds.IntersectsWith(c.Bounds))
                    {
                        Ball.Location = new Point(479, 284);
                        Sink.Location = new Point(x1, y1);
                        // miss++;
                        heart++;
                        BallTimer.Stop();
                        bspeed = 10;
                        //label2.Text = "Goalie Score: " + miss;
                    }
                }
                if (c is PictureBox && (string)c.Tag == "fan")
                {

                    if (Ball.Bounds.IntersectsWith(c.Bounds))
                    {
                        fan.Location = new Point(x2, y2);
                        Ball.Location = new Point(x3, y3);
                        heart++;
                        //Ball.Location = new Point(x+10, y);
                        BallTimer.Stop();
                        //goal--;
                        BallTimer.Stop();
                        bspeed = 10;
                        //label1.Text = "Player Score: " + goal;
                    }
                }

                if (c is PictureBox && (string)c.Tag == "miss")
                {
                    if (reward1.Bounds.IntersectsWith(c.Bounds))
                    {

                        reward1.Location = new Point(x0, y0 + 5);
                        reward1.Location = new Point(177, 64);

                        reward11.Stop();
                        timer1.Start();
                    }
                }
                if (c is PictureBox && (string)c.Tag == "lefa")
                {
                    if (reward2.Bounds.IntersectsWith(c.Bounds))
                    {

                        reward2.Location = new Point(x0, y0 + 5);
                        reward2.Location = new Point(585, 64);
                        bspeed = 15;//no
                        reward11.Stop();
                        timer1.Start();
                    }
                }

            }
            if (goal == 2)
            {
                Machine.Stop();
                SoccerWin soccerWin = new SoccerWin();
                soccerWin.Show();
                Game.level = 4;
                this.Hide();
            }
            if (miss == 2)
            {
                Machine.Stop();
                GolaieWin golaieWin = new GolaieWin();
                golaieWin.Show();
                Game.level = 4;
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
                Game.level = 4;
                this.Hide();
            }
        }
        bool isMovingUpb = false;

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            go1 = false;
            Ballbing.Start();
            min5.Start();
            Soccermove.Stop();

        }

        private void min5_Tick(object sender, EventArgs e)
        {
            BallTimer.Start();

            if (min5.Interval == 5000)
            {

               Ballbing.Stop();
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Machine.Start();
            dont.Stop();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            dont.Start();
            Machine.Stop();
        }

        private void Ballbing_Tick(object sender, EventArgs e)
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

        private void gsec_Tick(object sender, EventArgs e)
        {
            reward11.Start();
            if (gsec.Interval == 5000)
            {
                timer1.Stop();
            }
        }

        private void Soccermove_Tick(object sender, EventArgs e)
        {
            if (movebup == true && Ball.Top > 200)
            {
                Ball.Top -= speed;

            }
            if (movebdown == true && Ball.Top < 360)
            {
                Ball.Top += speed;

            }
            if (soccerleft== true && Soccer.Left > 525)
            {
                Soccer.Left -= speed;

            }
            if (soccerright== true && Soccer.Left< 610)
            {
                Soccer.Left += speed;

            }
        }

        private void time_Tick(object sender, EventArgs e)
        {
            sec++;
            label3.Text = "Time: "+sec.ToString();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void Ball_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void level3_Load(object sender, EventArgs e)
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

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void KeyIsDown(object sender, KeyEventArgs e)
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
            if (e.KeyCode == Keys.A)
            {
                goalieleft= true;
            }
            if (e.KeyCode == Keys.D)
            {
                golaieright = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                soccerleft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                soccerright = true;
            }
        }
    }
}
