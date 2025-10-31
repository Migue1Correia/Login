namespace Login.Views
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        // 🔹 Evento do botão "Criar Conta"
        private async void CriarConta_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(Cadastro));
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                List<Usuario> list_usuario = new List<Usuario>()
                {
                    new Usuario()
                    {
                        nome = "Miguel",
                        Email = "Miguel@12345",
                        senha = "admin123"
                    },

                    new Usuario()
                    {
                        nome = "Ana",
                        Email = "Ana@54321",
                        senha = "user123"
                    }
                };

                Usuario dados_digitados = new Usuario()
                {
                    nome = txt_Nome.Text,
                    senha = txt_Senha.Text,
                    Email = txt_Email.Text
                };
                if (list_usuario.Any(i => dados_digitados.senha == i.senha && dados_digitados.Email == i.Email))
                {
                    await SecureStorage.Default.SetAsync("usuario_logado", dados_digitados.Email);

                    App.Current.MainPage = new AppShell();

                }
                else
                {
                    await DisplayAlert("Atenção", "Usuário ou senha inválidos", "OK");
                }


            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
