﻿using CadMedalhas.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadMedalhas
{
    public partial class Form2 : Form
    {
        //atributo
        Form1 form1;

        public Form2(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            limparTela();
        }

        private void limparTela()
        {
            txtCodigo.Clear();
            txtNome.Clear();
            txtModalidade.Clear();
            txtNacionalidade.Clear();
        }
        private bool verificarTela()
        {
            bool resposta = true;
            if(txtNome.Text.Trim().Length == 0)
            {
                MessageBox.Show("Campo nome em branco. Verifique!",
                                "Nome aplicação",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                resposta = false;
            }

            if(txtModalidade.Text.Trim().Length == 0 && resposta)
            {
                MessageBox.Show("Campo modalide em branco. Verifique!",
                                "Nome aplicação",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                resposta = false;
            }

            if(txtNacionalidade.Text.Trim().Length == 0 && resposta)
            {
                MessageBox.Show("Campo nacionalidade em branco. Verifique!",
                                "Nome aplicação",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                resposta = false;                
            }
            return resposta;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            limparTela();
            txtCodigo.Text = "0";
            txtNome.Focus();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (verificarTela())
            {
                Atleta atleta = new Atleta();
                atleta.Codigo = int.Parse(txtCodigo.Text);
                atleta.Nome = txtNome.Text.Trim().ToUpper();
                atleta.Modalidade = txtModalidade.Text.Trim().ToUpper();
                atleta.Nacionalidade = txtNacionalidade.Text.Trim().ToUpper();
                if (atleta.Gravar(form1.conexaoBD))
                {
                    MessageBox.Show("Dados gravados com sucesso!",
                                "Nome aplicação",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                    limparTela();
                }
                else
                {
                    MessageBox.Show("Dados não gravados!",
                                "Nome aplicação",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                }
            }
        }
    }
}
