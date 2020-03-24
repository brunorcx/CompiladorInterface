using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompiladorInterface {

    public partial class Form1 : Form {

        public Form1() {
            InitializeComponent();

        }

        private void ModificarCodigo_Click_1(object sender, EventArgs e) {
            Process.Start("notepad.exe", "..\\..\\Codigo.txt");

        }

        private void GerarTabela_Click(object sender, EventArgs e) {
            DataTable tabela;
            List<string> listaLinhas = new List<string>();
            Lexico lexico = new Lexico();
            listaLinhas = lexico.lerArquivo();

            dataGridTabelaLex.DataSource = lexico.separarLexemas(listaLinhas);

        }

    }
}