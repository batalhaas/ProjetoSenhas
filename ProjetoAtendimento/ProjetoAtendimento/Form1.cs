using System;
using System.Linq;
using System.Windows.Forms;

namespace ProjetoAtendimento
{
    public partial class Form1 : Form
    {
        private Senhas senhas;
        private Guiches guiches;

        public Form1()
        {
            InitializeComponent();
            senhas = new Senhas();
            guiches = new Guiches();
            AtualizarQtdGuiches();
        }

        // Evento do Botão Gerar Senha
        private void btnGerar_Click(object sender, EventArgs e)
        {
            senhas.Gerar();
            MessageBox.Show($"Senha {senhas.ProximoAtendimento - 1} gerada com sucesso!", "Senha Gerada", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Evento do Botão Adicionar Guichê
        private void btnAdicionarGuiche_Click(object sender, EventArgs e)
        {
            int novoId = guiches.ListaGuiches.Count + 1;
            Guiche novoGuiche = new Guiche(novoId);
            guiches.Adicionar(novoGuiche);
            AtualizarQtdGuiches();
            MessageBox.Show($"Guichê {novoId} cadastrado!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Evento do Botão Chamar Próxima Senha
        private void btnChamar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtGuicheId.Text, out int idGuiche) || idGuiche <= 0)
            {
                MessageBox.Show("Informe um ID de guichê válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Guiche guicheEncontrado = guiches.ListaGuiches.FirstOrDefault(g => g.Id == idGuiche);

            if (guicheEncontrado == null)
            {
                MessageBox.Show("Guichê não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool sucesso = guicheEncontrado.Chamar(senhas.FilaSenhas);

            if (sucesso)
            {
                Senha chamada = guicheEncontrado.Atendimentos.LastOrDefault();
                MessageBox.Show($"Guichê {idGuiche} chamou a Senha {chamada?.Id}!", "Atendimento", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Não há senhas aguardando atendimento na fila.", "Fila Vazia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        // Evento do Botão Listar Senhas Geradas (Aguardando)
        private void btnListarSenhas_Click(object sender, EventArgs e)
        {
            lstSenhas.Items.Clear();
            foreach (Senha s in senhas.FilaSenhas)
            {
                lstSenhas.Items.Add(s.DadosParciais());
            }
        }

        // Evento do Botão Listar Atendimentos por Guichê
        private void btnListarAtendimentos_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtGuicheId.Text, out int idGuiche) || idGuiche <= 0)
            {
                MessageBox.Show("Informe o ID do guichê para listar seus atendimentos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Guiche guicheEncontrado = guiches.ListaGuiches.FirstOrDefault(g => g.Id == idGuiche);

            if (guicheEncontrado == null)
            {
                MessageBox.Show("Guichê não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lstAtendimentos.Items.Clear();
            foreach (Senha s in guicheEncontrado.Atendimentos)
            {
                lstAtendimentos.Items.Add(s.DadosCompletos());
            }
        }

        private void AtualizarQtdGuiches()
        {
            lblQtdGuiches.Text = $"Guichês Cadastrados: {guiches.ListaGuiches.Count}";
        }
    }
}