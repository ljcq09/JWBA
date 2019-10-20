using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomisedPicture;
using System.Runtime.InteropServices;
using System.Collections;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        //public delegate void StatusUpdateHandler(object sender, HexEventArgs e);
        //public event StatusUpdateHandler myEvent;

        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        private static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool PostMessage(int hWnd, uint Msg, int wParam, int lParam);
        public Form1()
        {
            InitializeComponent();
            createHex();
            //createBee();
            running = false;
            currentHex = -1;
            random = new Random();
            countDown = 15;
            totalActive = 0;
        }

        private CustomisedPic bee;


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void createBee()
        {
            this.bee = new CustomisedPicture.CustomisedPic();

            //
            // bee
            // 
            this.bee.BackColor = System.Drawing.Color.Transparent;
            this.bee.ImageLocation = "C:/Users/alexisja/Desktop/NASA/bee_2.png";

            this.bee.Location = new System.Drawing.Point(627, 280);
            this.bee.Margin = new System.Windows.Forms.Padding(2);
            this.bee.Name = "bee";
            this.bee.Size = new System.Drawing.Size(48, 58);
            this.bee.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bee.TabIndex = 0;
            this.bee.TabStop = false;
            this.bee.Click += new System.EventHandler(this.bee_clicked);

            this.bee.Parent = this.panel1;
            this.panel1.Controls.SetChildIndex(this.bee, 0);

            //Console.WriteLine("bee " + this.panel1.Controls.GetChildIndex(this.bee));

            //this.Controls.Add(this.bee);
        }

        private CustomisedPic[] hexagons;

        private void createHex()
        {
            hexagons = new CustomisedPic[18];
            Size hexSize = new Size(100, 100);
            int hexSideSize = hexSize.Width / 2;

            Point[] offsets = new Point[5] {new Point(0, 0), new Point (Convert.ToInt32(1.5 * hexSideSize), -hexSideSize), new Point(3 * hexSideSize, - 2 * hexSideSize), new Point(Convert.ToInt32(4.5 * hexSideSize), -hexSideSize), new Point(6 * hexSideSize, 0)};

            Point startPoint = new Point(this.ClientSize.Width / 2 - hexSize.Width / 2 - 3 * hexSideSize, this.ClientSize.Height / 2 - hexSize.Height / 2 - 2 * hexSideSize);

            int[] noOfColumnsInRow = {3, 4, 5, 4, 3};
            int noOfHex = 0;

            bool skipped = false;
            Point currentPoint = startPoint;
            for (int index = 0; index < 5; index++)
            {
                currentPoint.X = startPoint.X + offsets[index].X;
                currentPoint.Y = startPoint.Y + offsets[index].Y;

                for (int noOfRows = 0; noOfRows < noOfColumnsInRow[index]; noOfRows++)
                {
                    if (!skipped & noOfHex == 9)
                    {
                        skipped = true;
                        currentPoint.Y = currentPoint.Y + 2 * hexSideSize;
                    }
                    else
                    {
                        hexagons[noOfHex] = new CustomisedPic();
                        hexagons[noOfHex].Size = new Size(104, 102);
                        //hexagons[index].Location = new Point(this.ClientSize.Width/2 - hexagons[index].Size.Width/2, this.ClientSize.Height/2 - hexagons[index].Size.Height/2);
                        hexagons[noOfHex].Location = currentPoint;
                        hexagons[noOfHex].Name = "hexagon" + noOfHex;
                        Console.WriteLine(hexagons[noOfHex].Name);
                        hexagons[noOfHex].Tag = "inactive";
                        hexagons[noOfHex].BackColor = Color.Transparent;
                        //hexagons[noOfHex].ImageLocation = "C:/Users/alexisja/Desktop/NASA/hexagon_no_bg_2.png";
                        hexagons[noOfHex].ImageLocation = "D:/Integration/JamesVsBees/NASA/hexagon_flashing.png";
                        hexagons[noOfHex].SizeMode = PictureBoxSizeMode.StretchImage;
                        hexagons[noOfHex].Visible = false;


                        hexagons[noOfHex].Click += new System.EventHandler((s, e) => this.all_hex_click_handler(s, e, currentHex, countDown));
                        //hexagons[noOfHex].Click += new System.EventHandler(this.all_hex_click_handler);

                        //hexagons[noOfHex].Parent = this;

                        panel1.Controls.Add(hexagons[noOfHex]);
                            

                        //this.Controls.Add(hexagons[noOfHex]);
                        //this.Controls.SetChildIndex(hexagons[noOfHex], index);
                        //hexagons[noOfHex].SetControlZIndex(index);
                        //Console.WriteLine(this.panel1.Controls.GetChildIndex(hexagons[noOfHex]));
                        noOfHex++;
                        //this.setChildIndex(hexagons[noOfHex++], 0);
                        currentPoint.Y = currentPoint.Y + 2 * hexSideSize;
                    }
 
                }
            }
        }


        private void bee_clicked(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void centre_hex_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Point tempPoint = this.PointToClient(new Point(MousePosition.X, MousePosition.Y));
            //tempPoint.X = tempPoint.X - this.bee.Width;
            //tempPoint.Y = tempPoint.Y - this.bee.Height;
            //this.bee.Location = tempPoint;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            //this.bee.Location = new Point(e.X, e.Y);
            this.bee.Left = e.X;
            this.bee.Top = e.Y;
            Refresh();
        }

        private bool running;
        private int currentHex;
        private Random random;

        private void start_rocket_Click(object sender, EventArgs e)
        {
            running = true;
            Console.WriteLine("rocket pressed");
        }


        private int countDown;
        private int totalActive;

        private void pattern_timer_Tick(object sender, EventArgs e)
        {
            if (running & totalActive < 18)
            {
                // Generate only if there is no new position
                if (currentHex == -1)
                {
                    do
                    {
                        currentHex = random.Next(0, 18);
                    }
                    while (hexagons[currentHex].Tag == "active");

                    Console.WriteLine("current hex " + currentHex);

                    hexagons[currentHex].Visible = true;
                    hexagons[currentHex].updateView();
                    this.Refresh();

                    countDown = 30;
                }

                // Enough time has elapsed without pressing the hex
                countDown--;
                if (countDown <= 0)
                {
                    hexagons[currentHex].Visible = false;
                    currentHex = -1;
                }
            }
            if(totalActive == 18)
            {
                label3.Visible = true;
                label4.Visible = true;
            }
        }

        private void all_hex_click_handler(object sender, EventArgs e, int validHex, int count)
        {
            PictureBox hex = (PictureBox) sender;

            Console.WriteLine("Sender is " + hex.Name);
            Console.WriteLine("Hex " +  currentHex);
            Console.WriteLine("Total active " + totalActive);
            if (currentHex != -1 && hex.Name.Equals("hexagon" + currentHex))
            //if (validHex != -1)
            {
                hexagons[currentHex].ImageLocation = "D:/Integration/JamesVsBees/NASA/hexagon_no_bg_2.png";
                hexagons[currentHex].Visible = true;
                hexagons[currentHex].Tag = "active";
                hexagons[currentHex].updateView();
                //this.Refresh();
                currentHex = -1;
                totalActive++;
            }
            else
                Console.WriteLine("The game hasn't started");
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine("clicke clicked");
        }

        private void panel1_MouseMove_1(object sender, MouseEventArgs e)
        {

        }

        private void reset_planet_Click(object sender, EventArgs e)
        {
            running = false;
            currentHex = -1;
            random = new Random();
            countDown = 15;
            totalActive = 0;

            for (int index = 0; index < 18; index++)
            {
                hexagons[index].ImageLocation = "D:/Integration/JamesVsBees/NASA/hexagon_flashing.png";
                hexagons[index].Visible = false;
                hexagons[index].Tag = "inactive";
            }
        }
    }
}
