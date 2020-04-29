using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class tela : Form
    {
        Bitmap areaDesenho;
        int quantidadeClick; // conta a quantidade de cliques na tela. Se == 4, realiza as devidas operações

        Ponto[] pontos = new Ponto[4]; // Array de Points contendo todos os pontos que formam a curva
        Ponto ab, bc, cd, abbc, bccd, dest;

        bool p1_selecionado;
        bool p2_selecionado;
        bool p3_selecionado;
        bool p4_selecionado;

        public tela()
        {
            InitializeComponent();
            areaDesenho = new Bitmap(imagem.Size.Width, imagem.Size.Height);
            quantidadeClick = 0;

            for (int i = 0; i < pontos.Length; i++)
            {
                this.pontos[i] = new Ponto();
            }

            this.ab = new Ponto();
            this.bc = new Ponto();
            this.cd = new Ponto();
            this.abbc = new Ponto();
            this.bccd = new Ponto();
            this.dest = new Ponto();

            this.p1_selecionado = false;
            this.p2_selecionado = false;
            this.p3_selecionado = false;
            this.p4_selecionado = false;
        }

        /**
         * Captura cada clique na tela e verifica a operação a ser realizada de acordo com a entrada do usuario
         */
        private void Imagem_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.p1_selecionado)
                {
                    this.pontos[0].x = (float)e.X;
                    this.pontos[0].y = (float)e.Y;

                    this.Apagar();

                    for (int i = 0; i < 1000; i++)
                    {
                        float t = (float)i / (float)999.0;
                        this.ObterCurvaBezier(t);

                    }
                    this.quantidadeClick = 0;
                }
                else if (this.p2_selecionado)
                {
                    this.pontos[1].x = (float)e.X;
                    this.pontos[1].y = (float)e.Y;

                    this.Apagar();

                    for (int i = 0; i < 1000; i++)
                    {
                        float t = (float)i / (float)999.0;
                        this.ObterCurvaBezier(t);

                    }
                    this.quantidadeClick = 0;
                }
                else if (this.p3_selecionado)
                {
                    this.pontos[2].x = (float)e.X;
                    this.pontos[2].y = (float)e.Y;

                    this.Apagar();

                    for (int i = 0; i < 1000; i++)
                    {
                        float t = (float)i / (float)999.0;
                        this.ObterCurvaBezier(t);

                    }
                    this.quantidadeClick = 0;
                }
                else if (this.p4_selecionado)
                {
                    this.pontos[3].x = (float)e.X;
                    this.pontos[3].y = (float)e.Y;

                    this.Apagar();

                    for (int i = 0; i < 1000; i++)
                    {
                        float t = (float)i / (float)999.0;
                        this.ObterCurvaBezier(t);

                    }
                    this.quantidadeClick = 0;
                }
                else if (quantidadeClick < 3)
                {
                    this.pontos[quantidadeClick].x = (float)e.X;
                    this.pontos[quantidadeClick].y = (float)e.Y;

                    this.quantidadeClick++;
                }
                else if (quantidadeClick == 3)
                {
                    this.pontos[quantidadeClick].x = (float)e.X;
                    this.pontos[quantidadeClick].y = (float)e.Y;

                    for (int i = 0; i < 1000; i++)
                    {
                        float t = (float)i / (float)999.0; // t varia de 0 ate 1
                        this.ObterCurvaBezier(t);

                    }
                    this.quantidadeClick = 0;
                }
            }

        }

        /**
         * Avalia um ponto em uma curva de bezier. t vai desde 0 a 1,0
         *  Baseado no algoritmo de De Casteljau
         */
        public void ObterCurvaBezier(float t)
        {

            Interpolar(this.ab, this.pontos[0], this.pontos[1], t, Color.Red); 
            Interpolar(this.bc, this.pontos[1], this.pontos[2], t, Color.Red); 
            Interpolar(this.cd, this.pontos[2], this.pontos[3], t, Color.Red);
            Interpolar(this.abbc, ab, bc, t, Color.Yellow);
            Interpolar(this.bccd, bc, cd, t, Color.Yellow);
            Interpolar(this.dest, abbc, bccd, t, Color.Black); // ponto na curva de Bezier

        }

        /**
         * Método que realiza a interpolação simples entre dois pontos
         */
        public void Interpolar(Ponto dest, Ponto p0, Ponto p1, float t, Color cor)
        {
            dest.x = p0.x + (p1.x - p0.x) * t;
            dest.y = p0.y + (p1.y - p0.y) * t;

            this.Colore(dest.x, dest.y, cor);
        }

        /**
         * Seta o pixel, colorindo de acordo com as coordenadas x,y passadas como parametro
         * */
        public void Colore(float x, float y, Color cor)
        {
            areaDesenho.SetPixel((int)Math.Round(x), (int)Math.Round(y), cor);
            imagem.Image = areaDesenho;
        }

        private void BtApagar_Click(object sender, EventArgs e)
        {
            areaDesenho = new Bitmap(imagem.Size.Width, imagem.Size.Height);
            imagem.Image = areaDesenho;

            this.quantidadeClick = 0;

            for (int i = 0; i < pontos.Length; i++)
            {
                this.pontos[i] = new Ponto();
            }

            this.ab = new Ponto();
            this.bc = new Ponto();
            this.cd = new Ponto();
            this.abbc = new Ponto();
            this.bccd = new Ponto();
            this.dest = new Ponto();

            this.p1_selecionado = false;
            this.p2_selecionado = false;
            this.p3_selecionado = false;
            this.p4_selecionado = false;

            this.radioButton1.Checked = false;
            this.radioButton2.Checked = false;
            this.radioButton3.Checked = false;
            this.radioButton4.Checked = false;
        }

        public void Apagar()
        {
            areaDesenho = new Bitmap(imagem.Size.Width, imagem.Size.Height);
            imagem.Image = areaDesenho;
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.p1_selecionado = true;
            this.p2_selecionado = false;
            this.p3_selecionado = false;
            this.p4_selecionado = false;
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.p1_selecionado = false;
            this.p2_selecionado = true;
            this.p3_selecionado = false;
            this.p4_selecionado = false;
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            this.p1_selecionado = false;
            this.p2_selecionado = false;
            this.p3_selecionado = true;
            this.p4_selecionado = false;
        }

        private void RadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            this.p1_selecionado = false;
            this.p2_selecionado = false;
            this.p3_selecionado = false;
            this.p4_selecionado = true;
        }
    }
}
