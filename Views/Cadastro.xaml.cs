
using Login.Model;
namespace Login.Views;
public partial class Cadastro : ContentPage
{
    public Cadastro()
    {
        InitializeComponent();
    }
    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            // ?? Lista local (exemplo)
            List<Usuario> list_usuario = new List<Usuario>() 
        {
            new Usuario()
            {
                Nome = "Miguel",
                Email = "Miguel@12345",
                Senha = "admin123"
            },
            new Usuario()
            {
                Nome = "Ana",
                Email = "Ana@54321",
                Senha = "user123"
            }
        };

            // ?? Captura os dados digitados
            string nome = txt_Nome.Text?.Trim();
            string email = txt_Email.Text?.Trim();
            string senha = txt_Senha.Text?.Trim();

            // ?? Validação de campos vazios
            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                await DisplayAlert("Atenção", "Preencha todos os campos.", "OK");
                return;
            }

            // ?? Verifica se já existe um usuário com o mesmo email
            if (list_usuario.Any(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase)))
            {
                await DisplayAlert("Erro", "Este email já está cadastrado.", "OK");
                return;
            }

            // ?? Cria novo usuário e adiciona à lista
            Usuario dados_digitados = new Usuario()
            {
                Nome = nome,
                Email = email,
                Senha = senha
            };

            list_usuario.Add(dados_digitados);

            // ?? Mensagem de sucesso
            await DisplayAlert("Sucesso", "Cadastro feito com sucesso!", "OK");

            // ?? Volta para a tela anterior (Login)
            await Shell.Current.GoToAsync("..");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.Message, "OK");
        }
    }
}