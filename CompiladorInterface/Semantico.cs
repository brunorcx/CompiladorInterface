using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompiladorInterface {

    internal class Semantico {
        public List<string> listaErros;
        private DataTable tabelaLexica;
        private List<TreeNode> arvores;
        private List<string> resultadoArvore = new List<string>();

        public Semantico(DataTable tabela, List<TreeNode> listaArvore) {
            tabelaLexica = tabela;
            arvores = listaArvore;
        }

        private DataTable CriarEsquemaTabelaSimbolos() {
            DataTable tabelaSimbolos = new DataTable("tabelaSimbolos");
            //Definir esquema da tabela ############
            tabelaSimbolos.Columns.Add("Lexema", typeof(String));
            tabelaSimbolos.Columns.Add("Rótulo", typeof(String));
            tabelaSimbolos.Columns.Add("Tipo", typeof(String));
            tabelaSimbolos.Columns.Add("Valor", typeof(String));
            tabelaSimbolos.Columns.Add("Escopo", typeof(String));
            tabelaSimbolos.Columns.Add("Declarada", typeof(String));
            tabelaSimbolos.Columns.Add("Linha", typeof(String));

            return tabelaSimbolos;
        }

        public DataTable PreencherTabela() {
            listaErros = new List<string>();
            List<string> linhaLexemas = new List<string>();
            List<string> linhaRotulos = new List<string>();
            int linhaTabela = 0;
            int linhaCodigo = 0;
            int nivelEscopo = 0;
            DataTable tabelaSimbolos = CriarEsquemaTabelaSimbolos();
            DataRow novaLinha;
            //Carregar lexemas, rótulos e categorias
            foreach (DataRow linha in tabelaLexica.Rows) {
                linhaLexemas.Add(linha["Lexema"].ToString());
                linhaRotulos.Add(linha["Rótulo"].ToString());
                if (linha["Rótulo"].ToString() == "IDFUNC") {
                    nivelEscopo++;
                }
                else if (linha["Rótulo"].ToString() == "}") {
                    nivelEscopo--;
                }
                else if (linha["Rótulo"].ToString() == "$") {
                    for (int i = 0; i < linhaRotulos.Count; i++) {
                        if (linhaRotulos[i] == "PR") { // CASO 1
                            novaLinha = tabelaSimbolos.NewRow();
                            novaLinha["Lexema"] = linhaLexemas[i];
                            novaLinha["Rótulo"] = linhaRotulos[i];
                            novaLinha["Linha"] = (linhaCodigo + 1);
                            novaLinha["Escopo"] = nivelEscopo;
                            tabelaSimbolos.Rows.Add(novaLinha);
                        }// Fim CASO 1
                        else if (linhaRotulos[i] == "ID") {// CASO 2
                            string erroPossivel = String.Empty;
                            int escopoAtual = nivelEscopo;
                            if (tabelaSimbolos.Rows.Count - 1 > 1) {
                                for (int j = tabelaSimbolos.Rows.Count - 1; j >= 0; j--) {//Olhar se variável já está na tabela
                                    if (escopoAtual.ToString() == tabelaSimbolos.Rows[j]["Escopo"].ToString()) {
                                        if ("}" == tabelaSimbolos.Rows[j]["Escopo"].ToString()) {//Retirar funções no mesmo nível
                                            escopoAtual--;
                                            continue;
                                        }
                                        if (linhaRotulos[i] == tabelaSimbolos.Rows[j]["Lexema"].ToString()) {//Verificar variável
                                            if (i - 1 >= 0) {
                                                if (linhaRotulos[i - 1] == "PR") {
                                                    erroPossivel = "ERRO Variável " + linhaLexemas[i] + " já foi declarada próximo a linha " + (linhaCodigo + 1);
                                                    listaErros.Add(erroPossivel);
                                                    break;
                                                }

                                            }
                                            if (tabelaSimbolos.Rows[j]["Declarada"].ToString() == null) {
                                                erroPossivel = "ERRO Variável " + linhaLexemas[i] + " não foi declarada próximo a linha " + (linhaCodigo + 1);
                                                listaErros.Add(erroPossivel);
                                                break;
                                            }
                                        }
                                    }
                                    else {
                                        escopoAtual--;
                                    }

                                }//Fim variável repetida na tabela
                            }
                            if (erroPossivel == String.Empty) { //Não achou repetida e não deu erro
                                if (i - 1 >= 0) {
                                    novaLinha = tabelaSimbolos.NewRow();
                                    novaLinha["Tipo"] = linhaLexemas[i - 1].ToUpper();
                                    novaLinha["Lexema"] = linhaLexemas[i];
                                    novaLinha["Rótulo"] = "VAR";
                                    novaLinha["Linha"] = (linhaCodigo + 1);
                                    novaLinha["Escopo"] = nivelEscopo;
                                    tabelaSimbolos.Rows.Add(novaLinha);
                                }
                                else {
                                    listaErros.Add("ERRO Variável " + linhaLexemas[i] + " não foi declarada próximo a linha " + (linhaCodigo + 1));
                                }
                            }
                        } // Fim CASO 2
                        else if (linhaRotulos[i] == "}") { //CASO 3
                            novaLinha = tabelaSimbolos.NewRow();
                            novaLinha["Lexema"] = linhaLexemas[i];
                            novaLinha["Rótulo"] = linhaRotulos[i];
                            novaLinha["Linha"] = (linhaCodigo + 1);
                            novaLinha["Escopo"] = nivelEscopo;
                            tabelaSimbolos.Rows.Add(novaLinha);
                        }//Fim CASO 3
                        //TODO: Fazer caso = para rodar até o final do for L57 e PULAR VARIÁVEIS DO LADO DIREITO e verificar soma de inteiros/doubles
                        novaLinha = null;
                    }//Fim for próximo lexema

                    linhaRotulos.Clear();
                    linhaLexemas.Clear();
                    linhaCodigo++;
                }
                //Escopo dá para fazer como tinha feito com um variável inteira, basta começar da linha onde está executando
                //Olhar os niveis e andar até o nível chegar a 0
                linhaTabela++;
            }

            return tabelaSimbolos;
        }

    }
}

//lexema, token, categoria(var,func), tipo(int,float), valor, escopo, utilizada(S,N)