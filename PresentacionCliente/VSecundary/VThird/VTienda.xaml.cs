namespace PresentacionCliente.VSecundary.VThird;

public partial class VTienda : ContentPage
{
	public VTienda()
	{
		InitializeComponent();
        ProductosCollectionView.ItemsSource = ProductoLN.listarVistaProductosLN();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("Alerta", "�Desea agregar el producto al carrito?", "S�", "No");
        if (answer)
        {
            // El usuario seleccion� "S�"
            // Aqu� puedes agregar el c�digo para agregar el producto al carrito
            bool confirmacion = await DisplayAlert("Alerta", "Usted ha elegido este producto para comprarlo", "Seguir comprando", "Finalizar compra");
            if (confirmacion)
            {
                //El usuario continuo comprando
            }
            else
            {
                //El usuario Finalizo Compra
                await Navigation.PushAsync(new VThird.VCar());
            }
        }
        else
        {
            // El usuario seleccion� "No"
            // Aqu� puedes agregar el c�digo para manejar la respuesta negativa
            await DisplayAlert("", "Suerte la proxima vez", "OK");
        }
    }

    //codigo que permite bloquear la opcion de retroceder
    protected override bool OnBackButtonPressed()
    {
        // No permitir navegar hacia atr�s
        return true;

    }
}