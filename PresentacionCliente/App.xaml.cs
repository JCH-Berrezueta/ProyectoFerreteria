using System.Diagnostics;

namespace PresentacionCliente
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Debug.WriteLine(CapaLogica.Class1.probar());
            MainPage = new AppShell();
        }
    }
}
