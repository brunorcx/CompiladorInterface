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
            var arvore = sintaxe.AnalisadorPreditivo();

            if (arvore == null) {
                MessageBox.Show("Sentença não reconhecida, verifique a linha tal");
            }
            else {
                //Cronstruir Árvore
                List<TreeNode> listaNos = new List<TreeNode>();
                TreeNode<string> noPre;
                TreeNode noL = new TreeNode();
                foreach (var no in sintaxe.listaNos) {
                    listaNos.Add(new TreeNode(no.Value));
                }

                for (int i = 0; i < listaNos.Count; i++) {
                    noPre = sintaxe.listaNos[i];
                    noL = listaNos[i];

                    foreach (var children in noPre.Children) {
                        for (int j = i; j < listaNos.Count; j++) {
                            if (children.Value == listaNos[j].Text && listaNos[j].Parent == null) {
                                noL.Nodes.Add(listaNos[j]);
                                break;
                            }
                        }
                    }

                }

                /*
                listaNos.Add(new TreeNode("E"));
                listaNos.Add(new TreeNode("F"));
                listaNos.Add(new TreeNode("D"));
                listaNos.Add(new TreeNode("&"));

                TreeNode raiz = new TreeNode("E", new TreeNode[] { listaNos[1], listaNos[2] });
                listaNos[1].Nodes.Add(listaNos[3]);
                */
                treeView1.Nodes.Add(listaNos[0]);

                treeView1.ExpandAll();
            }
        }
    }
}

//Gramática C https://www.ime.usp.br/~fmario/mac122-15/gramatica.html
//Gramática C Yacc https://www.lysator.liu.se/c/ANSI-C-grammar-y.html
//GPLEX https://stackoverflow.com/questions/10808564/parser-generator-how-to-use-gplex-and-gppg-together