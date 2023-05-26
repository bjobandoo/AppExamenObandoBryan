using AppExamenObandoBryan.Code;
using AppExamenObandoBryan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace AppExamenObandoBryan.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageProcesador : ContentPage
    {
        private string Url = "https://apilaptops.azurewebsites.net/api/";
        public PageProcesador()
        {
            InitializeComponent();
            CargarProcesadores();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //cerramos la pagina actual y regresar a la pagina anterior de la pila
            Navigation.PopAsync();
        }

        private void CargarProcesadores()
        {
            GridProcesadores.RowDefinitions.Clear();
            GridProcesadores.ColumnDefinitions.Clear();
            GridProcesadores.Children.Clear();
            var procesadores = APIConsumer.Procesadors(Url + "Procesadors");
            if (procesadores.Length != 0)
            {
                int i = 0;
                foreach (Procesador procesado in procesadores)
                {                    
                    Grid grid = new Grid();
                    GridProcesadores.RowDefinitions.Add(new RowDefinition());
                    Grid.SetRow(grid, i);

                    ColumnDefinition columna1 = new ColumnDefinition();
                    columna1.Width = new GridLength(1, GridUnitType.Star);
                    grid.ColumnDefinitions.Add(columna1);

                    ColumnDefinition columna2 = new ColumnDefinition();
                    columna2.Width = new GridLength(1, GridUnitType.Star);
                    grid.ColumnDefinitions.Add(columna2);

                    ColumnDefinition columna3 = new ColumnDefinition();
                    columna3.Width = new GridLength(1, GridUnitType.Star);
                    grid.ColumnDefinitions.Add(columna3);

                    Label id = new Label();
                    Label marca = new Label();
                    Label modelo = new Label();

                    id.Text = procesado.idPro + "";
                    marca.Text = procesado.marcaPro + "";
                    modelo.Text = procesado.modeloPro + "";

                    Grid.SetColumn(id, 0);
                    Grid.SetColumn(marca, 1);
                    Grid.SetColumn(modelo, 2);

                    grid.Children.Add(id);
                    grid.Children.Add(marca);
                    grid.Children.Add(modelo);

                    GridProcesadores.Children.Add(grid);
                    i++;
                }
            }
        }

        private void Button_Clicked1(object sender, EventArgs e)
        {
            var procesador = APIConsumer.Procesador(Url + "Procesadors/" + txtId.Text);
            if (procesador != null)
            {
                txtId.Text = procesador.idPro;
                txtMarca.Text = procesador.marcaPro;
                txtModelo.Text = procesador.modeloPro;
            }
        }
        private void Button_Clicked2(object sender, EventArgs e)
        {
            Procesador procesador = new Procesador();
            procesador.idPro = txtId.Text;
            procesador.marcaPro = txtMarca.Text;
            procesador.modeloPro = txtModelo.Text;

            string result = APIConsumer.CreateProcesador(Url + "Procesadors", procesador, "POST");
            CargarProcesadores();
        }
        private void Button_Clicked3(object sender, EventArgs e)
        {
            Procesador procesador = new Procesador();
            procesador.idPro = txtId.Text;
            procesador.marcaPro = txtMarca.Text;
            procesador.modeloPro = txtModelo.Text;

            string result = APIConsumer.CreateProcesador(Url + "Procesadors/" + txtId.Text, procesador, "PUT");
            CargarProcesadores();
        }
    }
}