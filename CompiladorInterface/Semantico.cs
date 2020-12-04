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
            tabelaSimbolos.Columns.Add("Categoria", typeof(String));
            tabelaSimbolos.Columns.Add("Tipo", typeof(String));
            tabelaSimbolos.Columns.Add("Valor", typeof(String));
            tabelaSimbolos.Columns.Add("Escopo", typeof(String));
            tabelaSimbolos.Columns.Add("Utilizada", typeof(String));

            return tabelaSimbolos;
        }

        public DataTable PreencherTabela() {
            //TODO: verificar variáveis repetidas
            //TODO: ERRO dentro da main

            int linhaTabela = 0;
            int linhaCodigo = 0;
            int numEscopo = 0;
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
                    novaLinha["Tipo"] = linha["Rótulo"];
                }
                else
                    novaLinha["Rótulo"] = linha["Rótulo"];

                //Valor
                if (linha["Lexema"].ToString() == "=") {
                    //ESSE TRY CATCH É TEMPORÁRIO QUEBRA QUANDO LINHA ULTRAPASSA NUM ARVORES
                    try {
                        ResultadoArvore(arvores[linhaCodigo]);

                    }
                    catch (Exception) {
                        break;
                    }
                    tabelaSimbolos.Rows[linhaTabela - 1]["Valor"] = FazCalculo(tabelaSimbolos);
                    resultadoArvore.Clear();
                }
                if (linha["Rótulo"].ToString() == "IDFUNC"
                    && tabelaLexica.Rows[linhaTabela + 3]["Rótulo"].ToString() == "{") {
                    numEscopo++;
                }

                novaLinha["Escopo"] = numEscopo;

                tabelaSimbolos.Rows.Add(novaLinha);
                linhaTabela++;
                if (linha["Lexema"].ToString() == ";") {
                    linhaCodigo++;
                    try {
                        if (tabelaLexica.Rows[linhaTabela - 2]["Rótulo"].ToString() == "ID")
                            if (tabelaLexica.Rows[linhaTabela - 3]["Rótulo"].ToString() == "PR")
                                linhaCodigo--;
                    }
                    catch (Exception) {//out of bounds
                    }

                }
            }

            //Atribuir tipo

            return tabelaSimbolos;
        }

        private void ResultadoArvore(TreeNode pai) { // Pegar árvore precedência fraca
            foreach (TreeNode filho in pai.Nodes) {
                if (filho.Text == "v" || filho.Text == "*" || filho.Text == "+")
                    resultadoArvore.Add(filho.Name);

                ResultadoArvore(filho);
            }

        }

        private string FazCalculo(DataTable tabela) {
            double resultado;
            if (resultadoArvore.Count == 1)
                return resultadoArvore[0];

            if (resultadoArvore[1] == "*")
                resultado = 1;
            else
                resultado = 0;

            List<double> valores = new List<double>();
            List<string> operacao = new List<string>();
            foreach (var terminal in resultadoArvore) {
                try {
                    valores.Add(Convert.ToDouble(terminal));
                }
                catch (Exception) {
                    if (terminal != "*" && terminal != "+" && terminal != ";") {
                        double valorTemporario = Double.NaN;

                        foreach (DataRow linha in tabela.Rows) {
                            if (linha["Lexema"].ToString() == terminal) {
                                try {
                                    valorTemporario = Convert.ToDouble(linha["Valor"].ToString());
                                    valores.Add(valorTemporario);
                                }
                                catch (Exception) {
                                    return "ERRO variável " + terminal + " não foi declarada";
                                }
                                break;
                            }
                        }
                        if (Double.IsNaN(valorTemporario))
                            return "ERRO variável " + terminal + " não foi declarada";

                    }
                    else
                        operacao.Add(terminal);

                }
            }

            for (int i = 0, j = 0; i < valores.Count; i++) {
                if (operacao[j] == "*") {
                    resultado = resultado * valores[i];
                }
                else if (operacao[j] == "+") {
                    resultado = resultado + valores[i];
                }
                if (i % 2 != 0)
                    j++;

            }
            return resultado.ToString();
        }

    }
}

//lexema, token, categoria(var,func), tipo(int,float), valor, escopo, utilizada(S,N)