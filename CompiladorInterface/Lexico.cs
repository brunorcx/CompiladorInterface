using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;

namespace CompiladorInterface {

    public class Lexico {
        private static List<string> pReservadas;
        private static List<string> operadores;
        private static List<string> cEspeciais;

        // Palavras reservadas(keyword) #########################

        private string k_auto = "auto";
        private string k_double = "double";
        private string k_int = "int";
        private string k_struct = "struct";
        private string k_break = "break";
        private string k_else = "else";
        private string k_long = "long";
        private string k_switch = "switch";
        private string k_case = "case";
        private string k_enum = "enum";
        private string k_register = "register";
        private string k_typedef = "typedef";
        private string k_char = "char";
        private string k_extern = "extern";
        private string k_return = "return";
        private string k_union = "union";
        private string k_const = "const";
        private string k_short = "short";
        private string k_float = "float";
        private string k_unsigned = "unsigned";
        private string k_continue = "continue";
        private string k_for = "for";
        private string k_signed = "signed";
        private string k_void = "void";
        private string k_default = "default";
        private string k_goto = "goto";
        private string k_sizeof = "sizeof";
        private string k_volatile = "volatile";
        private string k_do = "do";
        private string k_if = "if";
        private string k_static = "static";
        private string k_while = "while";

        //Operadores #########################

        //Aritmética
        private string o_plus = "+";      //Adds two operands.A + B = 30

        private string o_minus = "-";     //Subtracts second operand from the first.A − B = -10
        private string o_multiply = "*";  //Multiplies both operands.	A* B = 200
        private string o_divide = "/";    //Divides numerator by de-numerator.B / A = 2
        private string o_percentage = "%";//Modulus Operator and remainder of after an integer division.	B % A = 0
        private string o_plusPlus = "++";  //Increment operator increases the integer value by one.	A++ = 11
        private string o_minusMinus = "--";//Decrement operator decreases the integer value by one.	A-- = 9

        //Relacional
        private string o_equalEqual = "==";//Checks if the values of two operands are equal or not.If yes, then the condition becomes true.	(A == B) is not true.

        private string o_notEqual = "!=";  //Checks if the values of two operands are equal or not.If the values are not equal, then the condition becomes true.	(A != B) is true.
        private string o_Gt = ">";        //Checks if the value of left operand is greater than the value of right operand.If yes, then the condition becomes true.	(A > B) is not true.
        private string o_Lt = "<";        //Checks if the value of left operand is less than the value of right operand.If yes, then the condition becomes true.	(A<B) is true.
        private string o_Gte = ">=";       //Checks if the value of left operand is greater than or equal to the value of right operand.If yes, then the condition becomes true.	(A >= B) is not true.
        private string o_lte = "<=";       //Checks if the value of left operand is less than or equal to the value of right operand.If yes, then the condition becomes true.	(A <= B) is true.

        //Lógico
        private string o_andAnd = "&&";    //Called Logical AND operator. If both the operands are non-zero, then the condition becomes true.	(A && B) is false.

        private string o_orOr = "||";      //Called Logical OR Operator.If any of the two operands is non-zero, then the condition becomes true.	(A || B) is true.
        private string o_not = "!";       //Called Logical NOT Operator.It is used to reverse the logical state of its operand.If a condition is true, then Logical NOT operator will make it false.	!(A && B) is true.

        //Atribuição
        private string o_equal = "=";     //Simple assignment operator. Assigns values from right side operands to left side operand    C = A + B will assign the value of A + B to C

        //Constantes #########################

        private string c_constant;

        //Caracteres especiais #########################

        private string c_comma = ",";                  // ,
        private string c_onpeningCurlyBracket = "{";   // {

        //private string c_period = ".";                 // .
        private string c_closingCurlyBracket = "}";    // }

        //private string c_semiColon = ";";              // ;
        private string c_leftBracket = "[";            // [

        private string c_colon = ":";                  // :
        private string c_rightBracket = "]";           // ]
        private string c_openingLeftParenthesis = "("; // (
        private string c_apostrophe = "'";             // '
        private string c_closingRightParenthesis = ")";// )
        private string c_doubleQuotationMark = "\"";   // "
        private string c_underscore = "_";             // _
        private string c_hash = "#";                   // #
        private string c_dollarSign = "$";             //$

        //identificadores #########################

        private string i_identifier;

