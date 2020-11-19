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
        private DataTable tabela;
        private int numArvore;
        private int numArvoreFracas;
        private List<TreeNode> arvores;
        private List<TreeNode> arvoresFracas;

        public Form1() {
            InitializeComponent();

        }

        private void ModificarCodigo_Click_1(object sender, EventArgs e) {
            var path = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Codigo.txt");
            Process.Start("notepad.exe", path);
        }

        private void GerarTabela_Click(object sender, EventArgs e) {
            //Código novo
            //sintaxe.AnalisadorPreditivo();
            //Finaliza aqui
            List<string> listaLinhas = new List<string>();
            //Léxico
            Lexico lexico = new Lexico();
            listaLinhas = lexico.lerArquivo();
            tabela = lexico.separarLexemas(listaLinhas);
            dataGridTabelaLex.DataSource = tabela;

        }

        private void buttonArvore_Click(object sender, EventArgs e) {
            //Sintaxe
            Sintaxe sintaxe = new Sintaxe(tabela);
            arvores = sintaxe.AnalisadorPreditivo();
            treeView1.Nodes.Clear();
            treeView1.Nodes.Add(arvores[0]);
            treeView1.ExpandAll();
        }

        private void buttonAntArvore_Click(object sender, EventArgs e) {
            if (arvores == null) {
                MessageBox.Show("Por favor gere a árvore primeiro");
            }
            else {
                if (numArvore > 0) {
                    numArvore--;
                    treeView1.Nodes.Clear();
                    treeView1.Nodes.Add(arvores[numArvore]);
                    treeView1.ExpandAll();
                }
            }
        }

        private void buttonProxArvore_Click(object sender, EventArgs e) {
            if (arvores == null) {
                MessageBox.Show("Por favor gere a árvore primeiro");
            }
            else {
                if (numArvore < arvores.Count - 1) {
                    numArvore++;
                    treeView1.Nodes.Clear();
                    treeView1.Nodes.Add(arvores[numArvore]);
                    treeView1.ExpandAll();
                }
            }
        }

        private void buttonArvorePrecFraca_Click(object sender, EventArgs e) {
            Sintaxe sintaxe = new Sintaxe(tabela);
            arvoresFracas = sintaxe.AnalisadorPrecedênciaFraca();
            treeView1.Nodes.Clear();
            treeView1.Nodes.Add(arvoresFracas[0]);
            treeView1.ExpandAll();
        }

        private void buttonAntFraca_Click(object sender, EventArgs e) {
            if (arvoresFracas == null) {
                MessageBox.Show("Por favor gere a árvore primeiro");
            }
            else {
                if (numArvoreFracas > 0) {
                    numArvoreFracas--;
                    treeView1.Nodes.Clear();
                    treeView1.Nodes.Add(arvoresFracas[numArvoreFracas]);
                    treeView1.ExpandAll();
                }
            }
        }

        private void buttonProxFraca_Click(object sender, EventArgs e) {
            if (arvoresFracas == null) {
                MessageBox.Show("Por favor gere a árvore primeiro");
            }
            else {
                if (numArvoreFracas < arvoresFracas.Count - 1) {
                    numArvoreFracas++;
                    treeView1.Nodes.Clear();
                    treeView1.Nodes.Add(arvoresFracas[numArvoreFracas]);
                    treeView1.ExpandAll();
                }
            }
        }
    }
}

//Gramática C https://www.ime.usp.br/~fmario/mac122-15/gramatica.html
//Gramática C Yacc https://www.lysator.liu.se/c/ANSI-C-grammar-y.html
//GPLEX https://stackoverflow.com/questions/10808564/parser-generator-how-to-use-gplex-and-gppg-together