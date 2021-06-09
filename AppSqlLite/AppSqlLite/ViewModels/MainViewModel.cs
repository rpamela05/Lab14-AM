using AppSqlLite.BL;
using AppSqlLite.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppSqlLite.ViewModels
{
    class MainViewModel: ViewModelBase
    {
        Personas personas = new Personas();

        private ObservableCollection<PersonaModel> listPersonas;
        public ObservableCollection<PersonaModel> ListPersonas
        {
            get { return listPersonas; }
            set { listPersonas = value; RaisePropertyChanged(); }
        }
        //Variable id
        private int idPersona;
        public int IdPersonaV
        {
            get { return idPersona; }
            set { idPersona = value; RaisePropertyChanged(); }
        }
        //Variable nombre
        private string namePersona;
        public string NamePersona
        {
            get { return namePersona; }
            set { namePersona = value; RaisePropertyChanged(); }
        }
        //Variable nacimiento
        private DateTime fechaNacimiento;
        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; RaisePropertyChanged(); }
        }
        //Variable activo
        private bool personaActiva;
        public bool PersonaActiva
        {
            get { return personaActiva; }
            set { personaActiva = value; RaisePropertyChanged(); }
        }

        public ICommand InsertRowCommand { get; set; }
        public ICommand UpdateRowCommand { get; set; }
        public ICommand DeleteRowCommand { get; set; }
        public ICommand DeleteAllRowCommand { get; set; }

        public MainViewModel()
        {
            //Eliminar una fila
            DeleteRowCommand = new Command<PersonaModel>(execute: async (personaModel) =>
            {
                await personas.Delete(personaModel);
                LoadListPersonas();
            });

            //Eliminar todo
            DeleteAllRowCommand = new Command(execute: async () =>
            {
                await personas.DeleteAllPersonas();
                LoadListPersonas();
            });

            //actulaizar una fila
            UpdateRowCommand = new Command<PersonaModel>(execute: async (personaModel) =>
            {
                await personas.Update(personaModel);
                LoadListPersonas();
            });

            //Insertar una fila
            InsertRowCommand = new Command(execute: async () =>
            {
                await personas.Insert(new PersonaModel() { IdPersona = IdPersonaV, NombrePersona = NamePersona, FechaNacimiento = FechaNacimiento, PersonaActiva = PersonaActiva });
                IdPersonaV = 0;
                NamePersona = "";
                FechaNacimiento = DateTime.Today;
                PersonaActiva = false;
                LoadListPersonas();
            });

            LoadListPersonas();
        }

        async void LoadListPersonas()
        {
            ListPersonas = new ObservableCollection<PersonaModel>(await personas.GetListPersonas());
        }
    }
}
