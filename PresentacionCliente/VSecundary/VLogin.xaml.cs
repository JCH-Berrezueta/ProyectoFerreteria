//using clientes = CapaDatos.Seguridad.CuentaCD;
namespace PresentacionCliente.VSecundary;

public partial class VLogin : ContentPage
{
    
	public VLogin()
	{
		InitializeComponent();
	}

    private async void ButtonRegister(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new VRegister());
    }

    private void ButtonIngresar(object sender, EventArgs e)
    {
        string correo = CorreoU.Text;
        string contrasena = ContraU.Text;

        if(correo == null || contrasena == null)
        {
            DisplayAlert("Error", "Debe llenar todos los campos", "Aceptar");
        }
        else if(correo == "admin" && contrasena == "admin")
        {
            Navigation.PushAsync(new VThird.VTienda());
        }
        else
        {
            
        }
    }
}