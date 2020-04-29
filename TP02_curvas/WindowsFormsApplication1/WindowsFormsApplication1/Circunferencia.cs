using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Circunferencia
    {
        private double raio;
        private double x;
        private double y;
        private double xc;
        private double yc;

        public Circunferencia()
        {
            this.raio = 0.0;
            this.x = 0.0;
            this.y = 0.0;
            this.xc = 0.0;
            this.yc = 0.0;
        }

        public Circunferencia(double x, double y, double xc, double yc)
        {
            this.raio = Math.Sqrt(Math.Pow((x - xc), 2.0) + Math.Pow((y - yc), 2.0));
            this.x = x;
            this.y = y;
            this.xc = xc;
            this.yc = yc;
        }

        public double GetRaio()
        {
            return this.raio;
        }

        public void SetRaio(double x, double y, double xc, double yc)
        {
            this.raio = Math.Sqrt( Math.Pow( (x - xc), 2.0 ) + Math.Pow( (y - yc), 2.0 ) );
        }

        public double GetX()
        {
            return this.x;
        }

        public void SetX(double x)
        {
            this.x = x;
        }

        public double GetY()
        {
            return this.y;
        }

        public void SetY(double y)
        {
            this.y = y;
        }

        public double GetXc()
        {
            return this.xc;
        }

        public void SetXc(double x)
        {
            this.xc = x;
        }

        public double GetYc()
        {
            return this.yc;
        }

        public void SetYc(double y)
        {
            this.yc = y;
        }
    }
}
