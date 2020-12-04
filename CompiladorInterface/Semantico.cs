using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompiladorInterface {

    internal class Semantico {
        private DataTable tabelaLexica;
        private List<TreeNode> arvores;
        private List<string> resultado = new List<string>();

        public Semantico(DataTable tabela, List<TreeNode> listaArvore) {
            tabelaLexica = tabela;
            arvores = listaArvore;
        }

        private DataTable CriarEsquemaTabelaSimbolos() {
            DataTable tabelaSimbolos = new DataTable("tabelaSimbolos");
            //Definir esquema da tabela ############
            tabelaSimbolos.Columns.Add("Lexema", typeof(String));
            tabelaSimbolos.Columns.Add("Rótulo", typeof(String));
            tabelaSimbolos.Columns.Add("Categoria", typeof(String));
            tabelaSimbolos.Columns.Add("Tipo", typeof(String));
            tabelaSimbolos.Columns.Add("Valor", typeof(String));
            tabelaSimbolos.Columns.Add("Escopo", typeof(String));
            tabelaSimbolos.Columns.Add("Utilizada", typeof(String));

            return tabelaSimbolos;
        }

        public DataTable PreencherTabela() {
            int linhaTabela = 0;
            int linhaCodigo = 2;
            DataTable tabelaSimbolos = CriarEsquemaTabelaSimbolos();

            //Carregar lexemas, rótulos e categorias
            foreach (DataRow linha in tabelaLexica.Rows) {
                DataRow novaLinha = tabelaSimbolos.NewRow();
                novaLinha["Lexema"] = linha["Lexema"];

                if (linha["Rótulo"].ToString() == "ID") { //variável
                    novaLinha["Categoria"] = "VAR";
                    if (linhaTabela > 0 && (tabelaLexica.Rows[linhaTabela - 1]["Rótulo"].ToString() == "INT" || tabelaLexica.Rows[linhaTabela - 1]["Rótulo"].ToString() == "FLOAT")) {
                        novaLinha["Tipo"] = tabelaLexica.Rows[linhaTabela - 1]["Rótulo"];
                    }

                }
                else if (linha["Rótulo"].ToString() == "INT" || linha["Rótulo"].ToString() == "FLOAT") {
                    novaLinha["Rótulo"] = "NUM";
                    novaLinha["Tipo"] = linha["Lexema"];
                }
                else
                    novaLinha["Rótulo"] = linha["Rótulo"];

                //Valor
                if (linha["Lexema"].ToString() == "=") {
                    ResultadoArvore(arvores[linhaCodigo]);
                    tabelaLexica.Rows[linhaTabela - 1]["Valor"] = resultado;
                }

                tabelaSimbolos.Rows.Add(novaLinha);
                linhaTabela++;
                if (linha["Lexema"].ToString() == ";")
                    linhaCodigo++;
            }

            //Atribuir tipo

            return tabelaSimbolos;
        }

        private void ResultadoArvore(TreeNode pai) { // Pegar árvore precedência fraca
            foreach (TreeNode filho in pai.Nodes) {
                if (filho.Text == "v" || filho.Text == "*" || filho.Text == "+")
                    resultado.Add(filho.Text);

                ResultadoArvore(filho);
            }

        }

    }
}

//lexema, token, categoria(var,func), tipo(int,float), valor, escopo, utilizada(S,N)