        public void carregarPalavrasReservadas() {
            pReservadas = new List<string>();

            pReservadas.Add(k_auto);
            pReservadas.Add(k_double);
            pReservadas.Add(k_int);
            pReservadas.Add(k_struct);
            pReservadas.Add(k_break);
            pReservadas.Add(k_else);
            pReservadas.Add(k_long);
            pReservadas.Add(k_switch);
            pReservadas.Add(k_case);
            pReservadas.Add(k_enum);
            pReservadas.Add(k_register);
            pReservadas.Add(k_typedef);
            pReservadas.Add(k_char);
            pReservadas.Add(k_extern);
            pReservadas.Add(k_return);
            pReservadas.Add(k_union);
            pReservadas.Add(k_const);
            pReservadas.Add(k_short);
            pReservadas.Add(k_float);
            pReservadas.Add(k_unsigned);
            pReservadas.Add(k_continue);
            pReservadas.Add(k_for);
            pReservadas.Add(k_signed);
            pReservadas.Add(k_void);
            pReservadas.Add(k_default);
            pReservadas.Add(k_goto);
            pReservadas.Add(k_sizeof);
            pReservadas.Add(k_volatile);
            pReservadas.Add(k_do);
            pReservadas.Add(k_if);
            pReservadas.Add(k_static);
            pReservadas.Add(k_while);

        }

        public void carregarOperadores() {
            //Aritmética
            operadores = new List<string>();

            operadores.Add(o_plus);
            operadores.Add(o_minus);
            operadores.Add(o_multiply);
            operadores.Add(o_divide);
            operadores.Add(o_percentage);
            operadores.Add(o_plusPlus);
            operadores.Add(o_minusMinus);

            //Relacional
            operadores.Add(o_equalEqual);

            operadores.Add(o_notEqual);
            operadores.Add(o_Gt);
            operadores.Add(o_Lt);
            operadores.Add(o_Gte);
            operadores.Add(o_lte);

            //Lógico
            operadores.Add(o_andAnd);
            operadores.Add(o_orOr);
            operadores.Add(o_not);

            //Atribuição
            operadores.Add(o_equal);
        }

        public void carregarCaracteresEspeciais() {
            cEspeciais = new List<string>();

            cEspeciais.Add(c_apostrophe);
            cEspeciais.Add(c_closingCurlyBracket);
            cEspeciais.Add(c_closingRightParenthesis);
            cEspeciais.Add(c_colon);
            cEspeciais.Add(c_comma);
            cEspeciais.Add(c_doubleQuotationMark);
            cEspeciais.Add(c_hash);
            cEspeciais.Add(c_leftBracket);
            cEspeciais.Add(c_onpeningCurlyBracket);
            cEspeciais.Add(c_openingLeftParenthesis);
            // cEspeciais.Add(c_period);
            cEspeciais.Add(c_rightBracket);
            //cEspeciais.Add(c_semiColon);
            cEspeciais.Add(c_underscore);
            cEspeciais.Add(c_dollarSign);

        }

        public List<string> lerArquivo() {
            int numLinha = 0;
            string line;
            List<string> listaLinhas = new List<string>();
            //Read the file and display it line by line.
            var path = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Codigo.txt");
            System.IO.StreamReader file;
            file = new System.IO.StreamReader(path);
            while ((line = file.ReadLine()) != null) {
                if (!string.IsNullOrWhiteSpace(line)) {
                    numLinha++;
                    // System.Console.WriteLine(line);
                    listaLinhas.Add(line);
                }

            }
            file.Close();
            return listaLinhas;

        }

