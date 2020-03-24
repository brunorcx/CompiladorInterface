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
            this.ModificarCodigo = new System.Windows.Forms.Button();
            this.GerarTabela = new System.Windows.Forms.Button();
            this.dataGridTabelaLex = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTabelaLex)).BeginInit();
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
            this.GerarTabela.Location = new System.Drawing.Point(207, 12);
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
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Empty;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridTabelaLex.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridTabelaLex.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Empty;
            this.dataGridTabelaLex.Size = new System.Drawing.Size(491, 338);
            this.dataGridTabelaLex.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridTabelaLex);
            this.Controls.Add(this.GerarTabela);
            this.Controls.Add(this.ModificarCodigo);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "Form1";
            this.Text = "Varredor de Lexemas";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTabelaLex)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button ModificarCodigo;
        private System.Windows.Forms.Button GerarTabela;
        private System.Windows.Forms.DataGridView dataGridTabelaLex;
    }
}

