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
        //Draw shape;
        int i, del_X, del_Y, amount;
        bool Dodraw, grab, NotNull=false;
        List<Draw> versh;
        public Form1()
        {
            InitializeComponent();
            del_X = 0;
            del_Y = 0;
            Dodraw = false;
            grab = false;
            versh = new List<Draw>();
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
                versh[amount].SetX = e.X - del_X;
                versh[amount].SetY = e.Y - del_Y;
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
            for (int j = 0; j < versh.Count; j++)
                {
                amount = j;
                NotNull = true;
                }
            if (Dodraw && versh[amount].check(e.X, e.Y)&& NotNull == true)
            {
                if (e.Button == MouseButtons.Left)
                {
                    del_X = e.X - versh[amount].SetX;
                    del_Y = e.Y - versh[amount].SetY;
                    grab = true;
                }
                if (e.Button == MouseButtons.Right)
                {
                    versh.RemoveAt(amount);
                    if (versh.Count == 0)
                    {
                        Dodraw = false;
                        NotNull = false;
                    }
                }
            }
            else
            {
                switch (i)
                {
                    case 0: versh.Add(new circle(e.X, e.Y)); break;
                    case 1: versh.Add(new square(e.X, e.Y)); break;
                    case 2: versh.Add(new triangle(e.X, e.Y)); break;
                    default: versh.Add(new circle(e.X, e.Y)); break;
                }
                Dodraw = true;
            }
            Refresh();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if(Dodraw)
            {
                for (int j = 0; j < versh.Count; j++)
                {
                    Graphics g = e.Graphics;
                    versh[j].DrawFigure(g);
                }
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if(grab)
            {
                grab = false;
                Refresh();
            }
        }
    }
}
