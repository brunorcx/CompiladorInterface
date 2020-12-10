using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompiladorInterface {

    internal class CodInter {
        private DataTable tabelaSimbolos;
        private DataTable tabelaLexica;
        private List<TreeNode> arvores;
        private List<string> listaArvoreSimplificada = new List<string>();

        public CodInter(DataTable tabelaSimbolos, DataTable tabelaLexica, List<TreeNode> listaArvore) {
            this.tabelaSimbolos = tabelaSimbolos;
            this.tabelaLexica = tabelaLexica;
            arvores = listaArvore;
        }

        private DataTable CriarEsquemaCodInter() {
            DataTable tabelaCodInter = new DataTable("tabelaCodInter");
            //Definir esquema da tabela ############
            tabelaCodInter.Columns.Add("Operador", typeof(String));
            tabelaCodInter.Columns.Add("Arg1", typeof(String));
            tabelaCodInter.Columns.Add("Arg2", typeof(String));
            tabelaCodInter.Columns.Add("Resultado", typeof(String));

            return tabelaCodInter;
        }

        public DataTable PreencherTabela() {
            List<string> linhaLexemas = new List<string>();
            List<string> linhaRotulos = new List<string>();
            DataTable tabelaCodInter = CriarEsquemaCodInter();
            int linhaTabela = 0;
            int linhaCodigo = 0;
            int nivelEscopo = 0;
            int arvoresSintaticas = 0;
            foreach (DataRow linha in tabelaLexica.Rows) {
                linhaLexemas.Add(linha["Lexema"].ToString());
                linhaRotulos.Add(linha["Rótulo"].ToString());
                if (linha["Rótulo"].ToString() == "IDFUNC") {
                    nivelEscopo++;
                }
                else if (linha["Rótulo"].ToString() == "}") {
                    nivelEscopo--;
                }

                if (linha["Rótulo"].ToString() == "$" || linha["Rótulo"].ToString() == "{" || linha["Rótulo"].ToString() == "}") {
                    for (int i = 0; i < linhaRotulos.Count; i++) {
                        if (linhaRotulos[i] == "=") {
                            var linhas = GerarCodigoLinha(arvores[arvoresSintaticas], tabelaCodInter);
                            foreach (var nLinha in linhas) {
                                tabelaCodInter.Rows.Add(nLinha);
                            }
                            arvoresSintaticas++;
                        }//Fim CASO 1
                        else if (linhaRotulos[i] == "IDFUNC") {
                        }// Fim CASO 2
                    }

                    linhaCodigo++;
                }
                linhaTabela++;
                if (arvoresSintaticas > arvores.Count - 1) {
                    break;
                }
            }

            return tabelaCodInter;
        }

        private DataRow ProcurarVariavelRepetida(DataTable tabela, int escopoAtual, string variavel) {
            if (tabela.Rows.Count - 1 >= 1)
                for (int i = tabela.Rows.Count - 1; i >= 0; i--) {
                    if (escopoAtual.ToString() == tabela.Rows[i]["Escopo"].ToString()) {
                        if ("}" == tabela.Rows[i]["Escopo"].ToString() && escopoAtual > 0) {//Retirar funções no mesmo nível
                            escopoAtual--;
                            continue;
                        }
                        if (variavel == tabela.Rows[i]["Lexema"].ToString()) {
                            return tabela.Rows[i];
                        }
                    }
                    else {
                        if (escopoAtual > 0 && tabela.Rows[i]["Rótulo"].ToString() == "IDFUNC")
                            escopoAtual--;
                    }
                }

            return null;

        }

        private void ArvoreSimplificada(TreeNode pai) { // Pegar árvore precedência fraca
            foreach (TreeNode filho in pai.Nodes) {
                if (filho.Text == "v" || filho.Text == "*" || filho.Text == "+")
                    listaArvoreSimplificada.Add(filho.Name);

                ArvoreSimplificada(filho);
            }

        }

        private List<DataRow> GerarCodigoLinha(TreeNode arvore, DataTable tabelaCod) {
            int numLinha = 0;
            List<DataRow> linhas = new List<DataRow>();
            DataRow novaLinha = tabelaCod.NewRow();
            ArvoreSimplificada(arvore);
            //TODO: rodar e ver o que está acontecendo com debugger
            if (listaArvoreSimplificada.Count == 1) {
                novaLinha["Operador"] = "=";
                novaLinha["Arg1"] = listaArvoreSimplificada[0];
                novaLinha["Resultado"] = listaArvoreSimplificada[0];
                linhas.Add(novaLinha);
                return linhas;
            }
            foreach (var terminal in listaArvoreSimplificada) {
                if (terminal == "*" || terminal == "+") {
                    if (numLinha > 0) {
                        novaLinha = tabelaCod.NewRow();
                    }
                    novaLinha["Operador"] = terminal;
                }
                else {
                    if (novaLinha["Arg1"] == null) {
                        if (numLinha > 0) {
                            novaLinha["Arg1"] = linhas[numLinha - 1]["Resultado"];
                            novaLinha["Arg2"] = terminal;
                            novaLinha["Resultado"] = "t" + numLinha;
                            numLinha++;
                        }
                        else {
                            novaLinha["Arg1"] = terminal;
                        }
                    }
                    else {
                        if (numLinha > 0) {
                        }
                        else {
                            novaLinha["Arg2"] = terminal;
                            novaLinha["Resultado"] = "t" + numLinha;
                            numLinha++;
                            linhas.Add(novaLinha);
                        }
                    }
                }

            }

            listaArvoreSimplificada.Clear();
            return linhas;
        }

    }
}