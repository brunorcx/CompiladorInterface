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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ModificarCodigo = new System.Windows.Forms.Button();
            this.GerarTabela = new System.Windows.Forms.Button();
            this.dataGridTabelaLex = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTabelaLex)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
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
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dataGridTabelaLex.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridTabelaLex.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridTabelaLex.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridTabelaLex.BackgroundColor = System.Drawing.Color.White;
            this.dataGridTabelaLex.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Tomato;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridTabelaLex.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridTabelaLex.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridTabelaLex.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridTabelaLex.EnableHeadersVisualStyles = false;
            this.dataGridTabelaLex.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridTabelaLex.Location = new System.Drawing.Point(12, 100);
            this.dataGridTabelaLex.Name = "dataGridTabelaLex";
            this.dataGridTabelaLex.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Empty;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridTabelaLex.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridTabelaLex.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Empty;
            this.dataGridTabelaLex.Size = new System.Drawing.Size(491, 213);
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
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTabelaLex)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button ModificarCodigo;
        private System.Windows.Forms.Button GerarTabela;
        private System.Windows.Forms.DataGridView dataGridTabelaLex;
    }
}

