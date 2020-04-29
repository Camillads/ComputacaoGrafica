namespace WindowsFormsApplication1
{
    partial class tela
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.imagem = new System.Windows.Forms.PictureBox();
            this.painel = new System.Windows.Forms.Panel();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btApagar = new System.Windows.Forms.Button();
            this.btCor = new System.Windows.Forms.Button();
            this.txtY = new System.Windows.Forms.TextBox();
            this.txtX = new System.Windows.Forms.TextBox();
            this.lbY = new System.Windows.Forms.Label();
            this.lbX = new System.Windows.Forms.Label();
            this.desenhar = new System.Windows.Forms.Button();
            this.cdlg = new System.Windows.Forms.ColorDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.checkBox12 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.imagem)).BeginInit();
            this.painel.SuspendLayout();
            this.SuspendLayout();
            // 
            // imagem
            // 
            this.imagem.BackColor = System.Drawing.Color.White;
            this.imagem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imagem.Location = new System.Drawing.Point(0, 0);
            this.imagem.Name = "imagem";
            this.imagem.Size = new System.Drawing.Size(784, 562);
            this.imagem.TabIndex = 0;
            this.imagem.TabStop = false;
            this.imagem.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Imagem_Click);
            this.imagem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Imagem_MouseMove);
            // 
            // painel
            // 
            this.painel.Controls.Add(this.checkBox12);
            this.painel.Controls.Add(this.checkBox11);
            this.painel.Controls.Add(this.label3);
            this.painel.Controls.Add(this.checkBox10);
            this.painel.Controls.Add(this.checkBox9);
            this.painel.Controls.Add(this.checkBox8);
            this.painel.Controls.Add(this.checkBox7);
            this.painel.Controls.Add(this.checkBox6);
            this.painel.Controls.Add(this.checkBox5);
            this.painel.Controls.Add(this.checkBox4);
            this.painel.Controls.Add(this.label2);
            this.painel.Controls.Add(this.checkBox3);
            this.painel.Controls.Add(this.checkBox2);
            this.painel.Controls.Add(this.checkBox1);
            this.painel.Controls.Add(this.label1);
            this.painel.Controls.Add(this.btApagar);
            this.painel.Controls.Add(this.btCor);
            this.painel.Controls.Add(this.txtY);
            this.painel.Controls.Add(this.txtX);
            this.painel.Controls.Add(this.lbY);
            this.painel.Controls.Add(this.lbX);
            this.painel.Controls.Add(this.desenhar);
            this.painel.Dock = System.Windows.Forms.DockStyle.Right;
            this.painel.Location = new System.Drawing.Point(654, 0);
            this.painel.Name = "painel";
            this.painel.Size = new System.Drawing.Size(130, 562);
            this.painel.TabIndex = 1;
            this.painel.Paint += new System.Windows.Forms.PaintEventHandler(this.Painel_Paint);
            // 
            // checkBox10
            // 
            this.checkBox10.AutoSize = true;
            this.checkBox10.Location = new System.Drawing.Point(10, 190);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(98, 17);
            this.checkBox10.TabIndex = 19;
            this.checkBox10.Text = "Diminuir Escala";
            this.checkBox10.UseVisualStyleBackColor = true;
            this.checkBox10.CheckedChanged += new System.EventHandler(this.CheckBox10_CheckedChanged);
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.Location = new System.Drawing.Point(10, 259);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(76, 17);
            this.checkBox9.TabIndex = 18;
            this.checkBox9.Text = "Refletir XY";
            this.checkBox9.UseVisualStyleBackColor = true;
            this.checkBox9.CheckedChanged += new System.EventHandler(this.CheckBox9_CheckedChanged);
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(10, 236);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(69, 17);
            this.checkBox8.TabIndex = 17;
            this.checkBox8.Text = "Refletir Y";
            this.checkBox8.UseVisualStyleBackColor = true;
            this.checkBox8.CheckedChanged += new System.EventHandler(this.CheckBox8_CheckedChanged);
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(10, 213);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(69, 17);
            this.checkBox7.TabIndex = 16;
            this.checkBox7.Text = "Refletir X";
            this.checkBox7.UseVisualStyleBackColor = true;
            this.checkBox7.CheckedChanged += new System.EventHandler(this.CheckBox7_CheckedChanged);
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(10, 167);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(106, 17);
            this.checkBox6.TabIndex = 15;
            this.checkBox6.Text = "Aumentar Escala";
            this.checkBox6.UseVisualStyleBackColor = true;
            this.checkBox6.CheckedChanged += new System.EventHandler(this.CheckBox6_CheckedChanged);
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(10, 144);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(78, 17);
            this.checkBox5.TabIndex = 14;
            this.checkBox5.Text = "Rotacionar";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.CheckBox5_CheckedChanged);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(10, 121);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(76, 17);
            this.checkBox4.TabIndex = 13;
            this.checkBox4.Text = "Transladar";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.CheckBox4_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Transf. geométricas 2D";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(10, 71);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(118, 17);
            this.checkBox3.TabIndex = 11;
            this.checkBox3.Text = "Circunf. Bresenham";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.CheckBox3_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(10, 48);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(105, 17);
            this.checkBox2.TabIndex = 10;
            this.checkBox2.Text = "Reta Bresenham";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.CheckBox2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(10, 25);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(75, 17);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "Reta DDA";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Escolha um Algoritmo:";
            // 
            // btApagar
            // 
            this.btApagar.Location = new System.Drawing.Point(20, 528);
            this.btApagar.Name = "btApagar";
            this.btApagar.Size = new System.Drawing.Size(75, 22);
            this.btApagar.TabIndex = 6;
            this.btApagar.Text = "Apagar";
            this.btApagar.UseVisualStyleBackColor = true;
            this.btApagar.Click += new System.EventHandler(this.BtApagar_Click);
            // 
            // btCor
            // 
            this.btCor.Location = new System.Drawing.Point(20, 499);
            this.btCor.Name = "btCor";
            this.btCor.Size = new System.Drawing.Size(75, 23);
            this.btCor.TabIndex = 5;
            this.btCor.Text = "Cor";
            this.btCor.UseVisualStyleBackColor = true;
            this.btCor.Click += new System.EventHandler(this.BtCor_Click);
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(20, 444);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(68, 20);
            this.txtY.TabIndex = 4;
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(20, 405);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(68, 20);
            this.txtX.TabIndex = 3;
            // 
            // lbY
            // 
            this.lbY.AutoSize = true;
            this.lbY.Location = new System.Drawing.Point(17, 428);
            this.lbY.Name = "lbY";
            this.lbY.Size = new System.Drawing.Size(14, 13);
            this.lbY.TabIndex = 2;
            this.lbY.Text = "Y";
            // 
            // lbX
            // 
            this.lbX.AutoSize = true;
            this.lbX.Location = new System.Drawing.Point(17, 389);
            this.lbX.Name = "lbX";
            this.lbX.Size = new System.Drawing.Size(14, 13);
            this.lbX.TabIndex = 1;
            this.lbX.Text = "X";
            // 
            // desenhar
            // 
            this.desenhar.Location = new System.Drawing.Point(20, 470);
            this.desenhar.Name = "desenhar";
            this.desenhar.Size = new System.Drawing.Size(75, 23);
            this.desenhar.TabIndex = 0;
            this.desenhar.Text = "Desenhar";
            this.desenhar.UseVisualStyleBackColor = true;
            this.desenhar.Click += new System.EventHandler(this.Desenhar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 295);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Recorte";
            // 
            // checkBox11
            // 
            this.checkBox11.AutoSize = true;
            this.checkBox11.Location = new System.Drawing.Point(10, 311);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(111, 17);
            this.checkBox11.TabIndex = 21;
            this.checkBox11.Text = "Cohen-Sutherland";
            this.checkBox11.UseVisualStyleBackColor = true;
            this.checkBox11.CheckedChanged += new System.EventHandler(this.CheckBox11_CheckedChanged);
            // 
            // checkBox12
            // 
            this.checkBox12.AutoSize = true;
            this.checkBox12.Location = new System.Drawing.Point(10, 334);
            this.checkBox12.Name = "checkBox12";
            this.checkBox12.Size = new System.Drawing.Size(90, 17);
            this.checkBox12.TabIndex = 22;
            this.checkBox12.Text = "Liang-Barsky ";
            this.checkBox12.UseVisualStyleBackColor = true;
            this.checkBox12.CheckedChanged += new System.EventHandler(this.CheckBox12_CheckedChanged);
            // 
            // tela
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.painel);
            this.Controls.Add(this.imagem);
            this.Name = "tela";
            this.Text = "Manipulação Imagem";
            ((System.ComponentModel.ISupportInitialize)(this.imagem)).EndInit();
            this.painel.ResumeLayout(false);
            this.painel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imagem;
        private System.Windows.Forms.Panel painel;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.Label lbY;
        private System.Windows.Forms.Label lbX;
        private System.Windows.Forms.Button desenhar;
        private System.Windows.Forms.Button btApagar;
        private System.Windows.Forms.Button btCor;
        private System.Windows.Forms.ColorDialog cdlg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox10;
        private System.Windows.Forms.CheckBox checkBox11;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox12;
    }
}