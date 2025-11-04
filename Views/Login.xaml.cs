namespace Login.Views
{
    public partial class Login : ContentPage
    {
        private async void Entrar_Clicked(object sender, EventArgs e)
        {
            string email = txt_Email.Text?.Trim();
            string senha = txt_Senha.Text?.Trim(); // corrigido

            // Validação simples
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                await DisplayAlert("Atenção", "Por favor, preencha todos os campos.", "OK");
                return;
            }

            // Busca usuário na lista
            var usuario = App.ListaUsuarios
                .FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase)
                                  && u.Senha == senha);

            if (usuario != null)
            {
                await DisplayAlert("Bem-vindo", $"Olá, {usuario.Nome}!", "OK");
                App.Current.MainPage = new AppShell();
            }
            else
            {
                await DisplayAlert("Erro", "Usuário ou senha inválidos.", "OK");
            }
        }

        private async void CriarConta_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(Cadastro));
        }


    }
}
