﻿using System;
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
            int arvoresSintaticas = 0;
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
                if (linha["Rótulo"].ToString() == "$" || linha["Rótulo"].ToString() == "{" || linha["Rótulo"].ToString() == "}") {
                    string declaTemp = String.Empty;
                    if (linhaRotulos.Count >= 3) {
                        declaTemp = linhaRotulos[0] + linhaRotulos[1] + linhaRotulos[2];
                    }
                    else if (linhaRotulos.Count == 1) {
                        declaTemp = linhaRotulos[0];
                    }
                    if (!linhaRotulos.Contains("IDFUNC") && !linhaRotulos.Contains("=") && declaTemp != "PRID$" && declaTemp != "}") {
                        listaErros.Add("Somente as expressões de atribuição e chamada podem ser usadas como instrução linha " + (linhaCodigo + 1));
                    }
                    else {
                        for (int i = 0; i < linhaRotulos.Count; i++) {
                            if (linhaRotulos[i] == "PR") { // CASO 1
                                novaLinha = tabelaSimbolos.NewRow();
                                novaLinha["Lexema"] = linhaLexemas[i];
                                novaLinha["Rótulo"] = linhaRotulos[i];
                                novaLinha["Linha"] = (linhaCodigo + 1);
                                novaLinha["Escopo"] = nivelEscopo;
                                tabelaSimbolos.Rows.Add(novaLinha);
                            }//Fim CASO 1
                            else if (linhaRotulos[i] == "ID") {// CASO 2
                                string erroPossivel = String.Empty;
                                int escopoAtual = nivelEscopo;
                                if (tabelaSimbolos.Rows.Count - 1 > 1) {
                                    for (int j = tabelaSimbolos.Rows.Count - 1; j >= 0; j--) {//Olhar se variável já está na tabela
                                        if (escopoAtual.ToString() == tabelaSimbolos.Rows[j]["Escopo"].ToString()) {
                                            if ("}" == tabelaSimbolos.Rows[j]["Rótulo"].ToString() && escopoAtual > 0) {//Retirar funções no mesmo nível
                                                escopoAtual--;
                                                continue;
                                            }
                                            if (linhaLexemas[i] == tabelaSimbolos.Rows[j]["Lexema"].ToString()) {//Verificar variável
                                                if (i - 1 >= 0) {
                                                    if (linhaRotulos[i - 1] == "PR") {
                                                        erroPossivel = "ERRO Variável " + linhaLexemas[i] + " já foi declarada próximo a linha " + (linhaCodigo + 1);
                                                        listaErros.Add(erroPossivel);
                                                        break;
                                                    }
                                                }/*
                                                if (tabelaSimbolos.Rows[j]["Declarada"] == null) {
                                                    erroPossivel = "ERRO Variável " + linhaLexemas[i] + " não foi declarada próximo a linha " + (linhaCodigo + 1);
                                                    listaErros.Add(erroPossivel);
                                                    break;
                                                }
                                                */
                                                erroPossivel = "Repetida";
                                                break;
                                            }
                                        }
                                        else {
                                            if (escopoAtual > 0 && tabelaSimbolos.Rows[j]["Rótulo"].ToString() == "IDFUNC")
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
                                        novaLinha["Declarada"] = "S";
                                        tabelaSimbolos.Rows.Add(novaLinha);
                                    }
                                    else if (erroPossivel != "Repetida") {
                                        listaErros.Add("ERRO Variável " + linhaLexemas[i] + " não foi declarada próximo a linha " + (linhaCodigo + 1));
                                    }
                                    //Achou repetida colocar um else{ substituir valor}
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
                            else if (linhaRotulos[i] == "=") { // CASO 4
                                var linhaTemp = ProcurarVariavelRepetida(tabelaSimbolos, nivelEscopo, linhaLexemas[i - 1]);
                                if (linhaTemp != null) {
                                    i++;
                                    if (linhaTemp["Tipo"].ToString() == "INT") {
                                        DataRow varTemp = null;
                                        while (i < linhaRotulos.Count) {
                                            string varTipo = linhaRotulos[i];
                                            if (varTipo == "ID") {
                                                varTemp = ProcurarVariavelRepetida(tabelaSimbolos, nivelEscopo, linhaLexemas[i]);
                                                if (varTemp == null) {
                                                    listaErros.Add("ERRO Variável " + linhaLexemas[i] + " não foi declarada próximo a linha " + (linhaCodigo + 1));
                                                    break;
                                                }
                                                else {
                                                    varTipo = varTemp["Tipo"].ToString();
                                                }
                                            }
                                            if (varTipo == "FLOAT" || varTipo == "DOUBLE") {
                                                listaErros.Add("ERRO variavel " + linhaTemp["Lexema"] + " é do tipo INT, portanto só pode receber valores do mesmo tipo linha " + (linhaCodigo + 1));
                                                i = linhaRotulos.Count;
                                                break;
                                            }
                                            i++;
                                        }
                                    }
                                }
                                else {
                                    i = linhaRotulos.Count;
                                }
                                arvoresSintaticas++;
                            }//Fim CASO 4
                            else if (linhaRotulos[i] == "IDFUNC") { //CASO 5
                                string erroPossivel = String.Empty;
                                var linhaTemp = ProcurarVariavelRepetida(tabelaSimbolos, nivelEscopo, linhaLexemas[i]);
                                if (linhaTemp != null) {
                                    if (i - 1 >= 0) {
                                        if (linhaRotulos[i - 1] == "PR") {
                                            listaErros.Add("ERRO Função " + linhaLexemas[i] + " já foi definida próximo a linha " + (linhaCodigo + 1));
                                        }
                                    }
                                }
                                else {
                                    if (i - 1 >= 0) {
                                        if (linhaRotulos[i - 1] == "PR") {
                                            novaLinha = tabelaSimbolos.NewRow();
                                            novaLinha["Lexema"] = linhaLexemas[i];
                                            novaLinha["Rótulo"] = linhaRotulos[i];
                                            novaLinha["Linha"] = (linhaCodigo + 1);
                                            novaLinha["Escopo"] = nivelEscopo;
                                            novaLinha["Tipo"] = linhaLexemas[i - 1];
                                            tabelaSimbolos.Rows.Add(novaLinha);
                                            i = linhaRotulos.Count;
                                        }
                                        else {
                                            listaErros.Add("ERRO Função " + linhaLexemas[i] + " não foi definida próximo a linha " + (linhaCodigo + 1));
                                        }
                                    }
                                    else {
                                        listaErros.Add("ERRO Função " + linhaLexemas[i] + " não foi definida próximo a linha " + (linhaCodigo + 1));
                                    }

                                }
                            }//Fim Caso 5
                            novaLinha = null;
                        }//Fim for próximo lexema
                    }
                    linhaRotulos.Clear();
                    linhaLexemas.Clear();
                    linhaCodigo++;
                }
                //Escopo dá para fazer como tinha feito com um variável inteira, basta começar da linha onde está executando
                //Olhar os niveis e andar até o nível chegar a 0
                linhaTabela++;
                if (arvoresSintaticas == arvores.Count) {
                    break;
                }
            }

            return tabelaSimbolos;
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

    }
}

//lexema, token, categoria(var,func), tipo(int,float), valor, escopo, utilizada(S,N)