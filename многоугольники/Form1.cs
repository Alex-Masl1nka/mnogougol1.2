using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace многоугольники
{
    public partial class Form1 : Form

    {
        Draw shape;
        int i, del_X, del_Y;
        bool Dodraw, grab ;
        public Form1()
        {
            InitializeComponent();
            del_X = 0;
            del_Y = 0;
            Dodraw = false;
            grab = false;
            i = 0;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
        } 
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (grab)
            {
                shape.SetX = e.X - del_X;
                shape.SetY = e.Y - del_Y;
                Refresh();
            }
        }

        private void окружностьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            i = 0;
        }

        private void квадратToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            i = 1;
        }

        private void треугольникToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            i = 2;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (Dodraw && shape.check(e.X, e.Y))
            {
                if (e.Button == MouseButtons.Left)
                {
                    del_X = e.X - shape.SetX;
                    del_Y = e.Y - shape.SetY;
                    grab = true;
                }
                if(e.Button==MouseButtons.Right)
                {
                    shape = null;
                    Dodraw = false;
                    grab = false;
                    Refresh();
                }
            }
            else
            {
                Dodraw = true;
                switch (i)
                {
                    case 0: shape = new circle(e.X, e.Y); break; 
                    case 1: shape = new square(e.X, e.Y); break;
                    case 2: shape = new triangle(e.X, e.Y); break;
                    default: shape = new circle(e.X, e.Y); break;
                }
                Refresh();
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if(Dodraw)
            {
                Graphics g = e.Graphics;
                shape.DrawFigure(g);
            }

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if(grab)
            {
                grab = false;
                DoubleBuffered = true;
                Refresh();
            }
        }
    }
}
