namespace Login
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // 🔹 registra a página de cadastro
            Routing.RegisterRoute(nameof(Login.Views.Cadastro), typeof(Login.Views.Cadastro));
        }
    }
}
