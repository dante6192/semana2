namespace Semana2.views;

public partial class vPrincipal : ContentPage
{
	public vPrincipal()
	{
		InitializeComponent();
	}

    private async void btnCalcular_Clicked(object sender, EventArgs e)
    {
        // Validación básica de campos vacíos
        if (string.IsNullOrWhiteSpace(txtSeguimiento1.Text) ||
            string.IsNullOrWhiteSpace(txtExamen1.Text) ||
            string.IsNullOrWhiteSpace(txtSeguimiento2.Text) ||
            string.IsNullOrWhiteSpace(txtExamen2.Text) ||
            pickerEstudiante.SelectedIndex == -1)
        {
            await DisplayAlert("Error", "Todos los campos son obligatorios.", "OK");
            return;
        }

        // Validación de rangos y conversión
        if (!double.TryParse(txtSeguimiento1.Text.Trim(), out double seguimiento1) ||
            !double.TryParse(txtExamen1.Text.Trim(), out double examen1) ||
            !double.TryParse(txtSeguimiento2.Text.Trim(), out double seguimiento2) ||
            !double.TryParse(txtExamen2.Text.Trim(), out double examen2))
        {
            await DisplayAlert("Error", "Las notas deben ser valores numéricos.", "OK");
            return;
        }

        if (seguimiento1 < 0 || seguimiento1 > 10 ||
            examen1 < 0 || examen1 > 10 ||
            seguimiento2 < 0 || seguimiento2 > 10 ||
            examen2 < 0 || examen2 > 10)
        {
            await DisplayAlert("Error", "Las notas deben estar entre 0 y 10.", "OK");
            return;
        }

        // Cálculo de notas
        double notaParcial1 = seguimiento1 * 0.3 + examen1 * 0.2;
        double notaParcial2 = seguimiento2 * 0.3 + examen2 * 0.2;
        double notaFinal = notaParcial1 + notaParcial2;

        string estado = notaFinal >= 7 ? "APROBADO" :
                        (notaFinal >= 5 ? "COMPLEMENTARIO" : "REPROBADO");

        string mensaje = $"Estudiante: {pickerEstudiante.SelectedItem}\n" +
                         $"Fecha: {dateFecha.Date.ToShortDateString()}\n" +
                         $"Nota Parcial 1: {notaParcial1:F2}\n" +
                         $"Nota Parcial 2: {notaParcial2:F2}\n" +
                         $"Nota Final: {notaFinal:F2}\n" +
                         $"Estado: {estado}";

        await DisplayAlert("Resultado", mensaje, "OK");
    }
}