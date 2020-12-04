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
        private List<TreeNode> listaArvoresProntas;
        private List<TreeNode> listaArvoresFracas;

        public Sintaxe(DataTable table) {
            tabela = table;
        }

        private List<TreeNode> FormatarArvore() {
            //Cronstruir Árvore
            List<TreeNode> listaNodes = new List<TreeNode>();
            TreeNode<string> noPre;
            TreeNode noL = new TreeNode();
            foreach (var no in listaNos) {
                listaNodes.Add(new TreeNode(no.Value));
            }

            for (int i = 0; i < listaNos.Count; i++) {
                noPre = listaNos[i];
                noL = listaNodes[i];

                foreach (var children in noPre.Children) {
                    for (int j = i; j < listaNodes.Count; j++) {
                        if (children.Value == listaNodes[j].Text && listaNodes[j].Parent == null) {
                            noL.Nodes.Add(listaNodes[j]);
                            break;
                        }
                    }
                }

            }

            listaArvoresProntas.Add(listaNodes[0]);
            //Limpar listas
            listaNos.Clear();

            return listaArvoresProntas;
        }

        public List<TreeNode> AnalisadorPreditivo() {
            List<string> listaRotulo = new List<string>();
            string linhaLexica = String.Empty;
            listaArvoresProntas = new List<TreeNode>();
            int linhaAtual = 0;

            foreach (System.Data.DataRow linha in tabela.Rows) {
                //ID INT FLOAT mudar para v
                if (linha["Rótulo"].ToString() == "ID" || linha["Rótulo"].ToString() == "INT"
                    || linha["Rótulo"].ToString() == "FLOAT") {
                    linhaLexica = linhaLexica + "v";
                    listaRotulo.Add(linha["Rótulo"].ToString());
                }
                else {
                    linhaLexica = linhaLexica + linha["Rótulo"];
                    listaRotulo.Add(linha["Rótulo"].ToString());
                }
                if (linha["Lexema"].ToString() == ";") {
                    linhaAtual++;
                    linhaLexica = linhaLexica.Replace(";", "$S");

                    for (int i = 0; i < listaRotulo.Count() - 1; i++) {
                        if (listaRotulo[i] == "=") {
                            if (listaRotulo[i - 1] == "ID") {
                                try {
                                    if (listaRotulo[i - 2] == "PR" && i - 2 == 0)
                                        linhaLexica = linhaLexica.Substring(linhaLexica.IndexOf('=') + 1);
                                    else {
                                        MessageBox.Show("Sentença não reconhecida, verifique a sintaxe correta para atribuição na linha " + linhaAtual.ToString());
                                        return listaArvoresProntas;
                                    }
                                }
                                catch (Exception) {
                                    linhaLexica = linhaLexica.Substring(linhaLexica.IndexOf('=') + 1);
                                }

                            }
                            else {
                                MessageBox.Show("Sentença não reconhecida, verifique a sintaxe correta para atribuição na linha " + linhaAtual.ToString());
                                return listaArvoresProntas;
                            }

                        }
                    }

                    var arvorePre = SomaMultiParen(linhaLexica);
                    if (arvorePre == null) {
                        MessageBox.Show("Sentença não reconhecida, verifique a linha " + linhaAtual.ToString());
                        return listaArvoresProntas;
                    }
                    FormatarArvore();
                    linhaLexica = String.Empty;
                    listaRotulo.Clear();
                }
            }

            //Inicia aqui
            return listaArvoresProntas;

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

        private TreeNode<string> SomaMultiParen(string linhaLexica) {
            List<TreeNode> arvoreValores = new List<TreeNode>();
            listaNos = new List<TreeNode<string>>();
            List<TreeNode<string>> listaTemp = new List<TreeNode<string>>();
            TreeNode<string> noArvore = new TreeNode<string>("E");//Raiz
            listaNos.Add(noArvore);
            Stack pilha = new Stack();

            //As palavras estão sem espaços, para mudar isso é só adicionar um " " na atribuição da linhaLexica
            string str = linhaLexica;//Essa string deve receber a setença e colocar $ no final

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
                                foreach (var filho in filhos) {
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

            return null;

        }

        public List<TreeNode> AnalisadorPrecedênciaFraca() {
            List<string> valores = new List<string>();
            List<string> listaRotulo = new List<string>();
            string linhaLexica = String.Empty;
            listaArvoresFracas = new List<TreeNode>();
            int linhaAtual = 0;

            foreach (System.Data.DataRow linha in tabela.Rows) {
                //ID INT FLOAT mudar para v
                if (linha["Rótulo"].ToString() == "ID" || linha["Rótulo"].ToString() == "INT"
                    || linha["Rótulo"].ToString() == "FLOAT") {
                    linhaLexica = linhaLexica + "v";
                    listaRotulo.Add(linha["Rótulo"].ToString());
                    valores.Add(linha["Lexema"].ToString());
                }
                else {
                    linhaLexica = linhaLexica + linha["Rótulo"];
                    listaRotulo.Add(linha["Rótulo"].ToString());
                    valores.Add(linha["Lexema"].ToString());
                }

                if (linha["Lexema"].ToString() == ";" || linha["Lexema"].ToString() == "{" || linha["Lexema"].ToString() == "}") {
                    linhaAtual++;
                    linhaLexica = linhaLexica.Replace(";", "$");

                    for (int i = 0; i < listaRotulo.Count() - 1; i++) {
                        if (listaRotulo[i] == "=") {
                            if (listaRotulo[i - 1] == "ID") {
                                try {
                                    if (listaRotulo[i - 2] == "PR" && i - 2 == 0) { //Mudar PR para INT/FLOAT/DOUBLE
                                        valores.RemoveRange(0, linhaLexica.IndexOf('='));
                                        linhaLexica = linhaLexica.Substring(linhaLexica.IndexOf('=') + 1);
                                    }
                                    else {
                                        MessageBox.Show("Sentença não reconhecida, verifique a sintaxe correta para atribuição na linha " + linhaAtual.ToString());
                                        return listaArvoresFracas;
                                    }
                                }
                                catch (Exception) {
                                    valores.RemoveRange(0, linhaLexica.IndexOf('=') + 1);
                                    linhaLexica = linhaLexica.Substring(linhaLexica.IndexOf('=') + 1);
                                }

                            }
                            else {
                                MessageBox.Show("Sentença não reconhecida, verifique a sintaxe correta para atribuição na linha " + linhaAtual.ToString());
                                return listaArvoresFracas;
                            }

                        }
                    }

                    var arvoreFraca = PrecedênciaSMParen(linhaLexica, valores);
                    if (arvoreFraca == null && !linhaLexica.Contains("PRIDFUNC(){") && linhaLexica != "PRv$" && linhaLexica != "}") {//O && não adiciona
                        MessageBox.Show("Sentença não reconhecida, verifique a linha " + linhaAtual.ToString());
                        return listaArvoresFracas;
                    }
                    else {
                        listaArvoresFracas.Add(arvoreFraca);
                    }
                    linhaLexica = String.Empty;
                    listaRotulo.Clear();
                    valores.Clear();
                }
            }

            return listaArvoresFracas;
        }

        private TreeNode PrecedênciaSMParen(string linhaLexica, List<string> valores) {
            TreeNode noArvore = null;
            Stack pilha = new Stack();
            Stack<TreeNode> pilhaNos = new Stack<TreeNode>();
            List<TreeNode> listaFilhos = new List<TreeNode>();

            string str = linhaLexica;//Essa string deve receber a sentença e colocar $ no final

            /* Declarando a tabela sintática para o automato M */
            int[,] M = new int[9, 6]{
                        {1, 9, 9, 1, 9, 9},
                        {2, 1, 9, 2, 9, 2},
                        {2, 2, 9, 2, 9, 2},
                        {9, 9, 1, 9, 1, 9},
                        {9, 9, 1, 9, 1, 9},
                        {9, 9, 1, 9, 1, 9},
                        {2, 2, 9, 2, 9, 2},
                        {2, 2, 9, 2, 9, 2},
                        {9, 9, 1, 9, 1, 9}
                    };

            /*Declarando matriz de produções*/
            string[,] producoes = new string[6, 2] {
                {"E", "M+E" },
                {"E", "M" },
                {"M", "P*M" },
                {"M", "P" },
                {"P", ")E(" },
                {"P", "v" }
            };

            /* Colocando o simbolo delimitador na pilha*/
            pilha.Push('$');

            /* Receberá a indexação referente ao matriz*/
            int c;
            int l;
            int i;
            /* Receberá as produções*/
            string prod;
            /* Percorrendo toda a sentenca de avaliacao*/
            for (i = 0; str.Length != i; i++) {
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

                        case 'M':
                            l = 1;
                            break;

                        case 'P':
                            l = 2;
                            break;

                        case '+':
                            l = 3;
                            break;

                        case '*':
                            l = 4;
                            break;

                        case '(':
                            l = 5;
                            break;

                        case ')':
                            l = 6;
                            break;

                        case 'v':
                            l = 7;
                            break;

                        case '$':
                            l = 8;
                            break;

                        default:
                            return null;
                    }

                    /* Escolhendo a produção a ser aplicada pela tabela sintática */
                    int nProd = M[l, c];
                    /* Tratando os dois casos Redução-Deslocamento*/
                    switch (nProd) {
                        case 1: //Deslocamento
                            prod = "Deslocamento";
                            break;

                        case 2: //Redução
                            Stack pilhaTemp = new Stack();
                            pilhaTemp = (Stack)pilha.Clone();
                            List<string> listaProd = new List<string>();
                            var topo = pilhaTemp.Pop().ToString();
                            for (int j = 0; j < 6; j++) {
                                if (producoes[j, 1].Contains(topo)) {
                                    listaProd.Add(producoes[j, 1]);
                                }
                            }
                            if (listaProd.Count == 1) {
                                prod = listaProd[0];
                            }
                            else {
                                int maior = 0;
                                prod = topo;
                                List<string> listaPilha = new List<string>();
                                while (pilhaTemp.Count > 0) {
                                    listaPilha.Add(pilhaTemp.Pop().ToString());
                                }

                                foreach (var produ in listaProd) {
                                    int o = 1;
                                    for (o = 1; o < produ.Length; o++) {
                                        if (produ[o].ToString() == listaPilha[o - 1]) {
                                        }
                                        else {
                                            break;
                                        }

                                    }
                                    if (o == produ.Length) {
                                        if (maior < o) {
                                            maior = o;
                                            prod = produ;
                                        }
                                    }
                                }

                            }
                            break;

                        default:
                            return null;
                    }
                    /*Empilha char da lista de tokens */
                    if (prod == "Deslocamento") {
                        pilha.Push(str[i]);
                        var novoPai = new TreeNode(str[i].ToString());
                        novoPai.Name = valores[i];
                        noArvore = novoPai;
                        pilhaNos.Push(noArvore);
                    }
                    /* Aplicar produção de redução */
                    else {
                        foreach (var caracter in prod) {
                            pilha.Pop();
                            listaFilhos.Add(pilhaNos.Pop());
                        }

                        for (int j = 0; j < 6; j++) {
                            if (producoes[j, 1] == prod) {
                                pilha.Push(producoes[j, 0][0]);
                                var novoNo = new TreeNode(producoes[j, 0]);
                                novoNo.Name = valores[i];
                                pilhaNos.Push(novoNo);
                                break;
                            }
                        }
                        foreach (var filho in listaFilhos) {
                            pilhaNos.Peek().Nodes.Add(filho);
                        }
                        listaFilhos.Clear();

                    }
                    /* Verificando se há igualdade no topo da pilha e o caractere em analise*/
                    if (pilha.Peek().ToString()[0] == 'E') {
                        /*Reconhecimento da sentença*/
                        if (str[i] == '$') {
                            return pilhaNos.Peek();
                        }

                    }
                    else if (prod == "Deslocamento")
                        break;
                }

            }

            return noArvore;
        }

    }
}