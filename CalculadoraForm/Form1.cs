using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraForm
{
    using System;
    using System.Windows.Forms;
    public partial class Form1 : Form
    {
        //variaveis globais
        bool operadorClicado = true;
        bool resultadoMostrado = false; // para quando eu calcular ele saber que o ultimo btn foi =


        public Form1()
        {
            InitializeComponent();
        }

        private void btnigual_Click(object sender, EventArgs e)
        {
        
            try
            {
                string expressao = txbtela.Text;

                // valida divisão por zero
                if (expressao.Contains("/0"))
                {
                    MessageBox.Show("Não é possível dividir por zero!");
                    return;
                }

                var resultado = new System.Data.DataTable().Compute(expressao, null);

                txbtela.Text = resultado.ToString();
                operadorClicado = false;
                resultadoMostrado = true;
            }
            catch
            {
                MessageBox.Show("Expressão inválida!");
            }
        }

        private void numero_Click(object sender, EventArgs e)
        {
            Button botaoClicado = sender as Button;
            if (botaoClicado == null) return;

            // Se o último passo foi "=", limpamos antes de digitar o novo número
            if (resultadoMostrado)
            {
                txbtela.Text = "";
                resultadoMostrado = false;
            }

            // adiciona o número normalmente
            txbtela.Text += botaoClicado.Text;

            // marca que o último clicado foi número
            operadorClicado = false;
        }
        private void operadorClick(object sender, EventArgs e)

        // verificar se o operaddor ainda não foi clicado
        {
            Button botaoClicado = sender as Button;
            if (botaoClicado == null) return;

            // Se o último mostrado foi resultado, não vamos limpar.
            // Apenas permitimos continuar a conta normalmente.
            if (resultadoMostrado)
            {
                resultadoMostrado = false; // resetamos a flag
            }

            if (operadorClicado == false)
            {
                txbtela.Text += botaoClicado.Text;
                operadorClicado = true;
            }
            else
            {
                // Se já tinha um operador e o usuário quer trocar (+ para - por exemplo)
                string tela = txbtela.Text;
                if (tela.Length > 0)
                {
                    txbtela.Text = tela.Substring(0, tela.Length - 1) + botaoClicado.Text;
                }
            }
        }
        
        private void btnlimpar_Click(object sender, EventArgs e)
        {
            //limpar tela
            txbtela.Text = "";
            //Voltar o operador clicado para true:
            operadorClicado = true;
            resultadoMostrado = false;
        }
        // Verifica se um caractere é operador

        private bool EhOperador(char c) => c == '+' || c == '-' || c == '*' || c == '/';

        // Adiciona ou troca operador no final do texto
        private void AdicionarOuTrocarOperador(string op)
        {
            if (string.IsNullOrEmpty(txbtela.Text)) return; // não deixa começar com operador

            char ultimo = txbtela.Text[txbtela.Text.Length - 1];  // pega último caractere digitado

            if (EhOperador(ultimo))
            {
                // se já tem operador, troca pelo novo
                txbtela.Text = txbtela.Text.Substring(0, txbtela.Text.Length - 1) + op;
            }
            else
            {
                // senão, adiciona normalmente
                txbtela.Text += op;
            }

            operadorClicado = true; // marca que o último foi operador
        }


    }
}
