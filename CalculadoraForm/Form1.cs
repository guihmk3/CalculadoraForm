using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraForm
{
    public partial class Form1 : Form
    {
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
            // adicionar o text no texbox
            txbtela.Text = butaoClicado.Text;
        }
    }
}
