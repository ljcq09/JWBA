using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sunshield
{
    public partial class Form1 : Form
    {
        bool right, left;
        bool invulnerability = true;
        int Force;
        bool jumpsPlayer = false;
        bool jumpsSun = false;
        bool particleOn = false;
        bool enemyFire = false;
        bool gameInProgress = true;
        bool shield = false;
        bool shield_2 = true;
        int playerLife = 3;
        HashSet<PictureBox> bulletInGame = new HashSet<PictureBox>();
        HashSet<PictureBox> enemyBulletGame = new HashSet<PictureBox>();
        int limitPlayerJump = 125;
        int bullets = 3;
        int sunlife = 2;
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            pictureBox23.Visible = shield_2;
            //player.Top += 10;

            if (!pictureBox21.Bounds.IntersectsWith(floor.Bounds) && jumpsSun == false)
            {

                pictureBox21.Top += 0;
                //Force--;
            }
            if (right)
            {
                player.Left += 5;
            }

            if (left)
            {
                player.Left -= 5;
            }

            if (jumpsPlayer)
            {
               
                player.Top -= Force;
                Force--;
            }
            if(player.Bounds.IntersectsWith(floor.Bounds))
            {
                //player.Top = this.Size.Height - player.Height;
                //player.Top = floor.Height + 1;
                //player.Top--;
                jumpsPlayer = false;
                player.Image = Image.FromFile(@"D:\Integration\JamesVsSun\sunshield\jamesPosing.png");
            }
            else
            {
                if(!player.Bounds.IntersectsWith(floor.Bounds))
                    player.Top -= Force;
                    Force--;
            }
            //screen.hig
            player.Refresh();
            if (particleOn)
            {
                List<PictureBox> deletedParticles = new List<PictureBox>();
               foreach (PictureBox temp in bulletInGame)
                {

                    temp.Refresh();
                    temp.Left += 5 ;
                    if (pictureBox21.Bounds.IntersectsWith(temp.Bounds))
                    {
                        deletedParticles.Add(temp);
                        if (!invulnerability)
                        {
                            sunlife--;
                            lbtop.Text = "Sun's Life:" + sunlife;
                        }
                        //bulletInGame.Remove(temp);
                    }
                    if(boundariesX1.Bounds.IntersectsWith(temp.Bounds) ||
                        boundariesX2.Bounds.IntersectsWith(temp.Bounds))
                    {
                        deletedParticles.Add(temp);
                    }

                }
               foreach(PictureBox reference in deletedParticles)
                {
                    this.Controls.Remove(reference);
                    bulletInGame.Remove(reference);
                }
                deletedParticles.Clear();
                if (sunlife <= 0)
                {
                    shield = true;
                    foreach (PictureBox particles in enemyBulletGame)
                        {
                        this.Controls.Remove(particles);
                    }
                    enemyBulletGame.Clear();
                    foreach (PictureBox particles in bulletInGame)
                    {
                        this.Controls.Remove(particles);
                    }
                    bulletInGame.Clear();
                    lbtop.Visible = false;
                    pictureBox21.Visible = false;
                    tmgravity.Stop();
                    label2.Visible = true;
                    particleOn = false;
                    enemyFire = false;
                    gameInProgress = false;
                    pictureBox22.Visible = shield;
                }
            }
            if(enemyFire)
            {
                List<PictureBox> deletedParticles = new List<PictureBox>();
                foreach (PictureBox temp in enemyBulletGame)
                {
                    temp.Refresh();
                    temp.Left -= 5;


                    if (player.Bounds.IntersectsWith(temp.Bounds))
                    {
                      
                        playerLife--;

                        

                        switch (playerLife)
                        {
                            case 0: this.Controls.Remove(heart3); break;
                            case 1: this.Controls.Remove(heart2); break;
                            case 2: this.Controls.Remove(heart1); break;
                        }
                      //dd  d  this.Controls.Remove(heart1);
                       deletedParticles.Add(temp);
                       // lbtop.Text = "Sun Life:" + sunlife;
                      // enemyBulletGame.Remove(temp);
                    }

                    if (boundariesX1.Bounds.IntersectsWith(temp.Bounds) ||
                        boundariesX2.Bounds.IntersectsWith(temp.Bounds))
                    {
                        deletedParticles.Add(temp);
                    }


                }
                foreach (PictureBox reference in deletedParticles)
                {
                    this.Controls.Remove(reference);
                    enemyBulletGame.Remove(reference);
                }
                deletedParticles.Clear();
                if (playerLife <= 0)
                {
                    label1.Visible = true;
                    tmgravity.Stop();

                }

            }
            

        }


     

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            player.Left += 10;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            player.Left -= 10;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (limitPlayerJump < player.Top)
            {
                jumpsPlayer = true;
                player.Top -= 10;
               
            }
            else {
                jumpsPlayer = false;
                
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            /*version of jump without using interrupts */
            if (e.KeyCode == Keys.A && gameInProgress)
            {
                left = true;
            }
            else if (e.KeyCode == Keys.D && gameInProgress)
            {
                right = true;
                
            }
            else if (e.KeyCode == Keys.W && gameInProgress)
            {
                var newBullet = new PictureBox
                {
                    Name = "pictureBox",
                    Size = new Size(19, 12),
                    Location = new Point((player.Location.X + player.Width/2) - 1/5* player.Width, (player.Location.Y + player.Height/2) - 1/2 * player.Location.Y),
                    BackColor = Color.Blue,
                    Image = Image.FromFile(@"D:\Integration\JamesVsSun\sunshield\drop.png"),
                };
                
                if (bullets > 0)
                {
                    //display animation of bullet 
                    // particle.Left -= 10;
                    particleOn = true;
                    bulletInGame.Add(newBullet);
                    this.Controls.Add(newBullet);
                    newBullet.BringToFront();
                    bullets--;
                }
                else
                {
                    timer4.Start();
                }
            }
            else if(e.KeyCode == Keys.R)
            {
                Application.Restart();
            }
            if(!jumpsPlayer)
            {
              if(e.KeyCode == Keys.Space && gameInProgress)
                {
                    jumpsPlayer = true;
                    Force = 20;
                    player.Image = Image.FromFile(@"D:\Integration\JamesVsSun\sunshield\walking.png");
                }
            }
       
            //////////////////////////////////////////
            if (e.KeyCode == Keys.Up) {

                timer3.Start();
            
            }
            else if (e.KeyCode == Keys.Right)
            {
                 
                timer1.Start();

            }
            else if (e.KeyCode == Keys.Left)
            {
                    
                timer2.Start();

            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Form1_KeyUp_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                left = false;
            }
            else if (e.KeyCode == Keys.D)
            {
                right = false;
            }
            if (e.KeyCode == Keys.Up)
            {

                timer3.Stop();
                jumpsPlayer = false;

            }

            else if (e.KeyCode == Keys.Right)
            {

                timer1.Stop();

            }
            else if (e.KeyCode == Keys.Left)
            {

                timer2.Stop();

            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {

            var newBullet = new PictureBox
            {
                Name = "pictureBox",
                Size = new Size(19, 12),
                Location = new Point(player.Location.X, player.Location.Y),
                BackColor = Color.Yellow,
                Image = Image.FromFile(@"D:\Integration\JamesVsSun\sunshield\drop.png"),
            };
           
            if (bullets > 0)
            {
                //display animation of bullet 
                // particle.Left -= 10;
                particleOn = true;
                bulletInGame.Add(newBullet);
                this.Controls.Add(newBullet);
                bullets--;
            }
            else
            {
                timer4.Start();
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            bullets = 3;
            timer4.Stop();
            particleOn = false;
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            if (gameInProgress)
            {
                enemyFire = false;
                int xCalculated;
                int yCalculated;
                int middleLocationX = pictureBox21.Location.X + (pictureBox21.Width / 2);
                int middleLocationY = pictureBox21.Location.Y + (pictureBox21.Height / 2);
                for (int i = 0; i < 8; i++)
                {
                    xCalculated = middleLocationX;
                    yCalculated = middleLocationY;

                    shield_2 = false;

                    switch (i)
                    {
                        case 0: yCalculated += (pictureBox21.Height / 2); break;
                        case 1: yCalculated -= (pictureBox21.Height / 2); break;
                        case 2: xCalculated += (pictureBox21.Width / 2); break;
                        case 3: xCalculated -= (pictureBox21.Width / 2); break;
                        case 4: yCalculated += (pictureBox21.Height / 2); xCalculated -= (pictureBox21.Width / 2); break;
                        case 5: yCalculated -= (pictureBox21.Height / 2); xCalculated -= (pictureBox21.Width / 2); break;
                        case 6: yCalculated += (pictureBox21.Height / 2); xCalculated += (pictureBox21.Width / 2); break;
                        case 7: yCalculated -= (pictureBox21.Height / 2); xCalculated += (pictureBox21.Width / 2); break;
                    }
                    var newEnemyBullet = new PictureBox
                    {
                        Name = "pictureBox",
                        Size = new Size(18, 9),
                        Location = new Point(xCalculated, yCalculated),
                        BackColor = Color.Yellow,
                        Image = Image.FromFile(@"D:\Integration\JamesVsSun\sunshield\sunbul.png"),

                    };
                    


                    enemyBulletGame.Add(newEnemyBullet);
                    this.Controls.Add(newEnemyBullet);
                    newEnemyBullet.BringToFront();

                }
                timer5.Stop();
                timer6.Start();
                invulnerability = false;
            }
        }

  

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbtop_Click(object sender, EventArgs e)
        {

        }

        private void textWin_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {

        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            enemyFire = true;
            timer6.Stop();
            timer5.Start();
            invulnerability = true;
            shield_2 = true;
        }
    }
}
