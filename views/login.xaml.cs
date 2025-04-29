namespace Semana2.views;

public partial class login : ContentPage
{

	private string[] usuarios = { "Carlos", "Ana", "Jose" };
	private string[] contrase�as = { "carlos123", "ana123", "jose123" };
    public login()
	{
		InitializeComponent();
	}

    private async void btnLogin_Clicked(object sender, EventArgs e)
    {
        string usuarioIngresado = txtUsuario.Text?.Trim();
        string contrase�aIngresada = txtContrase�a.Text?.Trim();

        // Verificar si el usuario y la contrase�a son correctos
        bool autenticado = false;
        for (int i = 0; i < usuarios.Length; i++)
        {
            if (usuarioIngresado == usuarios[i] && contrase�aIngresada == contrase�as[i])
            {
                autenticado = true;
                break;
            }
        }

        // Si autenticado, mostrar mensaje de bienvenida
        if (autenticado)
        {
            await DisplayAlert("Bienvenido", $"Bienvenido, {usuarioIngresado}!", "OK");
            // Redirigir al siguiente contenido, por ejemplo a la vista de calificaciones
            await Navigation.PushAsync(new vPrincipal());  // Cambiar a la vista principal despu�s del login
        }
        else
        {
            // Si no est� autenticado, mostrar mensaje de error
            await DisplayAlert("Error", "Usuario o contrase�a incorrectos", "OK");
        }
        
    }
}