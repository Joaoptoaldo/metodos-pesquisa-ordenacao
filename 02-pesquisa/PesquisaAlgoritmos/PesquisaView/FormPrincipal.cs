using PesquisaLib;

namespace PesquisaView;

public sealed class FormPrincipal : Form
{
    private readonly MetodosPesquisa metodosPesquisa = new();
    private readonly List<string> nomesCadastrados = new();

    private readonly TextBox txtNome = new();
    private readonly Button btnCadastrar = new();
    private readonly Label lblStatusCadastro = new();
    private readonly Label lblTotalCadastrados = new();

    private readonly TextBox txtPesquisa = new();
    private readonly ListBox lstResultados = new();
    private readonly Label lblStatusPesquisa = new();

    public FormPrincipal()
    {
        ConfigurarJanela();
        CriarInterface();
        ConfigurarEventos();
        AtualizarTotalCadastrados();
    }

    private void ConfigurarJanela()
    {
        Text = "Pesquisa de Nomes";
        StartPosition = FormStartPosition.CenterScreen;
        MinimumSize = new Size(680, 600);
        ClientSize = new Size(760, 680);
        Font = new Font("Segoe UI", 10F);
        BackColor = Color.FromArgb(245, 247, 250);
    }

    private void CriarInterface()
    {
        var titulo = new Label
        {
            Text = "Cadastro e pesquisa de nomes",
            Font = new Font("Segoe UI", 19F, FontStyle.Bold),
            ForeColor = Color.FromArgb(32, 44, 62),
            AutoSize = true,
            Location = new Point(22, 18)
        };

        var subtitulo = new Label
        {
            Text = "Cadastre nomes e encontre correspondências digitando apenas o início do nome.",
            ForeColor = Color.FromArgb(90, 100, 115),
            AutoSize = true,
            Location = new Point(25, 55)
        };

        var grupoCadastro = new GroupBox
        {
            Text = "1. Cadastro",
            Location = new Point(20, 88),
            Size = new Size(720, 145),
            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
        };

        var lblNome = new Label
        {
            Text = "Nome completo:",
            AutoSize = true,
            Location = new Point(17, 31)
        };

        txtNome.Location = new Point(20, 57);
        txtNome.Size = new Size(500, 30);
        txtNome.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtNome.PlaceholderText = "Ex.: João Pedro";

        btnCadastrar.Text = "Cadastrar nome";
        btnCadastrar.Location = new Point(535, 55);
        btnCadastrar.Size = new Size(160, 34);
        btnCadastrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnCadastrar.BackColor = Color.FromArgb(35, 105, 190);
        btnCadastrar.ForeColor = Color.White;
        btnCadastrar.FlatStyle = FlatStyle.Flat;
        btnCadastrar.FlatAppearance.BorderSize = 0;
        btnCadastrar.Cursor = Cursors.Hand;

        lblStatusCadastro.AutoSize = true;
        lblStatusCadastro.Location = new Point(20, 101);
        lblStatusCadastro.ForeColor = Color.FromArgb(70, 80, 95);
        lblStatusCadastro.Text = "Digite um nome para iniciar o cadastro.";

        grupoCadastro.Controls.AddRange(
        [
            lblNome,
            txtNome,
            btnCadastrar,
            lblStatusCadastro
        ]);

        var grupoPesquisa = new GroupBox
        {
            Text = "2. Pesquisa digital por prefixo",
            Location = new Point(20, 248),
            Size = new Size(720, 405),
            Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
        };

        var lblPesquisa = new Label
        {
            Text = "Digite o começo do nome:",
            AutoSize = true,
            Location = new Point(17, 30)
        };

        txtPesquisa.Location = new Point(20, 56);
        txtPesquisa.Size = new Size(675, 30);
        txtPesquisa.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtPesquisa.PlaceholderText = "Ex.: jo, joao ou joão pedro";

        var lblInstrucao = new Label
        {
            Text = "Ocorrência de nomes que começam com o texto digitado.",
            AutoSize = true,
            ForeColor = Color.FromArgb(90, 100, 115),
            Location = new Point(20, 92)
        };

        lstResultados.Location = new Point(20, 120);
        lstResultados.Size = new Size(675, 220);
        lstResultados.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        lstResultados.IntegralHeight = false;
        lstResultados.Font = new Font("Segoe UI", 11F);
        lstResultados.BackColor = Color.White;

        lblStatusPesquisa.AutoSize = true;
        lblStatusPesquisa.Location = new Point(20, 354);
        lblStatusPesquisa.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        lblStatusPesquisa.ForeColor = Color.FromArgb(70, 80, 95);
        lblStatusPesquisa.Text = "Cadastre nomes e digite ao menos um caractere para pesquisar.";

        grupoPesquisa.Controls.AddRange(
        [
            lblPesquisa,
            txtPesquisa,
            lblInstrucao,
            lstResultados,
            lblStatusPesquisa
        ]);

        lblTotalCadastrados.Location = new Point(25, 657);
        lblTotalCadastrados.AutoSize = true;
        lblTotalCadastrados.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        lblTotalCadastrados.ForeColor = Color.FromArgb(90, 100, 115);

        Controls.AddRange(
        [
            titulo,
            subtitulo,
            grupoCadastro,
            grupoPesquisa,
            lblTotalCadastrados
        ]);
    }

