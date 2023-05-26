using AppExamenObandoBryan.Code;
using AppExamenObandoBryan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppExamenObandoBryan.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageMarca : ContentPage
    {
        private string Url = "https://apilaptops.azurewebsites.net/api/";
        public PageMarca()
        {
            InitializeComponent();
            CargarMarcas();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //cerramos la pagina actual y regresar a la pagina anterior de la pila
            Navigation.PopAsync();
        }

        private void CargarMarcas()
        {
            GridMarcas.RowDefinitions.Clear();
            GridMarcas.ColumnDefinitions.Clear();
            GridMarcas.Children.Clear();
            var marcas = APIConsumer.Marcas(Url + "Marcas");
            if (marcas.Length != 0)
            {
                int i = 0;
                foreach (Marca marca in marcas)
                {
                    Grid grid = new Grid();
                    GridMarcas.RowDefinitions.Add(new RowDefinition());
                    Grid.SetRow(grid, i);

                    ColumnDefinition columna1 = new ColumnDefinition();
                    columna1.Width = new GridLength(50);
                    grid.ColumnDefinitions.Add(columna1);

                    ColumnDefinition columna2 = new ColumnDefinition();
                    columna2.Width = new GridLength(80);
                    grid.ColumnDefinitions.Add(columna2);

                    ColumnDefinition columna3 = new ColumnDefinition();
                    columna3.Width = new GridLength(1, GridUnitType.Star);
                    grid.ColumnDefinitions.Add(columna3);

                    Label id = new Label();
                    Label nombre = new Label();
                    Label descripcion = new Label();

                    id.Text = marca.idMar + "";
                    nombre.Text = marca.nombreMar + "";
                    descripcion.Text = marca.descripcionMar + "";

                    Grid.SetColumn(id, 0);
                    Grid.SetColumn(nombre, 1);
                    Grid.SetColumn(descripcion, 2);

                    grid.Children.Add(id);
                    grid.Children.Add(nombre);
                    grid.Children.Add(descripcion);

                    GridMarcas.Children.Add(grid);
                    i++;
                }
            }
        }

        private void Button_Clicked1(object sender, EventArgs e)
        {
            var marca = APIConsumer.Marca(Url + "Marcas/" + txtId.Text);
            if (marca != null)
            {
                txtId.Text = marca.idMar;
                txtNombre.Text = marca.nombreMar;
                txtDescripcion.Text = marca.descripcionMar;
            }
        }
        private void Button_Clicked2(object sender, EventArgs e)
        {
            Marca marca = new Marca();
            marca.idMar = txtId.Text;
            marca.nombreMar = txtNombre.Text;
            marca.descripcionMar = txtDescripcion.Text;

            string result = APIConsumer.CreateMarca(Url + "Marcas", marca, "POST");
            CargarMarcas();
        }
        private void Button_Clicked3(object sender, EventArgs e)
        {
            Marca marca = new Marca();
            marca.idMar = txtId.Text;
            marca.nombreMar = txtNombre.Text;
            marca.descripcionMar = txtDescripcion.Text;

            string result = APIConsumer.CreateMarca(Url + "Marcas/" + txtId.Text, marca, "PUT");
            CargarMarcas();
        }
    }
}