        public DataTable separarLexemas(List<string> listaLinhas) {
            DataTable tabela = new DataTable("Lexemas");
            DataRow workRow;
            int cont = 0;
            carregarPalavrasReservadas();
            carregarOperadores();
            carregarCaracteresEspeciais();

            int inicial = 0;

            string sTemp;
            //Definir esquema da tabela ############
            tabela.Columns.Add("Lexema", typeof(String));
            tabela.Columns.Add("Rótulo", typeof(String));

            DataColumn workCol = tabela.Columns.Add("COD", typeof(Int32));
            workCol.AllowDBNull = false;
            workCol.Unique = true;
            //workCol.AutoIncrement = true;
            workCol.AutoIncrementSeed = 0; // valor inicial
            workCol.AutoIncrementStep = 1;// valor incrimentado a cada inserção
                                          //workCol.Unique = true;
                                          // Fim esquema de tabela ############

            //Adicionar nova linha

            //COMECEI AQUI ####################
            foreach (var linha in listaLinhas) {
                string lexema = String.Empty;
                for (int i = 0; i < linha.Length; i++) {
                    lexema = lexema + linha[i];
                    if (linha[i] == ' ' || i == linha.Length - 1 || linha[i] == ';') {//Pegar Lexema
                        if (i == linha.Length - 1 && linha[i] != ' ' && linha[i] != ';')//Corrigir \n que não é lido
                            lexema = lexema + ' ';
                        if (ReconhecerIdentificador(lexema)) {//CASO IDENTIFICADOR
                            workRow = tabela.NewRow();
                            workRow["Lexema"] = lexema.Substring(0, lexema.Length - 1);
                            workRow["Rótulo"] = "ID";
                            workRow["COD"] = cont++;
                            tabela.Rows.Add(workRow);
                        }//FIM CASO IDENTIFICADOR
                        else if (ReconhecerNumero(lexema) != "ERRO") { //CASO INT E FLOAT verificar 0.5f
                            workRow = tabela.NewRow();
                            workRow["Lexema"] = lexema.Substring(0, lexema.Length - 1);
                            workRow["Rótulo"] = ReconhecerNumero(lexema);
                            workRow["COD"] = cont++;
                            tabela.Rows.Add(workRow);
                        }
                        lexema = String.Empty;

                    }
                }
            }
            //ATÉ AQUI #######################

            /*
            foreach (string linha in listaLinhas) {
                for (int i = 0, tamanho = 0; i < linha.Length;) {
                    if (linha[i] == ' ')
                        i++;
                    else {
                        inicial = i;
                        try {
                            // CASOS COM CARACTERES ESPECIAIS SEM ESPAÇO
                            while (linha[i] != ' ' && linha[i] != ';' && !acharSimbolos(linha[i])) {
                                i++;
                                tamanho++;
                            }

                        }
                        catch (Exception) {// Faltou um ; na linha
                            string erro = "Não foi encontrado um \";\" na linha ' " + linha + " '";
                            i--;
                        }

                        //O problema do ponto está em separar um número com vírgula
                        //Assim, ponto não é adicionado aos caracteres especiais

                        if (tamanho != 0) {
                            workRow = tabela.NewRow();
                            sTemp = linha.Substring(inicial, tamanho);
                            workRow["Lexema"] = sTemp;
                            workRow["Rótulo"] = identificarRotulo(sTemp);
                            workRow["COD"] = cont++;
                            tabela.Rows.Add(workRow);
                        }
                        if (linha[i] == ';') {
                            workRow = tabela.NewRow();
                            sTemp = linha.Substring(i, 1);
                            workRow["Lexema"] = sTemp;
                            workRow["Rótulo"] = identificarRotulo(sTemp);
                            workRow["COD"] = cont++;
                            tabela.Rows.Add(workRow);
                        }
                        if (acharSimbolos(linha[i])) {
                            workRow = tabela.NewRow();
                            sTemp = linha.Substring(i, 1);
                            workRow["Lexema"] = sTemp;
                            workRow["Rótulo"] = identificarRotulo(sTemp);
                            workRow["COD"] = cont++;
                            tabela.Rows.Add(workRow);
                        }
                        i++;
                        tamanho = 0;
                    }
                }

            }
            */
            DataRow[] rows = tabela.Select();
            Console.Write("\tLexema");
            Console.Write("\tRótulo");
            Console.Write("\tCOD\n");

            for (int i = 0; i < rows.Length; i++) {
                Console.Write("\t" + rows[i]["Lexema"]);
                Console.Write("\t" + rows[i]["Rótulo"]);
                Console.Write("\t" + rows[i]["COD"]);
                Console.WriteLine();
            }
            return tabela;
        }

        private string identificarRotulo(string lexema) {
            foreach (string palavra in pReservadas) {
                if (lexema == palavra)
                    return "PR";//Palavra Reservada
            }
            foreach (string palavra in operadores) {
                if (lexema == palavra)
                    return palavra;//retornar o operador
            }
            foreach (string palavra in cEspeciais) {
                if (lexema == palavra)
                    return palavra;//retornar o operador
            }
            if (lexema == ";")
                return "$";

            if ((lexema[0] >= 65 && lexema[0] <= 90) || (lexema[0] >= 97 && lexema[0] <= 122) || lexema[0] == 95) {
                return "ID";
            }
            return IdentificarNumeros(lexema);
            /*
            string numero = IdentificarNumeros(lexema);
            if (numero == "Float") {
                try {
                    float.Parse(lexema);
                    return numero;
                }
                catch (Exception) {
                    numero = "ERRO";
                }
            }
            return numero;
            */

        }

