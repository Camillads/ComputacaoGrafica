using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class tela : Form
    {
        Bitmap areaDesenho;
        Color corPreenche;
        int quantidadeClick; // conta a quantidade de cliques na tela. Se == 2, realiza as devidas operações
        int algoritmoEscolhido; // flag para identificar o algoritmo selecionado
        int recorteEscolhido; // flag para identificar o algoritmo de recorte que será utilizado
        bool desenharReta;
        bool desenharCircunferencia;
        bool transformar;
        Reta reta;
        Circunferencia circunferencia; 
        List<Reta> listaRetas; // lista para armazenar todas as Retas criadas
        List<Circunferencia> listaCircunferencias; // lista para armazenar todas as circunferências criadas

        double x1, x2, y1, y2;

        public tela()
        {
            InitializeComponent();
            areaDesenho = new Bitmap(imagem.Size.Width, imagem.Size.Height);
            corPreenche = Color.Black;
            quantidadeClick = 0;
            algoritmoEscolhido = -1;
            recorteEscolhido = Enum.RECORTE.COHEN;
            desenharReta = false;
            desenharCircunferencia = false;
            transformar = false;
            reta = new Reta();
            circunferencia = new Circunferencia();
            listaRetas = new List<Reta>();
            listaCircunferencias = new List<Circunferencia>();

            this.x1 = 0.0;
            this.x2 = 0.0;
            this.y1 = 0.0;
            this.y2 = 0.0;

            this.VerificarComponentes();
        }

        /**
         * Verifica qual checkbox esta selecionado para tirar a seleção dos demais 
         */
        public void VerificarComponentes()
        {
            if (checkBox1.Checked)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
                checkBox10.Checked = false;
            }
            else if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
                checkBox10.Checked = false;
            }
            else if (checkBox3.Checked)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
                checkBox10.Checked = false;
            }
            else if (checkBox4.Checked)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
                checkBox10.Checked = false;
            }
            else if (checkBox5.Checked)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
                checkBox10.Checked = false;
            }
            else if (checkBox6.Checked)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
                checkBox10.Checked = false;
            }
            else if (checkBox7.Checked)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
                checkBox10.Checked = false;
            }
            else if (checkBox8.Checked)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox9.Checked = false;
                checkBox10.Checked = false;
            }
            else if (checkBox9.Checked)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
                checkBox10.Checked = false;
            }
            else if (checkBox10.Checked)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
            }

            if (!checkBox4.Checked && !checkBox5.Checked && !checkBox6.Checked && !checkBox7.Checked && !checkBox8.Checked && !checkBox9.Checked)
            {
                this.transformar = false;
            }
            else
            {
                this.transformar = true;
            }

            if (!checkBox1.Checked && !checkBox2.Checked)
            {
                this.desenharReta = false;
            }
            else
            {
                this.desenharReta = true;
            }

            if (!checkBox3.Checked)
            {
                this.desenharCircunferencia = false;
            }
            else
            {
                this.desenharCircunferencia = true;
            }
        }

        /**
         * Desenha a reta conforme o algoritmo de DDA
         */ 
        public void AlgoritmoDDA()
        {
            double xincr, yincr;
            int passos;

            if (Math.Abs(this.reta.GetDx()) >= Math.Abs(this.reta.GetDy()))
            {
                passos = (int)Math.Abs(this.reta.GetDx());
            }
            else
            {
                passos = (int)Math.Abs(this.reta.GetDy());
            }

            xincr = this.reta.GetDx() / passos;
            yincr = this.reta.GetDy() / passos;

            for (int i = 0; i < passos; i++)
            {
                this.reta.SetX1(this.reta.GetX1() + xincr);
                this.reta.SetY1(this.reta.GetY1() + yincr);

                this.Colore(this.reta.GetX1(), this.reta.GetY1());
            }
        }

        /**
         * Desenha a reta conforme o algoritmo de Bresenham
         * São necessários 2 cliques
         * Primeiro clique - primeiro pontos x,y iniciais da reta
         * Segundo clique - pontos x,y finais da reta
         */
        public void AlgoritmoRetaBresenham()
        {
            double xincr, yincr, p, c1, c2;

            if (this.reta.GetDx() > 0)
            {
                xincr = 1;
            }
            else
            {
                xincr = -1;
                this.reta.SetDx(-1 * this.reta.GetDx());
            }

            if (this.reta.GetDy() > 0)
            {
                yincr = 1;
            }
            else
            {
                yincr = -1;
                this.reta.SetDy(-1 * this.reta.GetDy());
            }

            this.Colore(this.reta.GetX1(), this.reta.GetY1());

            if (this.reta.GetDx() > this.reta.GetDy())
            {
                p = 2 * this.reta.GetDy() - this.reta.GetDx();
                c1 = 2 * this.reta.GetDy();
                c2 = 2 * (this.reta.GetDy() - this.reta.GetDx());

                for (int i = 0; i < this.reta.GetDx(); i++)
                {
                    this.reta.SetX1(this.reta.GetX1() + xincr);
                    if (p < 0)
                    {
                        p = p + c1;
                    }
                    else
                    {
                        this.reta.SetY1(this.reta.GetY1() + yincr);
                        p = p + c2;
                    }
                    this.Colore(this.reta.GetX1(), this.reta.GetY1());
                }
            }
            else
            {
                p = 2 * this.reta.GetDx() - this.reta.GetDy();
                c1 = 2 * this.reta.GetDx();
                c2 = 2 * (this.reta.GetDx() - this.reta.GetDy());

                for (int i = 0; i < this.reta.GetDy(); i++)
                {
                    this.reta.SetY1(this.reta.GetY1() + yincr);
                    if (p < 0)
                    {
                        p = p + c1;
                    }
                    else
                    {
                        this.reta.SetX1(this.reta.GetX1() + xincr);
                        p = p + c2;
                    }
                    this.Colore(this.reta.GetX1(), this.reta.GetY1());
                }
            }
        }

        /**
         * Desenha a circunferencia conforme o algoritmo de de Bresenham
         * São necessários 2 cliques
         * Primeiro clique - ponto da circunferencia 
         * segundo clique - raio
         */
        public void AlgoritmoCircunferenciaBresenham()
        {
            double x = 0.0, y = this.circunferencia.GetRaio(), p = 3.0 - 2.0 * this.circunferencia.GetRaio();

            this.PlotaSimetricos(x, y, this.circunferencia.GetXc(), this.circunferencia.GetYc());

            while (x < y)
            {
                if (p < 0)
                {
                    p = p + 4 * x + 6;
                }
                else
                {
                    p = p + 4 * (x - y) + 10;
                    y--;
                }
                x++;

                this.PlotaSimetricos(x, y, this.circunferencia.GetXc(), this.circunferencia.GetYc());
            }
        }

        /**
         * Seta o pixel, colorindo de acordo com as coordenadas x,y passadas como parametro
         * */
        public void Colore(double x, double y)
        {
            areaDesenho.SetPixel((int)Math.Round(x), (int)Math.Round(y), corPreenche);
            imagem.Image = areaDesenho;
        }

        /*
         * Função exclusivamente usada para desenhar os pontos da circunferencia de Bresenham
         */
        public void PlotaSimetricos(double x, double y, double xc, double yc)
        {
            this.Colore(xc + x, yc + y);
            this.Colore(xc + x, yc - y);
            this.Colore(xc - x, yc + y);
            this.Colore(xc - x, yc - y);
            this.Colore(xc + y, yc + x);
            this.Colore(xc + y, yc - x);
            this.Colore(xc - y, yc + x);
            this.Colore(xc - y, yc - x);
        }

        private void Desenhar_Click(object sender, EventArgs e)
        {
            int x = (int)Convert.ToInt64(txtX.Text);
            int y = (int)Convert.ToInt64(txtY.Text);

            areaDesenho.SetPixel(x, y, corPreenche);
            imagem.Image = areaDesenho;
        }

        private void BtCor_Click(object sender, EventArgs e)
        {
            DialogResult result = cdlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                corPreenche = cdlg.Color;
            }
        }

        private void BtApagar_Click(object sender, EventArgs e)
        {
            areaDesenho = new Bitmap(imagem.Size.Width, imagem.Size.Height);
            imagem.Image = areaDesenho;

            this.listaRetas.Clear();
            this.listaCircunferencias.Clear();
        }

        /**
         * Limpa a tela
         */
        private void Apagar()
        {
            areaDesenho = new Bitmap(imagem.Size.Width, imagem.Size.Height);
            imagem.Image = areaDesenho;
        }

        private void Imagem_MouseMove(object sender, MouseEventArgs e)
        {
        }

        /**
         * Captura cada clique na tela e verifica a operação a ser realizada de acordo com a entrada do usuario
         */
        private void Imagem_Click(object sender, MouseEventArgs e)
        {
            this.VerificarComponentes();
            if (e.Button == MouseButtons.Left)
            {
                quantidadeClick++;

                if (this.desenharReta)
                {
                    this.DesenharReta(e);
                }
                else if (this.desenharCircunferencia)
                {
                    this.DesenharCircunferencia(e);
                }
                else if (this.transformar)
                {
                    this.Transformar(e);
                }
            }
        }

        bool cliptest(double p, double q, ref double u1, ref double u2)
        {
            bool result = true;
            double r;
            if (p < 0)
            {
                r = q / p;
                if (r > u2) result = false;
                else if (r > u1) u1 = r;
            }
            else if (p > 0)
            {
                r = q / p;
                if (r < u1) result = false;
                else if (r < u2) u2 = r;
            }
            else if (q < 0) result = false;
            return result;
        }

        /**
         * Função de recorte de retas
         */
        void LiangBarsky(double x1, double y1, double x2, double y2)
        {
            double u1 = 0;
            double u2 = 1;
            double dx = x2 - x1;
            double dy = y2 - y1;

            if (cliptest(-dx, x1, ref u1, ref u2))
                if (cliptest(dx, imagem.Size.Width - 1 - x1, ref u1, ref u2))
                    if (cliptest(-dy, y1, ref u1, ref u2))
                        if (cliptest(dy, imagem.Size.Height - 1 - y1, ref u1, ref u2))
                        {
                            if (u2 < 1)
                            {
                                x2 = (int)(x1 + dx * u2);
                                y2 = (int)(y1 + dy * u2);
                            }
                            if (u1 > 0)
                            {
                                x1 = (int)(x1 + dx * u1);
                                y1 = (int)(y1 + dy * u1);
                            }

                            this.reta = new Reta(x1, y1, x2, y2);
                            if (this.algoritmoEscolhido == Enum.Retas.DDA)
                            {
                                this.AlgoritmoDDA();
                            }
                            else if (this.algoritmoEscolhido == Enum.Retas.BRESENHAM)
                            {
                                this.AlgoritmoRetaBresenham();
                            }
                            else if (this.algoritmoEscolhido == Enum.TRANSFORMACOES.TRANSLADAR || this.algoritmoEscolhido == Enum.TRANSFORMACOES.ROTACIONAR
                                || this.algoritmoEscolhido == Enum.TRANSFORMACOES.ESCALA_AUMENTAR || this.algoritmoEscolhido == Enum.TRANSFORMACOES.ESCALA_DIMINUIR
                                || this.algoritmoEscolhido == Enum.TRANSFORMACOES.REFLETIRX || this.algoritmoEscolhido == Enum.TRANSFORMACOES.REFLETIRY
                                || this.algoritmoEscolhido == Enum.TRANSFORMACOES.REFLETIRXY)
                            {
                                this.AlgoritmoRetaBresenham();
                            }
                        }
        }

        int getPointCode(double x, double y)
        {
            int code = 0;

            if (x < 0)
                code = code | 1;
            else if (x >= imagem.Size.Width)
                code = code | 2;
            if (y < 0)
                code = code | 4;
            else if (y >= imagem.Size.Height)
                code = code | 8;

            return code;
        }

        /**
         * Função de recorte de retas
         */
        public void RecortCohen(double x1, double y1, double x2, double y2)
        {
            int code1 = getPointCode(x1, y1);
            int code2 = getPointCode(x2, y2);

            bool accept = false;

            while (true)
            {
                if ((code1 == 0) && (code2 == 0)) { accept = true; break; }
                else if ((code1 & code2) != 0) { break; }
                else
                {
                    int code_out;
                    double x = 0, y = 0;

                    if (code1 != 0) code_out = code1;
                    else code_out = code2;

                    if ((code_out & 8) != 0)
                    {
                        x = x1 + (x2 - x1) * (imagem.Size.Height - y1) / (y2 - y1);
                        y = imagem.Size.Height - 1;
                    }
                    else if ((code_out & 4) != 0)
                    {
                        x = x1 + (x2 - x1) * (0 - y1) / (y2 - y1);
                        y = 0;
                    }
                    else if ((code_out & 2) != 0)
                    {
                        y = y1 + (y2 - y1) * (imagem.Size.Width - x1) / (x2 - x1);
                        x = imagem.Size.Width - 1;
                    }
                    else if ((code_out & 1) != 0)
                    {
                        y = y1 + (y2 - y1) * (0 - x1) / (x2 - x1);
                        x = 0;
                    }

                    if (code_out == code1)
                    {
                        x1 = (int)x;
                        y1 = (int)y;
                        code1 = getPointCode(x1, y1);
                    }
                    else
                    {
                        x2 = (int)x;
                        y2 = (int)y;
                        code2 = getPointCode(x2, y2);
                    }
                }
            }
            if (accept)
            {
                this.reta = new Reta(x1, y1, x2, y2);
                if (this.algoritmoEscolhido == Enum.Retas.DDA)
                {
                    this.AlgoritmoDDA();
                }
                else if (this.algoritmoEscolhido == Enum.Retas.BRESENHAM)
                {
                    this.AlgoritmoRetaBresenham();
                }
                else if (this.algoritmoEscolhido == Enum.TRANSFORMACOES.TRANSLADAR || this.algoritmoEscolhido == Enum.TRANSFORMACOES.ROTACIONAR
                    || this.algoritmoEscolhido == Enum.TRANSFORMACOES.ESCALA_AUMENTAR || this.algoritmoEscolhido == Enum.TRANSFORMACOES.ESCALA_DIMINUIR
                    || this.algoritmoEscolhido == Enum.TRANSFORMACOES.REFLETIRX || this.algoritmoEscolhido == Enum.TRANSFORMACOES.REFLETIRY
                    || this.algoritmoEscolhido == Enum.TRANSFORMACOES.REFLETIRXY)
                {
                    this.AlgoritmoRetaBresenham();
                }
            }
        }

        /**
         * Desenha a reta de acordo com as coordenadas dos pontos selecionados na tela e de acordo com o algoritmo escolhido
         */
        private void DesenharReta(MouseEventArgs e)
        {

            if (quantidadeClick == 1)
            {
                this.reta.SetX1(e.X);
                this.reta.SetY1(e.Y);

                txtX.Text = Convert.ToString(this.reta.GetX1());
                txtY.Text = Convert.ToString(this.reta.GetY1());

                this.Colore(this.reta.GetX1(), this.reta.GetY1());
            }
            else if (quantidadeClick == 2)
            {
                this.reta.SetX2(e.X);
                this.reta.SetY2(e.Y);

                this.reta.SetDx(this.reta.GetX2() - this.reta.GetX1());
                this.reta.SetDy(this.reta.GetY2() - this.reta.GetY1());
                this.reta.SetCoeficienteAngular(this.reta.GetDy() / this.reta.GetDx());

                Reta retaAux = new Reta(this.reta.GetX1(), this.reta.GetY1(), this.reta.GetX2(), this.reta.GetY2());

                this.listaRetas.Add(retaAux);

                txtX.Text = Convert.ToString(this.reta.GetX2());
                txtY.Text = Convert.ToString(this.reta.GetY2());

                this.Colore(this.reta.GetX2(), this.reta.GetY2());

                this.RecortCohen(this.reta.GetX1(), this.reta.GetY1(), this.reta.GetX2(), this.reta.GetY2());

                this.quantidadeClick = 0;
            }
        }


        /**
         * Desenha a circunferencia de acordo com os pontos selecionados na tela e de acordo com o algoritmo escolhido
         */
        private void DesenharCircunferencia(MouseEventArgs e)
        {
            if (this.quantidadeClick == 1)
            {
                // obtem as cordenadas do primeiro ponto
                this.circunferencia.SetX(e.X);
                this.circunferencia.SetY(e.Y);

                txtX.Text = Convert.ToString(this.circunferencia.GetX());
                txtY.Text = Convert.ToString(this.circunferencia.GetY());

                // desenha o primeiro ponto
                this.Colore(this.circunferencia.GetX(), this.circunferencia.GetY());
            }
            else if (this.quantidadeClick == 2)
            {
                // obtem as coordenadas do segundo ponto
                this.circunferencia.SetXc(e.X);
                this.circunferencia.SetYc(e.Y);

                this.circunferencia.SetRaio(this.circunferencia.GetX(), this.circunferencia.GetY(), this.circunferencia.GetXc(), this.circunferencia.GetYc());

                var cirAux = new Circunferencia(this.circunferencia.GetX(), this.circunferencia.GetY(), this.circunferencia.GetXc(), this.circunferencia.GetYc());
                this.listaCircunferencias.Add(cirAux);

                txtX.Text = Convert.ToString(this.circunferencia.GetXc());
                txtY.Text = Convert.ToString(this.circunferencia.GetYc());

                // desenha o segunto ponto
                this.Colore(this.circunferencia.GetXc(), this.circunferencia.GetYc());

                if (this.algoritmoEscolhido == Enum.CIRCUNFERENCIAS.BRESENHAM)
                {
                    this.AlgoritmoCircunferenciaBresenham();
                }

                this.quantidadeClick = 0;
            }

        }

        /**
         *  Chama o algoritmo de transformação selecionado pelo usuário de acordo com os valores das flags 
         */
        private void Transformar(MouseEventArgs e)
        {
            if (this.quantidadeClick == 1)
            {
                this.x1 = e.X;
                this.y1 = e.Y;
            }
            else if (this.quantidadeClick == 2)
            {
                this.quantidadeClick = 0;
                this.x2 = e.X;
                this.y2 = e.Y;

                this.Apagar(); // apaga para, depois, redesenhar

                if (this.transformar && this.algoritmoEscolhido == Enum.TRANSFORMACOES.TRANSLADAR)
                {
                    this.Transladar();
                }
                else if (this.transformar && this.algoritmoEscolhido == Enum.TRANSFORMACOES.ROTACIONAR)
                {
                    this.Rotacionar();
                }
                else if (this.transformar && this.algoritmoEscolhido == Enum.TRANSFORMACOES.ESCALA_AUMENTAR)
                {
                    this.AumentarEscala();
                }
                else if (this.transformar && this.algoritmoEscolhido == Enum.TRANSFORMACOES.ESCALA_DIMINUIR)
                {
                    this.DiminuirEscala();
                }
                else if (this.transformar && this.algoritmoEscolhido == Enum.TRANSFORMACOES.REFLETIRX)
                {
                    this.RefletirX();
                }
                else if (this.transformar && this.algoritmoEscolhido == Enum.TRANSFORMACOES.REFLETIRY)
                {
                    this.RefletirY();
                }
                else if (this.transformar && this.algoritmoEscolhido == Enum.TRANSFORMACOES.REFLETIRXY)
                {
                    this.RefletixXY();
                }

                this.quantidadeClick = 0; // seta quantidade de cliques para 0 para obter os proximos 2 cliques
            }
        }

        /**
         * Translada a figura de acordo com a variação dos pontos x e y
         */
        private void Transladar()
        {
            var deltaX = this.x2 - this.x1;
            var deltaY = this.y2 - this.y1;

            foreach (var retaAux in this.listaRetas)
            {
                retaAux.SetX1(retaAux.GetX1() + deltaX);
                retaAux.SetY1(retaAux.GetY1() + deltaY);

                retaAux.SetX2(retaAux.GetX2() + deltaX);
                retaAux.SetY2(retaAux.GetY2() + deltaY);

                // chama um dos algoritmos de recorte antes de desenhar, para garantir o desenho dentro da janela de vizualizacao
                if (this.recorteEscolhido == Enum.RECORTE.LIANG)
                {
                    this.LiangBarsky(retaAux.GetX1(), retaAux.GetY1(), retaAux.GetX2(), retaAux.GetY2());
                }
                else
                {
                    this.RecortCohen(retaAux.GetX1(), retaAux.GetY1(), retaAux.GetX2(), retaAux.GetY2());
                }
            }

            foreach (var circAux in this.listaCircunferencias)
            {
                circAux.SetXc(circAux.GetXc() + deltaX);
                circAux.SetYc(circAux.GetYc() + deltaY);

                circAux.SetX(circAux.GetX() + deltaX);
                circAux.SetY(circAux.GetY() + deltaY);

                this.circunferencia = new Circunferencia(circAux.GetX(), circAux.GetY(), circAux.GetXc(), circAux.GetYc());

                this.AlgoritmoCircunferenciaBresenham();
            }

        }

        /**
         * Rotaciona a figura de acordo com um valor definido pelos 2 pontos selecionados pelo usuario 
         * Pega-se a diferença dos valores de x e obtêm o ângulo de rotação
         */
        private void Rotacionar()
        {
            double degrees = (this.x2 - this.x1) / 5;
            double angle = Math.PI * degrees / 180.0;
            double sinAngle = Math.Sin(angle);
            double cosAngle = Math.Cos(angle);

            /**
             * translada a figura para uma nova origem no centro da tela 
             */
            this.x1 = imagem.Image.Width / 2;
            this.x2 = 0;
            this.y1 = imagem.Image.Height / 2;
            this.y2 = 0;

            this.Transladar();

            foreach (var retaAux in this.listaRetas)
            {
                retaAux.SetX1(Math.Round(retaAux.GetX1() * cosAngle - retaAux.GetY1() * sinAngle));
                retaAux.SetY1(Math.Round(retaAux.GetY1() * cosAngle + retaAux.GetX1() * sinAngle));

                retaAux.SetX2(Math.Round(retaAux.GetX2() * cosAngle - retaAux.GetY2() * sinAngle));
                retaAux.SetY2(Math.Round(retaAux.GetY2() * cosAngle + retaAux.GetX2() * sinAngle));

                /**
                 * Translada a figura para as posicoes iniciais, antes de desenhar
                 */
                this.x1 = 0;
                this.x2 = imagem.Image.Width / 2;
                this.y1 = 0;
                this.y2 = imagem.Image.Height / 2;
                this.Transladar();


                // chama um dos algoritmos de algoritmos de recorte para garantir o desenho dentro da janela de visualização
                if (this.recorteEscolhido == Enum.RECORTE.LIANG)
                {
                    this.LiangBarsky(retaAux.GetX1(), retaAux.GetY1(), retaAux.GetX2(), retaAux.GetY2());
                }
                else
                {
                    this.RecortCohen(retaAux.GetX1(), retaAux.GetY1(), retaAux.GetX2(), retaAux.GetY2());
                }
            }

            foreach (var circAux in this.listaCircunferencias)
            {
                circAux.SetXc(Math.Round(circAux.GetXc() * cosAngle - circAux.GetYc() * sinAngle));
                circAux.SetYc(Math.Round(circAux.GetYc() * cosAngle + circAux.GetXc() * sinAngle));

                this.circunferencia = new Circunferencia(circAux.GetX(), circAux.GetY(), circAux.GetXc(), circAux.GetYc());

                this.x1 = 0;
                this.x2 = imagem.Image.Width / 2;
                this.y1 = 0;
                this.y2 = imagem.Image.Height / 2;
                this.Transladar();

                this.AlgoritmoCircunferenciaBresenham();
            }
        }


        /*
         * Diminui a escala da figura por uma constante 0.9
         */
        private void DiminuirEscala()
        {
            foreach (var retaAux in this.listaRetas)
            {
                retaAux.SetX1(retaAux.GetX1() * Enum.TRANSFORMACOES.CONSTANTE_MENOR);
                retaAux.SetY1(retaAux.GetY1() * Enum.TRANSFORMACOES.CONSTANTE_MENOR);

                retaAux.SetX2(retaAux.GetX2() * Enum.TRANSFORMACOES.CONSTANTE_MENOR);
                retaAux.SetY2(retaAux.GetY2() * Enum.TRANSFORMACOES.CONSTANTE_MENOR);

                // chama um dos algoritmos de algoritmos de recorte para garantir o desenho dentro da janela de visualização
                if (this.recorteEscolhido == Enum.RECORTE.LIANG)
                {
                    this.LiangBarsky(retaAux.GetX1(), retaAux.GetY1(), retaAux.GetX2(), retaAux.GetY2());
                }
                else
                {
                    this.RecortCohen(retaAux.GetX1(), retaAux.GetY1(), retaAux.GetX2(), retaAux.GetY2());
                }
            }

            foreach (var circAux in this.listaCircunferencias)
            {
                circAux.SetXc(circAux.GetXc() * Enum.TRANSFORMACOES.CONSTANTE_MENOR);
                circAux.SetYc(circAux.GetYc() * Enum.TRANSFORMACOES.CONSTANTE_MENOR);

                circAux.SetX(circAux.GetX() * Enum.TRANSFORMACOES.CONSTANTE_MENOR);
                circAux.SetY(circAux.GetY() * Enum.TRANSFORMACOES.CONSTANTE_MENOR);

                this.circunferencia = new Circunferencia(circAux.GetX(), circAux.GetY(), circAux.GetXc(), circAux.GetYc());

                this.AlgoritmoCircunferenciaBresenham();
            }
        }


        /**
         * Aumenta a escala da figura por uma constante 1.1
         */
        private void AumentarEscala()
        {
            foreach (var retaAux in this.listaRetas)
            {
                retaAux.SetX1(retaAux.GetX1() * Enum.TRANSFORMACOES.CONSTANTE_MAIOR);
                retaAux.SetY1(retaAux.GetY1() * Enum.TRANSFORMACOES.CONSTANTE_MAIOR);

                retaAux.SetX2(retaAux.GetX2() * Enum.TRANSFORMACOES.CONSTANTE_MAIOR);
                retaAux.SetY2(retaAux.GetY2() * Enum.TRANSFORMACOES.CONSTANTE_MAIOR);

                // chama um dos algoritmos de algoritmos de recorte para garantir o desenho dentro da janela de visualização
                if (this.recorteEscolhido == Enum.RECORTE.LIANG)
                {
                    this.LiangBarsky(retaAux.GetX1(), retaAux.GetY1(), retaAux.GetX2(), retaAux.GetY2());
                }
                else
                {
                    this.RecortCohen(retaAux.GetX1(), retaAux.GetY1(), retaAux.GetX2(), retaAux.GetY2());
                }
            }

            foreach (var circAux in this.listaCircunferencias)
            {
                circAux.SetXc(circAux.GetXc() * Enum.TRANSFORMACOES.CONSTANTE_MAIOR);
                circAux.SetYc(circAux.GetYc() * Enum.TRANSFORMACOES.CONSTANTE_MAIOR);

                circAux.SetX(circAux.GetX() * Enum.TRANSFORMACOES.CONSTANTE_MAIOR);
                circAux.SetY(circAux.GetY() * Enum.TRANSFORMACOES.CONSTANTE_MAIOR);

                this.circunferencia = new Circunferencia(circAux.GetX(), circAux.GetY(), circAux.GetXc(), circAux.GetYc());

                this.AlgoritmoCircunferenciaBresenham();
            }
        }


        /**
         * Reflete a figura em torno do eixo x
         */
        private void RefletirX()
        {

            foreach (var retaAux in this.listaRetas)
            {
                retaAux.SetY1(imagem.Size.Height - retaAux.GetY1());

                retaAux.SetY2(imagem.Size.Height - retaAux.GetY2());

                // chama um dos algoritmos de algoritmos de recorte para garantir o desenho dentro da janela de visualização
                if (this.recorteEscolhido == Enum.RECORTE.LIANG)
                {
                    this.LiangBarsky(retaAux.GetX1(), retaAux.GetY1(), retaAux.GetX2(), retaAux.GetY2());
                }
                else
                {
                    this.RecortCohen(retaAux.GetX1(), retaAux.GetY1(), retaAux.GetX2(), retaAux.GetY2());
                }
            }

            foreach (var cirAux in this.listaCircunferencias)
            {
                cirAux.SetYc(imagem.Size.Height - cirAux.GetYc());

                this.circunferencia = new Circunferencia(cirAux.GetX(), cirAux.GetY(), cirAux.GetXc(), cirAux.GetYc());

                this.AlgoritmoCircunferenciaBresenham();
            }
        }

        /**
         * Reflete a figura em torno do eixo y
         */
        private void RefletirY()
        {
            foreach (var retaAux in this.listaRetas)
            {
                retaAux.SetX1(imagem.Size.Height - retaAux.GetX1());

                retaAux.SetX2(imagem.Size.Height - retaAux.GetX2());

                // chama um dos algoritmos de algoritmos de recorte para garantir o desenho dentro da janela de visualização
                if (this.recorteEscolhido == Enum.RECORTE.LIANG)
                {
                    this.LiangBarsky(retaAux.GetX1(), retaAux.GetY1(), retaAux.GetX2(), retaAux.GetY2());
                }
                else
                {
                    this.RecortCohen(retaAux.GetX1(), retaAux.GetY1(), retaAux.GetX2(), retaAux.GetY2());
                }
            }
        }

        /**
         * Reflete a figura em torno dos eixo x e y
         */
        private void RefletixXY()
        {
            foreach (var retaAux in this.listaRetas)
            {
                retaAux.SetY1(imagem.Size.Height - retaAux.GetY1());

                retaAux.SetY2(imagem.Size.Height - retaAux.GetY2());

                retaAux.SetX1(imagem.Size.Height - retaAux.GetX1());

                retaAux.SetX2(imagem.Size.Height - retaAux.GetX2());

                // chama um dos algoritmos de algoritmos de recorte para garantir o desenho dentro da janela de visualização
                if (this.recorteEscolhido == Enum.RECORTE.LIANG)
                {
                    this.LiangBarsky(retaAux.GetX1(), retaAux.GetY1(), retaAux.GetX2(), retaAux.GetY2());
                }
                else
                {
                    this.RecortCohen(retaAux.GetX1(), retaAux.GetY1(), retaAux.GetX2(), retaAux.GetY2());
                }
            }
        }
        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.algoritmoEscolhido = Enum.Retas.DDA;

            this.VerificarComponentes();
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            this.algoritmoEscolhido = Enum.Retas.BRESENHAM;

            this.VerificarComponentes();
        }

        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            this.algoritmoEscolhido = Enum.CIRCUNFERENCIAS.BRESENHAM;

            this.VerificarComponentes();
        }

        private void Painel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            this.algoritmoEscolhido = Enum.TRANSFORMACOES.TRANSLADAR;

            this.VerificarComponentes();
        }

        private void CheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            this.algoritmoEscolhido = Enum.TRANSFORMACOES.ROTACIONAR;

            this.VerificarComponentes();
        }

        private void CheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            this.algoritmoEscolhido = Enum.TRANSFORMACOES.ESCALA_AUMENTAR;

            this.VerificarComponentes();
        }

        private void CheckBox10_CheckedChanged(object sender, EventArgs e)
        {
            this.algoritmoEscolhido = Enum.TRANSFORMACOES.ESCALA_DIMINUIR;

            this.VerificarComponentes();
        }

        private void CheckBox11_CheckedChanged(object sender, EventArgs e)
        {
            this.recorteEscolhido = Enum.RECORTE.COHEN;
            this.VerificarComponentes();
        }

        private void CheckBox12_CheckedChanged(object sender, EventArgs e)
        {
            this.recorteEscolhido = Enum.RECORTE.LIANG;
            this.VerificarComponentes();
        }

        private void CheckBox7_CheckedChanged(object sender, EventArgs e)
        {
            this.algoritmoEscolhido = Enum.TRANSFORMACOES.REFLETIRX;

            this.VerificarComponentes();
        }

        private void CheckBox8_CheckedChanged(object sender, EventArgs e)
        {
            this.algoritmoEscolhido = Enum.TRANSFORMACOES.REFLETIRY;

            this.VerificarComponentes();
        }

        private void CheckBox9_CheckedChanged(object sender, EventArgs e)
        {
            this.algoritmoEscolhido = Enum.TRANSFORMACOES.REFLETIRXY;

            this.VerificarComponentes();
        }
    }
}
