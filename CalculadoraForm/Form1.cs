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
    public partial class Form1 : Form
    {
        //variaveis globais
        bool operadorClicado = true;


        public Form1()
        {
            InitializeComponent();
        }

        private void btnigual_Click(object sender, EventArgs e)
        {
            // implementar depois...
        }

        private void numero_Click(object sender, EventArgs e)
        { 

        // obter o botão que está chamando este evento:
        Button butaoClicado = (Button)sender;

            // adicionar o text do botao clicado no texbox(tela da calculadora)
            txbtela.Text += butaoClicado.Text;

            // abaixar a bandeirinha
            operadorClicado=false;
            
        }
        private void operadorClick(object sender, EventArgs e) 
        {
            // verificar se o operaddor ainda não foi clicado
            if (operadorClicado == false)
            {
                // obter o botão que está chamando este evento
                Button botaoclicado = (Button)sender;

                // adicionar  o text do botão clicado no text box
                txbtela.Text = botaoclicado.Text;

                // mudar operadorClicado para true:
                operadorClicado=true;
            }


        }
    }
}
