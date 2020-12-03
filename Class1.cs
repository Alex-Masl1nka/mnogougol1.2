using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace многоугольники
{
    public abstract class Draw
    {
        protected int x, y;
        protected static int r;
        public Draw(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        static Draw()
        { r = 25; }
        public int SetX { get { return x; } set { x = value; } }
        public int SetY { get { return y; } set { y = value; } }
        public abstract void DrawFigure(Graphics graf);
        abstract public bool check(int x, int y);
    }
    public class circle : Draw
    {
        SolidBrush br = new SolidBrush(Color.Green);
        public circle(int x, int y) : base(x, y)
        {
        }
        public override void DrawFigure(Graphics graf)
        {
            graf.FillEllipse ( new SolidBrush(Color.Green), x - (r / 2), y - (r / 2), r, r);
        }
        public override bool check(int x, int y)
        {
            if (Math.Sqrt(Math.Pow(x - this.x - (r / 2), 2) + Math.Pow(y - this.y - (r / 2), 2)) < r) return true;
            else return false;
        }
    }
    public class square : Draw
    {
        SolidBrush br = new SolidBrush(Color.Green);
        public square(int x, int y) : base(x, y)
        {
        }
        public override void DrawFigure(Graphics graf)
        {
            graf.FillRectangle(new SolidBrush(Color.Green), x - (r / 2), y - (r / 2), r, r);
        }
        public override bool check(int x, int y)
        {
            if (this.x - (r / 2) < x && this.x + (r / 2) > x && this.y - (r / 2) < y && this.y + (r / 2) > y) return true;
            else return false;
        }
    }
    public class triangle : Draw
    {
        SolidBrush br = new SolidBrush(Color.Green);
        public triangle(int x, int y) : base(x, y)
        {
        }
        public override void DrawFigure(Graphics graf)
        {
            Point point1 = new Point(x - r, y + (r / 2));
            Point point2 = new Point(x + r, y + (r / 2));
            Point point3 = new Point(x, y - r);
            Point[] Points = { point1, point2, point3 };
            graf.FillPolygon(new SolidBrush(Color.Green), Points);
        }
        public override bool check(int x, int y)
        {
            if (this.x - (r / 2) < x && this.x + (r / 2) > x && this.y - r < y && this.y + (r / 2) > y) return true;
            else return false;
        }
    }
}