    private void ConfigurarEventos()
    {
        btnCadastrar.Click += (_, _) => CadastrarNome();
        txtNome.KeyDown += (_, evento) =>
        {
            if (evento.KeyCode == Keys.Enter)
            {
                evento.SuppressKeyPress = true;
                CadastrarNome();
            }
        };

        txtPesquisa.TextChanged += (_, _) => AtualizarResultadosPesquisa();
    }

    private void CadastrarNome()
    {
        string nome = PrepararNome(txtNome.Text);

        if (nome.Length == 0)
        {
            ExibirStatusCadastro("Digite um nome antes de cadastrar.", Color.Firebrick);
            txtNome.Focus();
            return;
        }

        int indiceExistente = metodosPesquisa.PesquisaSequencial(nomesCadastrados, nome);

        if (indiceExistente >= 0)
        {
            ExibirStatusCadastro(
                $"O nome '{nomesCadastrados[indiceExistente]}' já está cadastrado.",
                Color.Firebrick);
            txtNome.SelectAll();
            txtNome.Focus();
            return;
        }

        nomesCadastrados.Add(nome);
        metodosPesquisa.AdicionarNomeNoIndiceDigital(nome);

        ExibirStatusCadastro($"Nome '{nome}' cadastrado com sucesso.", Color.SeaGreen);
        txtNome.Clear();
        txtNome.Focus();
        AtualizarTotalCadastrados();
        AtualizarResultadosPesquisa();
    }

    private void AtualizarResultadosPesquisa()
    {
        string prefixo = txtPesquisa.Text.Trim();
        lstResultados.BeginUpdate();
        lstResultados.Items.Clear();

        if (prefixo.Length == 0)
        {
            lblStatusPesquisa.Text = "Digite ao menos um caractere para pesquisar por prefixo.";
            lstResultados.EndUpdate();
            return;
        }

        IReadOnlyList<string> resultados = metodosPesquisa.PesquisaDigital(prefixo);

        foreach (string nome in resultados)
        {
            lstResultados.Items.Add(nome);
        }

        lblStatusPesquisa.Text = resultados.Count switch
        {
            0 => $"Nenhum nome começa com '{prefixo}'.",
            1 => "1 nome encontrado.",
            _ => $"{resultados.Count} nomes encontrados."
        };

        lstResultados.EndUpdate();
    }

    private void AtualizarTotalCadastrados()
    {
        lblTotalCadastrados.Text = nomesCadastrados.Count switch
        {
            0 => "Nenhum nome cadastrado nesta sessão.",
            1 => "1 nome cadastrado nesta sessão.",
            _ => $"{nomesCadastrados.Count} nomes cadastrados nesta sessão."
        };
    }

    private void ExibirStatusCadastro(string mensagem, Color cor)
    {
        lblStatusCadastro.Text = mensagem;
        lblStatusCadastro.ForeColor = cor;
    }

    private static string PrepararNome(string? nome)
    {
        return string.Join(' ', (nome ?? string.Empty)
            .Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries));
    }
}
