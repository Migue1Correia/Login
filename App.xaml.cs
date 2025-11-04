namespace Login
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        public static object ListaUsuarios { get; internal set; }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}