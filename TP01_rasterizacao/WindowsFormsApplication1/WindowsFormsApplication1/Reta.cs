using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Reta
    {
        private double x1, x2, y1, y2, dx, dy, m;

        public Reta()
        {
            this.x1 = 0.0;
            this.x2 = 0.0;
            this.y1 = 0.0;
            this.y2 = 0.0;
            this.dx = 0;
            this.dy = 0;
            this.m = 0.0;
        }

        public Reta (double x1, double y1, double x2, double y2)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.y1 = y1;
            this.y2 = y2;
            this.dx = x2 - x1;
            this.dy = y2 - y1;
            this.m = (this.dy/this.dx);
        }

        public double GetX1()
        {
            return this.x1;
        }

        public double GetX2()
        {
            return this.x2;
        }

        public double GetY1()
        {
            return this.y1;
        }

        public double GetY2()
        {
            return this.y2;
        }

        public void SetX1(double x)
        {
            this.x1 = x;
        }

        public void SetX2(double x)
        {
            this.x2 = x;
        }

        public void SetY1(double y)
        {
            this.y1 = y;
        }

        public void SetY2(double y)
        {
            this.y2 = y;
        }

        public double GetDx()
        {
            return this.dx;
        }

        public double GetDy()
        {
            return this.dy;
        }

        public void SetDx(double dx)
        {
            this.dx = dx;
        }

        public void SetDy(double dy)
        {
            this.dy = dy;
        }

        public double GetCoeficienteAngular()
        {
            return this.m;
        }

        public void SetCoeficienteAngular(double m)
        {
            this.m = m;
        }
    }
}
