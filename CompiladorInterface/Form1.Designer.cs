namespace CompiladorInterface {
    partial class Form1 {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ModificarCodigo = new System.Windows.Forms.Button();
            this.GerarTabela = new System.Windows.Forms.Button();
            this.dataGridTabelaLex = new System.Windows.Forms.DataGridView();
            this.buttonArvore = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.buttonAntArvore = new System.Windows.Forms.Button();
            this.buttonProxArvore = new System.Windows.Forms.Button();
            this.buttonArvorePrecFraca = new System.Windows.Forms.Button();
            this.buttonAntFraca = new System.Windows.Forms.Button();
            this.buttonProxFraca = new System.Windows.Forms.Button();
            this.dataGridTabelaSimbolos = new System.Windows.Forms.DataGridView();
            this.buttonTabelaSimbolos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTabelaLex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTabelaSimbolos)).BeginInit();
            this.SuspendLayout();
            // 
            // ModificarCodigo
            // 
            this.ModificarCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModificarCodigo.Location = new System.Drawing.Point(12, 12);
            this.ModificarCodigo.Name = "ModificarCodigo";
            this.ModificarCodigo.Size = new System.Drawing.Size(147, 32);
            this.ModificarCodigo.TabIndex = 0;
            this.ModificarCodigo.Text = "Modificar Código";
            this.ModificarCodigo.UseVisualStyleBackColor = true;
            this.ModificarCodigo.Click += new System.EventHandler(this.ModificarCodigo_Click_1);
            // 
            // GerarTabela
            // 
            this.GerarTabela.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GerarTabela.Location = new System.Drawing.Point(12, 62);
            this.GerarTabela.Name = "GerarTabela";
            this.GerarTabela.Size = new System.Drawing.Size(147, 32);
            this.GerarTabela.TabIndex = 1;
            this.GerarTabela.Text = "Gerar Tabela";
            this.GerarTabela.UseVisualStyleBackColor = true;
            this.GerarTabela.Click += new System.EventHandler(this.GerarTabela_Click);
            // 
            // dataGridTabelaLex
            // 
            this.dataGridTabelaLex.AllowUserToAddRows = false;
            this.dataGridTabelaLex.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dataGridTabelaLex.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridTabelaLex.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridTabelaLex.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridTabelaLex.BackgroundColor = System.Drawing.Color.White;
            this.dataGridTabelaLex.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Tomato;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridTabelaLex.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridTabelaLex.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridTabelaLex.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridTabelaLex.EnableHeadersVisualStyles = false;
            this.dataGridTabelaLex.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridTabelaLex.Location = new System.Drawing.Point(12, 100);
            this.dataGridTabelaLex.Name = "dataGridTabelaLex";
            this.dataGridTabelaLex.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridTabelaLex.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridTabelaLex.Size = new System.Drawing.Size(350, 338);
            this.dataGridTabelaLex.TabIndex = 2;
            // 
            // buttonArvore
            // 
            this.buttonArvore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonArvore.Location = new System.Drawing.Point(396, 62);
            this.buttonArvore.Name = "buttonArvore";
            this.buttonArvore.Size = new System.Drawing.Size(147, 32);
            this.buttonArvore.TabIndex = 4;
            this.buttonArvore.Text = "Árvore PréOrdem";
            this.buttonArvore.UseVisualStyleBackColor = true;
            this.buttonArvore.Click += new System.EventHandler(this.buttonArvore_Click);
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(396, 100);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(350, 338);
            this.treeView1.TabIndex = 5;
            // 
            // buttonAntArvore
            // 
            this.buttonAntArvore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAntArvore.Location = new System.Drawing.Point(560, 62);
            this.buttonAntArvore.Name = "buttonAntArvore";
            this.buttonAntArvore.Size = new System.Drawing.Size(73, 32);
            this.buttonAntArvore.TabIndex = 6;
            this.buttonAntArvore.Text = "Anterior";
            this.buttonAntArvore.UseVisualStyleBackColor = true;
            this.buttonAntArvore.Click += new System.EventHandler(this.buttonAntArvore_Click);
            // 
            // buttonProxArvore
            // 
            this.buttonProxArvore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonProxArvore.Location = new System.Drawing.Point(639, 62);
            this.buttonProxArvore.Name = "buttonProxArvore";
            this.buttonProxArvore.Size = new System.Drawing.Size(73, 32);
            this.buttonProxArvore.TabIndex = 7;
            this.buttonProxArvore.Text = "Próxima";
            this.buttonProxArvore.UseVisualStyleBackColor = true;
            this.buttonProxArvore.Click += new System.EventHandler(this.buttonProxArvore_Click);
            // 
            // buttonArvorePrecFraca
            // 
            this.buttonArvorePrecFraca.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonArvorePrecFraca.Location = new System.Drawing.Point(396, 24);
            this.buttonArvorePrecFraca.Name = "buttonArvorePrecFraca";
            this.buttonArvorePrecFraca.Size = new System.Drawing.Size(147, 32);
            this.buttonArvorePrecFraca.TabIndex = 8;
            this.buttonArvorePrecFraca.Text = "Árvore PrecFraca";
            this.buttonArvorePrecFraca.UseVisualStyleBackColor = true;
            this.buttonArvorePrecFraca.Click += new System.EventHandler(this.buttonArvorePrecFraca_Click);
            // 
            // buttonAntFraca
            // 
            this.buttonAntFraca.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAntFraca.Location = new System.Drawing.Point(560, 24);
            this.buttonAntFraca.Name = "buttonAntFraca";
            this.buttonAntFraca.Size = new System.Drawing.Size(73, 32);
            this.buttonAntFraca.TabIndex = 9;
            this.buttonAntFraca.Text = "Anterior";
            this.buttonAntFraca.UseVisualStyleBackColor = true;
            this.buttonAntFraca.Click += new System.EventHandler(this.buttonAntFraca_Click);
            // 
            // buttonProxFraca
            // 
            this.buttonProxFraca.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonProxFraca.Location = new System.Drawing.Point(639, 24);
            this.buttonProxFraca.Name = "buttonProxFraca";
            this.buttonProxFraca.Size = new System.Drawing.Size(73, 32);
            this.buttonProxFraca.TabIndex = 10;
            this.buttonProxFraca.Text = "Próxima";
            this.buttonProxFraca.UseVisualStyleBackColor = true;
            this.buttonProxFraca.Click += new System.EventHandler(this.buttonProxFraca_Click);
            // 
            // dataGridTabelaSimbolos
            // 
            this.dataGridTabelaSimbolos.AllowUserToAddRows = false;
            this.dataGridTabelaSimbolos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dataGridTabelaSimbolos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridTabelaSimbolos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridTabelaSimbolos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridTabelaSimbolos.BackgroundColor = System.Drawing.Color.White;
            this.dataGridTabelaSimbolos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Tomato;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridTabelaSimbolos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridTabelaSimbolos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridTabelaSimbolos.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridTabelaSimbolos.EnableHeadersVisualStyles = false;
            this.dataGridTabelaSimbolos.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridTabelaSimbolos.Location = new System.Drawing.Point(782, 100);
            this.dataGridTabelaSimbolos.Name = "dataGridTabelaSimbolos";
            this.dataGridTabelaSimbolos.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridTabelaSimbolos.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridTabelaSimbolos.Size = new System.Drawing.Size(350, 338);
            this.dataGridTabelaSimbolos.TabIndex = 11;
            // 
            // buttonTabelaSimbolos
            // 
            this.buttonTabelaSimbolos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTabelaSimbolos.Location = new System.Drawing.Point(782, 62);
            this.buttonTabelaSimbolos.Name = "buttonTabelaSimbolos";
            this.buttonTabelaSimbolos.Size = new System.Drawing.Size(147, 32);
            this.buttonTabelaSimbolos.TabIndex = 12;
            this.buttonTabelaSimbolos.Text = "Tabela Símbolos";
            this.buttonTabelaSimbolos.UseVisualStyleBackColor = true;
            this.buttonTabelaSimbolos.Click += new System.EventHandler(this.buttonTabelaSimbolos_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 450);
            this.Controls.Add(this.buttonTabelaSimbolos);
            this.Controls.Add(this.dataGridTabelaSimbolos);
            this.Controls.Add(this.buttonProxFraca);
            this.Controls.Add(this.buttonAntFraca);
            this.Controls.Add(this.buttonArvorePrecFraca);
            this.Controls.Add(this.buttonProxArvore);
            this.Controls.Add(this.buttonAntArvore);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.buttonArvore);
            this.Controls.Add(this.dataGridTabelaLex);
            this.Controls.Add(this.GerarTabela);
            this.Controls.Add(this.ModificarCodigo);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "Form1";
            this.Text = "Compilador";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTabelaLex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTabelaSimbolos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button ModificarCodigo;
        private System.Windows.Forms.Button GerarTabela;
        private System.Windows.Forms.DataGridView dataGridTabelaLex;
        private System.Windows.Forms.Button buttonArvore;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button buttonAntArvore;
        private System.Windows.Forms.Button buttonProxArvore;
        private System.Windows.Forms.Button buttonArvorePrecFraca;
        private System.Windows.Forms.Button buttonAntFraca;
        private System.Windows.Forms.Button buttonProxFraca;
        private System.Windows.Forms.DataGridView dataGridTabelaSimbolos;
        private System.Windows.Forms.Button buttonTabelaSimbolos;
    }
}

