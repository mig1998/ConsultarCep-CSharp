using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsultarCeps
{
    public partial class FrmConsultarCEPS : Form
    {
        public FrmConsultarCEPS()
        {
            //link do services do correios
            //https://apps.correios.com.br/SigepMasterJPA/AtendeClienteService/AtendeCliente?wsdl

            InitializeComponent();
        }

        private void FrmConsultarCEPS_Load(object sender, EventArgs e)
        {
//
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCep.Text))
            {
                using (var ws = new WSCorreios.AtendeClienteClient())
                {
                    try
                    {
                        var endereco = ws.consultaCEP(txtCep.Text.Trim());

                        txtEstado.Text = endereco.uf;
                        txtCidade.Text = endereco.cidade;
                        txtRua.Text = endereco.end;
                        txtBairro.Text = endereco.bairro;
                        

                    }



                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }
            }
            else
            {
                MessageBox.Show("informe um cep valido...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtCep.Text = string.Empty;
            txtEstado.Text = string.Empty;
            txtBairro.Text = string.Empty;
            txtCidade.Text = string.Empty;
            txtRua.Text = string.Empty;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
