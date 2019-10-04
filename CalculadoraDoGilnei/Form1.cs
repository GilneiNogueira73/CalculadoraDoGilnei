using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraDoGilnei
{
    public partial class Form1 : Form
    {
        Double resultado = 0;
        String operacao = "";
        bool inserir_valor = false;
        char iOperacao;

        public Form1()
        {
            InitializeComponent();
        }

        private void txtDisplay_TextChanged(object sender, EventArgs e)
        {

        }

        private void numbers_Only(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if((txtDisplay.Text == "0") || (inserir_valor))
                txtDisplay.Text = "";
            inserir_valor = false;

            if (b.Text == ",")
            {
                if (!txtDisplay.Text.Contains(","))
                    txtDisplay.Text = txtDisplay.Text + b.Text;
            }
            else
            {
               txtDisplay.Text = txtDisplay.Text + b.Text;
            }
        }
    }
}
