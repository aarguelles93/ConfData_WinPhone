using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;

namespace ConfData_WinPhone
{
    public partial class Preferencias : PhoneApplicationPage
    {
        public IsolatedStorageSettings preferencias;

        public Preferencias()
        {
            InitializeComponent();
            preferencias = IsolatedStorageSettings.ApplicationSettings;
        }

        private void guardarPreferencias(object sender, RoutedEventArgs e)
        {
            preferencias["Nombre"] = textBoxNombre.Text.ToString();
            preferencias["Edad"] = textBoxEdad.Text.ToString();
            int ind = listBoxGenero.SelectedIndex;
            ListBoxItem temp = (ListBoxItem) listBoxGenero.SelectedItem;
            String gen="";
            if (temp != null)
            {
                gen = temp.Content.ToString();
            }
            preferencias["Genero"] = gen;
            //Notifico que los datos han sido guardados
            MessageBox.Show("Los datos han sido salvados!");
            
        }

        //Al abrir la página de preferencias
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            textBoxNombre.Text = preferencias["Nombre"].ToString();
            textBoxEdad.Text = preferencias["Edad"].ToString();
            if (preferencias["Genero"].ToString().CompareTo("Masculino") == 0)
            {
                listBoxGenero.SelectedIndex = 0;
            }
            else if (preferencias["Genero"].ToString().CompareTo("Femenino") == 0)
            {
                listBoxGenero.SelectedIndex = 1;
            }
            else
                listBoxGenero.SelectedIndex = -1;
           
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


    }
}