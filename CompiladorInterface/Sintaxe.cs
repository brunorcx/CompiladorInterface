using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompiladorInterface {

    internal class Sintaxe {
        private DataTable tabela;
        public List<TreeNode<string>> listaNos;

        public Sintaxe(DataTable table) {
            tabela = table;
        }

        public TreeNode<string> AnalisadorPreditivo() {
            //Inicia aqui
            return SomaMultiParen();

        }

        //Finazaliza aqui

        public void CriarArvore() {
            TreeNode<string> no = new TreeNode<string>("Raiz");

            var filhoe = no.AddChild("FilhoEsquerdo");
            var filhod = no.AddChild("FilhoDireito");

            filhoe.AddChild("FilhoEE");

            no.Traverse(PreOrdem);

        }

        public void PreOrdem(string valor) {
            string teste;
            teste = valor;
        }

        private TreeNode<string> SomaMultiParen() {
            listaNos = new List<TreeNode<string>>();
            List<TreeNode<string>> listaTemp = new List<TreeNode<string>>();
            TreeNode<string> noArvore = new TreeNode<string>("E");//Raiz
            listaNos.Add(noArvore);
            string linhaLexica = String.Empty;
            Stack pilha = new Stack();
            foreach (System.Data.DataRow linha in tabela.Rows) {
                //ID INT FLOAT mudar para v
                if (linha["Rótulo"].ToString() == "ID" || linha["Rótulo"].ToString() == "INT"
                    || linha["Rótulo"].ToString() == "FLOAT")
                    linhaLexica = linhaLexica + "v";
                else
                    linhaLexica = linhaLexica + linha["Rótulo"];

                if (linha["Lexema"].ToString() == ";") {
                    //As palavras estão sem espaços, para mudar isso é só adicionar um " " na atribuição da linhaLexica
                    string str = linhaLexica.Replace(";", "$S");//Essa string deve receber a setença e colocar $ no final

                    /* Declarando a tabela sintatica para o automato M */
                    int[,] M = new int[5, 6]{
                        {9, 9, 1, 9, 1, 9},
                        {2, 9, 9, 3, 9, 3},
                        {9, 9, 4, 9, 4, 9},
                        {6, 5, 9, 6, 9, 6},
                        {9, 9, 7, 9, 8, 9}
                    };
                    /* Colocando o simbolo delimitador na pilha*/
                    pilha.Push('$');
                    /* Colocando o simbolo sentencial na pilha*/
                    pilha.Push('E');
                    /* Recebera a indexação referente ao matriz*/
                    int c;
                    int l;
                    int i;
                    /* Recebera as produções*/
                    string prod;
                    /* Percorrendo toda a sentenca de avaliacao*/
                    for (i = 0; str.Length != i; i++) {//ATUALIZAR PARA TABELA
                        switch (str[i]) {
                            case '+':
                                c = 0;
                                break;

                            case '*':
                                c = 1;
                                break;

                            case '(':
                                c = 2;
                                break;

                            case ')':
                                c = 3;
                                break;

                            case 'v':
                                c = 4;
                                break;

                            case '$':
                                c = 5;
                                break;

                            default:
                                return null;
                        }
                        while (true) {
                            switch (pilha.Peek()) {
                                case 'E':
                                    l = 0;
                                    break;

                                case 'F':
                                    l = 1;
                                    break;

                                case 'M':
                                    l = 2;
                                    break;

                                case 'N':
                                    l = 3;
                                    break;

                                case 'P':
                                    l = 4;
                                    break;

                                default:
                                    return null;
                            }

                            /* Escolhendo a produção a ser aplicada pela tabela sintática */
                            int nProd = M[l, c];
                            /* Fazendo equivalência entre a produção e ordem inversa e o
                            seu número da tabela */
                            switch (nProd) {
                                case 1:
                                    prod = "FM";
                                    break;

                                case 2:
                                    prod = "FM+";
                                    break;

                                case 3:
                                    prod = "&";
                                    break;

                                case 4:
                                    prod = "NP";
                                    break;

                                case 5:
                                    prod = "NP*";
                                    break;

                                case 6:
                                    prod = "&";
                                    break;

                                case 7:
                                    prod = ")E(";
                                    break;

                                case 8:
                                    prod = "v";
                                    break;

                                default:
                                    return null;
                            }
                            /*Aplicando a produção que leva para a string vazia*/
                            if (prod[0] == '&') {
                                var paiTemp = pilha.Pop().ToString();
                                foreach (var no in listaNos) {
                                    if (no.Value == paiTemp && no.Children.Count == 0) {
                                        listaNos.Add(no.AddChild("&"));
                                        break;
                                    }
                                }
                            }
                            /* Aplicando outros tipos de produções */
                            else {
                                string filhos = String.Empty;
                                var paiTemp = pilha.Pop().ToString();//Pai
                                for (int j = 0; j != prod.Length; j++) {
                                    pilha.Push(prod[j]);//Filhos
                                    filhos = filhos + prod[j].ToString();
                                }
                                //BEM AQUI PRECISA DE FOREACH
                                foreach (var no in listaNos) {
                                    if (no.Value == paiTemp && no.Children.Count == 0) {
                                        foreach (var filho in filhos.Reverse()) {
                                            listaTemp.Add(no.AddChild(filho.ToString()));
                                        }
                                        break;
                                    }
                                }
                                listaNos.AddRange(listaTemp);
                                listaTemp.Clear();
                            }
                            /* Verificando se há igualdade no topo da pilha e o caractere em analise*/
                            if (pilha.Peek().ToString()[0] == str[i]) {
                                /*Reconhecimento da sentença*/
                                if (pilha.Peek().ToString()[0] == '$') {
                                    return noArvore;
                                }
                                /* Mudança de estado do autômato */
                                else {
                                    pilha.Pop();
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return null;

        }

    }
}

//TODO: Visualização da árvore e adicionar sintaxe para código inteiro