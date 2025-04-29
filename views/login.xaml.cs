namespace Semana2.views;

public partial class login : ContentPage
{

	private string[] usuarios = { "Carlos", "Ana", "Jose" };
	private string[] contraseñas = { "carlos123", "ana123", "jose123" };
    public login()
	{
		InitializeComponent();
	}

    private async void btnLogin_Clicked(object sender, EventArgs e)
    {
        string usuarioIngresado = txtUsuario.Text?.Trim();
        string contraseñaIngresada = txtContraseña.Text?.Trim();

        // Verificar si el usuario y la contraseña son correctos
        bool autenticado = false;
        for (int i = 0; i < usuarios.Length; i++)
        {
            if (usuarioIngresado == usuarios[i] && contraseñaIngresada == contraseñas[i])
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
            await Navigation.PushAsync(new vPrincipal());  // Cambiar a la vista principal después del login
        }
        else
        {
            // Si no está autenticado, mostrar mensaje de error
            await DisplayAlert("Error", "Usuario o contraseña incorrectos", "OK");
        }
        
    }
}