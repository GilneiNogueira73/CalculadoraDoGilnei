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
        double resultado;                //indicador do resultado da operacao
        string operacao;                 //indicador da operação
        bool inserir_valor;              //necessário inserir valor
        string primeironum, segundonum;  //utilizados no histórico
        bool negativo, historico;        //utilizado no botão "Mostrar/Ocultar Histórico"

        public Form1()
        {
            InitializeComponent();
            lblMostraOps.Text = "";
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

        private void operacao_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (resultado != 0)
            {
                btnIgual.PerformClick();
                inserir_valor = true;
                operacao = b.Text;
                lblMostraOps.Text = resultado + " " + operacao;
            }
            else
            {
                operacao = b.Text;
                if (txtDisplay.Text != "")
                {
                    resultado = Double.Parse(txtDisplay.Text);
                    inserir_valor = true;
                    lblMostraOps.Text = resultado + " " + operacao;
                    txtDisplay.Text = "";
                }
            }

            primeironum = lblMostraOps.Text;
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            segundonum = txtDisplay.Text;
            lblMostraOps.Text = "";

            if (txtDisplay.Text == "") return;
            
            switch(operacao)
            {
                case "+":
                    txtDisplay.Text = (resultado + Double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "-":
                    txtDisplay.Text = (resultado - Double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "*":
                    txtDisplay.Text = (resultado * Double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "/":
                    if (operacao == "/" && txtDisplay.Text == "0")
                    {
                        MessageBox.Show("Não é possível realizar divisão por 0");
                        btnC.PerformClick();
                        return;
                    }
                    txtDisplay.Text = (resultado / Double.Parse(txtDisplay.Text)).ToString();
                    break;
                default:
                    break;
            }
            
            resultado = Double.Parse(txtDisplay.Text);
            operacao = "";

            btnLimparHistorico.Visible = true;
            if (primeironum is null && segundonum != null) return;
            
            rtbMostraHistorico.AppendText(primeironum + "   " + segundonum + " = " + "\n");
            rtbMostraHistorico.AppendText("\n\t" + txtDisplay.Text + "\n\n");
            primeironum = null;
            segundonum = null;
            inserir_valor = true;
            if (double.Parse(txtDisplay.Text) < 0)
            {
                negativo = true;
            }
        }

        private void btnCe_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            resultado = 0;
            lblMostraOps.Text = "";
        }

        private void btnLimparHistorico_Click(object sender, EventArgs e)
        {
            rtbMostraHistorico.Clear();
            btnLimparHistorico.Visible = false;
            rtbMostraHistorico.ScrollBars = 0;
        }

        private void btnNegPos_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text != "" && txtDisplay.Text != "0")
            {
                if (txtDisplay.Text.Contains("-"))
                {
                    if (negativo == true)
                    {
                        txtDisplay.Text = txtDisplay.Text.Remove(0, 1);
                        negativo = false;
                        return;
                    }
                }
                txtDisplay.Text = "-" + txtDisplay.Text;
                negativo = true;
            }
        }

        private void btnMostrarHistorico_Click(object sender, EventArgs e)
        {
            if (historico == true)
            {
                this.ClientSize = new System.Drawing.Size(420, 690);
                historico = false;
            }
            else
            {
                this.ClientSize = new System.Drawing.Size(789, 690);
                historico = true;
            }
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text.Length > 0)
            {
                txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1, 1);
            }

            if (txtDisplay.Text == "")
            {
                txtDisplay.Text = "0";
            }
        }

    }
}
