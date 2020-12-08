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
            tabelaSimbolos.Columns.Add("Declarada", typeof(String));

            return tabelaSimbolos;
        }

        private DataTable PreencherTabela() {
            //TODO: verificar variáveis repetidas
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
                    if ((linhaTabela > 0) && (tabelaLexica.Rows[linhaTabela - 1]["Lexema"].ToString().ToUpper() == "INT"
                        || tabelaLexica.Rows[linhaTabela - 1]["Lexema"].ToString().ToUpper() == "FLOAT")) {
                        novaLinha["Tipo"] = tabelaLexica.Rows[linhaTabela - 1]["Lexema"].ToString().ToUpper();
                        novaLinha["Declarada"] = "S";
                    }
                    else
                        novaLinha["Declarada"] = "N";

                }
                else if (linha["Rótulo"].ToString() == "INT" || linha["Rótulo"].ToString() == "FLOAT") {
                    novaLinha["Rótulo"] = "NUM";
                    novaLinha["Tipo"] = linha["Rótulo"];
                }
                else
                    novaLinha["Rótulo"] = linha["Rótulo"];

                //Tratar Escopo
                if (linha["Rótulo"].ToString() == "IDFUNC"
                    && tabelaLexica.Rows[linhaTabela + 3]["Rótulo"].ToString() == "{") {
                    numEscopo++;
                }
                else if (linha["Rótulo"].ToString() == "}") {
                    numEscopo--;
                }

                novaLinha["Escopo"] = numEscopo;

                //Valor
                if (linha["Lexema"].ToString() == "=") {
                    string varTemp = tabelaLexica.Rows[linhaTabela - 1]["Lexema"].ToString();
                    string calculo;
                    DataRow linhaTemp;
                    //ESSE TRY CATCH É TEMPORÁRIO QUEBRA QUANDO LINHA ULTRAPASSA NUM ARVORES
                    try {
                        ResultadoArvore(arvores[linhaCodigo]);
                    }
                    catch (Exception) {
                        break;
                    }
                    calculo = FazCalculo(tabelaSimbolos, linhaTabela, numEscopo);
                    tabelaSimbolos.Rows[linhaTabela - 1]["Valor"] = calculo;
                    resultadoArvore.Clear();

                    //Adicionar valor de acordo com o escopo
                    List<DataRow> linhasVar = new List<DataRow>();
                    for (int i = 0; i < linhaTabela; i++) {
                        linhaTemp = tabelaSimbolos.Rows[i];
                        if (varTemp == linhaTemp["Lexema"].ToString()) {
                            if (linhaTemp["Declarada"].ToString() == "S") {
                                if (numEscopo.ToString() == linhaTemp["Escopo"].ToString()) {
                                    linhaTemp["Valor"] = calculo;
                                    linhasVar.Clear();
                                    break;
                                }
                                else
                                    linhasVar.Insert(0, linhaTemp);
                            }
                        }
                    }
                    if (linhasVar.Count != 0) {
                        for (int i = numEscopo - 1, j = 0; i >= 0; i--, j++) {
                            if (linhasVar[j]["Escopo"].ToString() == i.ToString()) {
                                linhasVar[j]["Valor"] = calculo;
                                break;
                            }
                        }
                    }
                }

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

        private string FazCalculo(DataTable tabela, int linhaTabela, int numEscopo) {
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
                        // COMEÇA AQUI

                        //TERMINA AQUI
                        foreach (DataRow linha in tabela.Rows) {
                            if (linha["Lexema"].ToString() == terminal) {
                                try {
                                    valorTemporario = Convert.ToDouble(linha["Valor"].ToString());
                                    valores.Add(valorTemporario);
                                }
                                catch (Exception) {
                                    if (linha["Escopo"].ToString() != numEscopo.ToString())
                                        continue;
                                    else
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

        public DataTable FormatarTabela() {
            DataTable tabelaSimbolos = PreencherTabela();

            return tabelaSimbolos;
        }

    }
}

//lexema, token, categoria(var,func), tipo(int,float), valor, escopo, utilizada(S,N)