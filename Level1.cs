using GOAT.Classes;
using GOAT.Formes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GOAT
{
    
    public partial class Level1 : Form
    {
        bool moveup, movedown, pressball, movebup, movebdown, go=true,go1=true;
        int bspeed=10;
        int speed = 15;
        int goal = 0;
        int miss = 0;
        int sec=0;
        
        

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            bingbonggoalie.Enabled = true;
            
            Goaleitimer.Enabled = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Goaleitimer.Enabled = true;
            bingbonggoalie.Enabled = false;
            
        }

        bool isMovingUp = false;
        private void timer2_Tick(object sender, EventArgs e)
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

            int x1 = Ball.Location.X;
            int y1 = Ball.Location.Y;
            foreach (Control c in this.Controls)
            {
                if ((string)c.Tag == "Hit")
                {
                    if (Ball.Bounds.IntersectsWith(c.Bounds))
                    {
                        Ball.Location = new Point(453, 251);
                        miss++;
                        Balltimer.Stop();
                        if(go==false)
                            bingbongBall.Enabled = false;
                        else
                        bingbongBall.Start();

                        bspeed = 15;
                        label3.Text = "Goalie Score: " + miss;
                    }

                }
                if (c is PictureBox && (string)c.Tag == "Goal")
                {
                    if (Ball.Bounds.IntersectsWith(c.Bounds))
                    {
                        Ball.Location = new Point(453, 251);
                        goal++;
                        Balltimer.Stop();
                        if (go == false)
                            bingbongBall.Enabled = false;
                        else
                            bingbongBall.Start();
                        bspeed = 15;
                        label2.Text = "Player Score: " + goal;
                    }

                }
            }
            /*if (miss == 2)
            {
                bingbonggoalie.Stop();
                GolaieWin golaieWin = new GolaieWin();
                golaieWin.Show();
                Game.level = 2;
                this.Hide();
            }
            if (goal == 2)
            {
                bingbonggoalie.Stop();
                SoccerWin soccerWin = new SoccerWin();
                soccerWin.Show();
                Game.level = 2;
                this.Hide();
            */
        }

        private void Balltimer_Tick(object sender, EventArgs e)
        {
            soccert.Enabled = false;
                int x = Ball.Location.X;
                int y = Ball.Location.Y;
                if (x >= Up.Left)
                    Ball.Location = new Point(x - bspeed, y);
           
        }
        

        private void Level1_Click(object sender, EventArgs e)
        {
            
        }

        private void Up_Click(object sender, EventArgs e)
        {
           
        }

        private void Level1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        public Level1()
        {
            InitializeComponent();
            //goaltarget=new List<PictureBox> { Up,Down,center};
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        

        private void time_Tick(object sender, EventArgs e)
        {
            sec++;
            
            label4.Text ="Time: "+ sec.ToString();
            
            
            


        }

        private void soccert_Tick(object sender, EventArgs e)
        {
            if (movebup == true && Ball.Top > Up.Top)
            {
                Ball.Top -= speed;

            }
            if (movebdown == true && Ball.Top < 320)
            {
                Ball.Top += speed;

            }
        }
        bool isMovingUpb = false;
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

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            go1 = false;
            bingbongBall.Start();
            min5.Start();
            soccert.Stop();
            Balltimer.Stop();
            

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            go = false;
            bingbongBall.Stop();
            min5.Stop();
            soccert.Start();
        }

        private void min5_Tick(object sender, EventArgs e)
        {
            Balltimer.Start();
            
            if (min5.Interval == 5000)
            {
               
                bingbongBall.Stop();
            }
            
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
                movebup= true;
            }
            if (e.KeyCode == Keys.Down)
            {
                movebdown = true;
            }
            if (e.KeyCode == Keys.Space)
            {
                pressball = true;
                
            }
           
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W )
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
                pressball = false;
                if (pressball == false || bspeed == 20)
                {
                    //min5.Stop();
                    Balltimer.Start();
                }

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            
           
            if (moveup == true && Goalie.Top>Up.Top)
            {
                Goalie.Top -= speed;
            }
            if (movedown == true && Goalie.Top<280)
            {
                Goalie.Top += speed;
            }
            if (pressball == true)
            {
                bspeed++;
                
                
            }

            
            int x = Ball.Location.X;
            int y = Ball.Location.Y;
            foreach (Control c in this.Controls)
            {
                if ((string)c.Tag=="Hit")
                {
                    if (Ball.Bounds.IntersectsWith(c.Bounds))
                    {
                        Ball.Location = new Point(453, 251);
                        miss++;
                        Balltimer.Stop();
                        if (go1 == false)
                        {
                            bingbongBall.Start();
                        }
                        bspeed = 10;
                        label3.Text = "Goalie Score: " + miss;
                    }
                    
                }
                if (c is PictureBox && (string)c.Tag == "Goal")
                {
                    if (Ball.Bounds.IntersectsWith(c.Bounds))
                    {
                        Ball.Location = new Point(453, 251);
                        goal++;
                        Balltimer.Stop();
                        if (go1 == false)
                        {
                            bingbongBall.Start();
                        }
                        bspeed = 10;
                        label2.Text = "Player Score: " + goal;
                    }

                }
            }
            if (miss == 2)
            {
                Goaleitimer.Stop();
               GolaieWin golaieWin=new GolaieWin();
                golaieWin.Show();
                Game.level= 2;
                this.Hide();
            }
            if (goal == 2)
            {
                Goaleitimer.Stop();
                SoccerWin soccerWin=new SoccerWin();
                soccerWin.Show();
                Game.level= 2;
                this.Hide();
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void Level1_Load(object sender, EventArgs e)
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
            else if(av== 3)
            {
                
                Soccer.Image = Properties.Resources.lefa;
            }else if(av==4)
            {
                Soccer.Image= Properties.Resources.don;
            }
        }

       
    }
}
