using System.Diagnostics;

namespace PresentacionAdmin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Debug.WriteLine(CapaLogica.Class1.probar());
        }
    }
}
