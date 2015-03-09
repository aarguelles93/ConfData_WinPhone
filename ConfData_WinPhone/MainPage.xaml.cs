using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Windows.Navigation;
using System.IO.IsolatedStorage;

namespace ConfData_WinPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        public IsolatedStorageSettings preferencias;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            preferencias = IsolatedStorageSettings.ApplicationSettings;
        
            if (preferencias.Count <= 0)
            {
                preferencias["Nombre"] = "Usuario";
                preferencias["Edad"] = "";
                preferencias["Genero"] = "";
            }
        
        }

        //Cuando va a ir a la ventana de preferencias
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
          
        }

        //Cuando regresa de la ventana de preferencias
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            textBoxNombreDisp.Text = preferencias["Nombre"].ToString();
            textBoxEdadDisp.Text = preferencias["Edad"].ToString();
            textBoxGenDisp.Text = preferencias["Genero"].ToString();
        }

        private void GoToSettingsPage(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Preferencias.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}