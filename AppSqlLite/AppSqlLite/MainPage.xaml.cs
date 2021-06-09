using AppSqlLite.Models;
using AppSqlLite.ViewModels;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace AppSqlLite
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        MainViewModel Vm { get { return BindingContext as MainViewModel; } }
        public async void UpdateRow_Tapped(object sender, EventArgs e)
        {
            var contenedor = ((Frame)sender).GestureRecognizers[0];

            PersonaModel personaModel = ((TapGestureRecognizer)contenedor).CommandParameter as PersonaModel;

            string NameUpt = await DisplayPromptAsync("Name", personaModel.NombrePersona);

            DateTime BirthFmt = personaModel.FechaNacimiento;
            string BirthSrt = BirthFmt.ToString("dd/MM/yyyy");
            string BirthUpt = await DisplayPromptAsync("Birth", BirthSrt);

            bool ActiveFmt = personaModel.PersonaActiva;
            string ActiveSrt = ActiveFmt.ToString();
            string ActiveUpt = await DisplayPromptAsync("Active (True/False)", ActiveSrt);

            personaModel.NombrePersona = NameUpt;
            string format = "dd/MM/yyyy";
            DateTime BirthFmtDt = DateTime.ParseExact(BirthUpt, format, CultureInfo.InvariantCulture);
            personaModel.FechaNacimiento = BirthFmtDt;
            bool ActiveFmtBl = System.Convert.ToBoolean(ActiveSrt);
            Console.WriteLine(ActiveFmtBl);
            personaModel.PersonaActiva = ActiveFmtBl;

            Vm.UpdateRowCommand.Execute(personaModel);

        }

        private async void DeleteRow_Swiped(object sender, SwipedEventArgs e)
        {
            bool result = await DisplayAlert("Eliminar fila", "¿Desea eliminar la fila?", "Si", "No");
            if (result)
            {
                var container = ((Frame)sender).GestureRecognizers[0];
                PersonaModel personaModel = ((TapGestureRecognizer)container).CommandParameter as PersonaModel;
                Vm.DeleteRowCommand.Execute(personaModel);
            }
        }
    }
}