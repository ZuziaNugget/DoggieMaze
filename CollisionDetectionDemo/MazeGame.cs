using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollisionDetectionDemo
{
    //the interger for movement speed and the booleans that tell you if a direction is true or false
    public partial class MazeGame : Form
    {
        bool moveLeft, moveRight, moveUp, moveDown;
        int speed = 6;

        public MazeGame()
        {
            InitializeComponent();
        }

        private void MainTimerEvent(object sender, EventArgs e)
        {
            //moves entity arround with a sertain speed
            if (moveLeft == true && Doggie.Left > 5)
            {
                Doggie.Left -= speed;
            }
            if (moveRight == true && Doggie.Left < 1145)
            {
                Doggie.Left += speed;
            }
            if (moveUp == true && Doggie.Top > 5)
            {
                Doggie.Top -= speed;
            }
            if (moveDown == true && Doggie.Top < 725)
            {
                Doggie.Top += speed;
            }

            //detects collision and then prevents player from moving through walls
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "Object")
                {
                    if (Doggie.Bounds.IntersectsWith(x.Bounds))
                    {
                        x.BackColor = Color.MediumPurple;

                        if (moveLeft == true)
                        {
                            Doggie.Left += speed;
                        }
                        if (moveRight == true)
                        {
                            Doggie.Left -= speed;
                        }
                        if (moveUp == true)
                        {
                            Doggie.Top += speed;
                        }
                        if (moveDown == true)
                        {
                            Doggie.Top -= speed;
                        }
                    }
                    else
                    {
                        x.BackColor = Color.MediumPurple;
                    }
                }
            }

            foreach (Control x in this.Controls)
            {
                if(x is PictureBox && (string)x.Tag == "Door")
                {
                    if(Doggie.Bounds.IntersectsWith(x.Bounds))
                    {
                        timer1.Stop();

                        if (moveLeft == true)
                        {
                            Doggie.Left += speed;
                        }
                        if (moveRight == true)
                        {
                            Doggie.Left -= speed;
                        }
                        if (moveUp == true)
                        {
                            Doggie.Top += speed;
                        }
                        if (moveDown == true)
                        {
                            Doggie.Top -= speed;
                        }

                        DialogResult userChoiseFinish = MessageBox.Show("You did it!!!\nDoggie has been fed?", "", MessageBoxButtons.YesNo);
                        if (userChoiseFinish == DialogResult.Yes)
                        {
                            timer1.Start();
                            x.Dispose();
                        }
                        if(userChoiseFinish == DialogResult.No)
                        {
                            timer1.Start();
                        }
                    }
                }


                if (x is PictureBox && (string)x.Tag == "Food")
                {
                    if (Doggie.Bounds.IntersectsWith(x.Bounds))
                    {
                        x.BackColor = Color.Cornsilk;

                        timer1.Stop();

                        if (moveLeft == true)
                        {
                            Doggie.Left += speed;
                        }
                        if (moveRight == true)
                        {
                            Doggie.Left -= speed;
                        }
                        if (moveUp == true)
                        {
                            Doggie.Top += speed;
                        }
                        if (moveDown == true)
                        {
                            Doggie.Top -= speed;
                        }

                        DialogResult userChoiseFinish = MessageBox.Show("You did it!!!\nDoggie has been fed?", "", MessageBoxButtons.OK);
                        if(userChoiseFinish == DialogResult.OK)
                        {
                            this.Close();
                        }
                    }
                    else
                    {
                        x.BackColor = Color.Cornsilk;
                    }
                }
            }
        }


        //MazeGame_KeyDown moves entity when arrow keys are pressed
        private void MazeGame_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                moveLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                moveRight = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                moveDown = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                moveUp = true;
            }
        }

        //MazeGame_KeyUp stops entity from moving when arrow keys aren't pressed
        public void MazeGame_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                moveLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                moveRight = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                moveDown = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                moveUp = false;
            }
        }
    }
}