        private bool acharSimbolos(char simbolo) {
            foreach (string palavra in cEspeciais) {
                if (simbolo == palavra[0])
                    return true;//retornar o operador
            }
            foreach (string palavra in operadores) {
                if (simbolo == palavra[0])
                    return true;//retornar o operador
            }
            return false;
        }

        public string IdentificarNumeros(string numero) { // Mudar para private depois
            //^ é usado para dar match forçando o inicio da palavra
            // return match.Value + " Float"; para verificar o valor que deu match

            //Regex regex = new Regex(@"^[0-9]*\.[0-9]+|[0-9]+\.[0-9]*");//Float
            Regex regex = new Regex(@"^[0-9]*[.][0-9]+|[0-9]+[.][0-9]*");//Float
            Match match = regex.Match(numero);
            if (match.Success) {
                if (match.Value == numero)
                    return "Float";
                else
                    return "ERRO";
            }
            else {
                regex = new Regex(@"^[1-9][0-9]*"); //Decimal
                match = regex.Match(numero);
                if (match.Success)
                    return "Decimal";
                else {
                    regex = new Regex(@"^0x[0-9A-Fa-f]+");//Hexadecimal
                    match = regex.Match(numero);
                    if (match.Success)
                        return "Hexadecimal";
                    else {
                        regex = new Regex(@"^0[0-7]*"); //Octal
                        match = regex.Match(numero);
                        if (match.Success)
                            return "Octal";
                    }

                }
            }

            return "ERRO";
        }

        public string IdentificarCaracter(char c) {
            if ((c >= 65 && c <= 90) || (c >= 97 && c <= 122) || c == 95) {
                return "Char";
            }
            if (IdentificarNumeros(c.ToString()) != "ERRO")
                return "Numero";
            if (c == ';' || c == ' ' || c == '\n')
                return "Fim";
            if (acharSimbolos(c) || c == '.')
                return "Simbolo";

            return "ERRO";

        }

        public bool ReconhecerIdentificador(string token) {//Identificador deve iniciar com letra ou _
            //1º Linguagem
            carregarOperadores();
            carregarCaracteresEspeciais();
            //2 é o estado de aceitação e 3 o de ERRO
            int[,] m = new int[4, 4] {
              //q0, q1, q2, q3
                {1, 1, 2, 3} ,   /*  Char Linha 0  */
                {3, 1, 2, 3} ,   /*  Num Linha 1 */
                {3, 2, 2, 3},   /*  ; " " "\n" Linha  2 */
                {3, 3 , 2, 3}   /*  cEspeciais ou operadores Linha 3 */
            };
            //Estado inicial
            int estado = 0;
            int linha = 0;

            foreach (var caracter in token) {
                switch (IdentificarCaracter(caracter)) {
                    case "Char":
                        linha = 0;
                        break;

                    case "Numero":
                        linha = 1;
                        break;

                    case "Fim":
                        linha = 2;
                        break;

                    case "Simbolo":
                        linha = 3;
                        break;

                    default:
                        break;
                }

                estado = m[linha, estado];

            }

            if (estado == 2)
                return true;
            else
                return false;
        }

        public string ReconhecerNumero(string token) {//Identificador deve iniciar com letra ou _
            //1º Linguagem
            carregarOperadores();
            carregarCaracteresEspeciais();
            //2 é o estado de aceitação e 3 o de ERRO
            int[,] m = new int[4, 7] {
              //q0  q1  q2  q3  q4  q5  q6
                {2, 2,  6,  6,  4,  5,  6} ,    /*  . Linha 0  */
                {1, 1,  3,  3,  4,  5,  6} ,    /*  Num Linha 1 */
                {6, 5,  6,  4,  4,  5,  6},     /*  ; " " "\n" Linha  2 */
                {6, 6 , 6,  6,  4,  5,  6}      /*  cEspeciais ou operadores Linha 3 */
            };
            //Estado inicial
            int estado = 0;
            int linha = 0;

            foreach (var caracter in token) {
                switch (IdentificarCaracter(caracter)) {
                    case "Simbolo":
                        if (caracter == '.')
                            linha = 0;
                        else
                            linha = 3;
                        break;

                    case "Numero":
                        linha = 1;
                        break;

                    case "Fim":
                        linha = 2;
                        break;

                    default:
                        break;
                }

                estado = m[linha, estado];

            }

            if (estado == 5)
                return "INT";
            else if (estado == 4)
                return "FLOAT";
            else
                return "ERRO";
        }

    }
}

// REGEX https://www.geeksforgeeks.org/what-is-regular-expression-in-c-sharp/#:~:text=In%20C%23%2C%20Regular%20Expression%20is,that%20allows%20the%20pattern%20matching.