using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA
{
    public partial class ListaCarro : Form
    {
        string nomeAntigo = string.Empty;
        List<Carro> carros = new List<Carro>();

        public ListaCarro()
        {
            InitializeComponent();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Carro carro = new Carro()
                { 
                Nome = txtNome.Text,
                Marca = txtMarca.Text,
                AnoFabricação = Convert.ToInt16(txtAno.Text),
                Valor = Convert.ToDecimal(txtValor.Text)
                };
                if (nomeAntigo == "")
                {
                    carros.Add(carro);
                    AdicionarCarroATabela(carro);
                }
                MessageBox.Show("Cadastrado com Sucesso");
                tabControl1.SelectedIndex = 0;
            }
            catch (Exception El)
            {
                MessageBox.Show("El.Message");
            }
        }

        private void AdicionarCarroATabela(Carro carro)
        {
            dataGridView1.Rows.Add(new Object[]
                {
                    carro.Nome, carro.Marca, carro.AnoFabricação, carro.Valor
                });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            txtNome.Text = "";
            txtMarca.Text = "";
            txtAno.Text = "";
            txtValor.Text = "";
        }

        private void EditarCarroNaTabela(Carro carro, int linha)
        {
            dataGridView1.Rows[linha].Cells[0].Value = carro.Nome;
            dataGridView1.Rows[linha].Cells[0].Value = carro.Marca;
            dataGridView1.Rows[linha].Cells[0].Value = carro.AnoFabricação;
            dataGridView1.Rows[linha].Cells[0].Value = carro.Valor;





















        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Cadastre um Carro");
                return;

            }
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Selecione uma Linha");
                return;
            }

            int linhaSelecionada = dataGridView1.CurrentRow.Index;
            string nome = dataGridView1.Rows[linhaSelecionada].Cells[0].Value.ToString();
            for (int i = 0; i < carros.Count(); i++)
            {
                Carro carro = carros[i];
                if (carro.Nome == nome)
                {
                    carros.RemoveAt(i);
                }
            }

            dataGridView1.Rows.RemoveAt(linhaSelecionada);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int linhaSelecionada = dataGridView1.CurrentRow.Index;
            string nome = dataGridView1.Rows[linhaSelecionada].Cells[0].Value.ToString();
            foreach (Carro carro in carros)
            {
                txtNome.Text = carro.Nome;
                txtMarca.Text = Convert.ToString(carro.AnoFabricação);
                txtAno.Text = Convert.ToString(carro.Valor);
                txtValor.Text = Convert.ToString(carro.Valor);
                nomeAntigo = carro.Nome;
                tabControl1.SelectedIndex = 1;
                break;
                int linha = carros.FindIndex(x => x.Nome == nomeAntigo);
                carros[linha] = carro;
                EditarCarroNaTabela(carro, linha);
                MessageBox.Show("Alterado com Sucesso");
                nomeAntigo = string.Empty;
            }

        }
    }
}
