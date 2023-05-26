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
    public partial class VerLaptops : ContentPage
    {
        private string Url = "https://apilaptops.azurewebsites.net/api/";
        public VerLaptops()
        {
            InitializeComponent();
            CargarLaptops();
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            //cerramos la pagina actual y regresar a la pagina anterior de la pila
            Navigation.PopAsync();
        }
        private void CargarLaptops()
        {
            GridLaptops.RowDefinitions.Clear();
            GridLaptops.ColumnDefinitions.Clear();
            GridLaptops.Children.Clear();
            var laptops = APIConsumer.Laptops(Url + "Laptops");
            if (laptops.Length != 0)
            {
                int i = 0;
                foreach (Laptop laptop in laptops)
                {
                    Grid grid = new Grid();
                    GridLaptops.RowDefinitions.Add(new RowDefinition());
                    Grid.SetRow(grid, i);

                    ColumnDefinition columna1 = new ColumnDefinition();
                    columna1.Width = new GridLength(20);
                    grid.ColumnDefinitions.Add(columna1);

                    ColumnDefinition columna2 = new ColumnDefinition();
                    columna2.Width = new GridLength(100);
                    grid.ColumnDefinitions.Add(columna2);

                    ColumnDefinition columna3 = new ColumnDefinition();
                    columna3.Width = new GridLength(60);
                    grid.ColumnDefinitions.Add(columna3);

                    ColumnDefinition columna4 = new ColumnDefinition();
                    columna4.Width = new GridLength(40);
                    grid.ColumnDefinitions.Add(columna4);

                    ColumnDefinition columna5 = new ColumnDefinition();
                    columna5.Width = new GridLength(50);
                    grid.ColumnDefinitions.Add(columna5);

                    ColumnDefinition columna6 = new ColumnDefinition();
                    columna6.Width = new GridLength(40);
                    grid.ColumnDefinitions.Add(columna6);

                    Grid grid2 = new Grid();
                    GridLaptops.RowDefinitions.Add(new RowDefinition());
                    Grid.SetRow(grid2, i + 1);

                    ColumnDefinition columna7 = new ColumnDefinition();
                    columna7.Width = new GridLength(60);
                    grid2.ColumnDefinitions.Add(columna7);

                    ColumnDefinition columna8 = new ColumnDefinition();
                    columna8.Width = new GridLength(1, GridUnitType.Star);
                    grid2.ColumnDefinitions.Add(columna8);

                    ColumnDefinition columna9 = new ColumnDefinition();
                    columna9.Width = new GridLength(1, GridUnitType.Star);
                    grid2.ColumnDefinitions.Add(columna9);

                    Label id = new Label();
                    Label modelo = new Label();
                    Label serie = new Label();
                    Label ram = new Label();
                    Label almacenamiento = new Label();
                    Label pantalla = new Label();
                    Label marca = new Label();
                    Label grafica = new Label();
                    Label procesador = new Label();

                    var graficaGR = APIConsumer.Grafica(Url + "Graficas/" + laptop.idGra);
                    var marcaGR = APIConsumer.Marca(Url + "Marcas/" + laptop.idMar);
                    var procesadorGR = APIConsumer.Procesador(Url + "Procesadors/" + laptop.idPro);

                    id.Text = laptop.idLap + "";
                    modelo.Text = laptop.modeloLap + "";
                    serie.Text = laptop.serieLap + "";
                    ram.Text = laptop.ramLap + "";
                    almacenamiento.Text = laptop.almacenamientoLap + "";
                    pantalla.Text = laptop.pantallaLap + "";

                    marca.Text = marcaGR.nombreMar;
                    grafica.Text = graficaGR.marcaGra + graficaGR.modeloGra;
                    procesador.Text = procesadorGR.marcaPro + procesadorGR.modeloPro;

                    Grid.SetColumn(id, 0);
                    Grid.SetColumn(modelo, 1);
                    Grid.SetColumn(serie, 2);
                    Grid.SetColumn(ram, 3);
                    Grid.SetColumn(almacenamiento, 4);
                    Grid.SetColumn(pantalla, 5);

                    Grid.SetColumn(marca, 0);
                    Grid.SetColumn(grafica, 1);
                    Grid.SetColumn(procesador, 2);

                    grid.Children.Add(id);
                    grid.Children.Add(modelo);
                    grid.Children.Add(serie);
                    grid.Children.Add(ram);
                    grid.Children.Add(almacenamiento);
                    grid.Children.Add(pantalla);

                    grid2.Children.Add(marca);
                    grid2.Children.Add(grafica);
                    grid2.Children.Add(procesador);

                    GridLaptops.Children.Add(grid2);
                    GridLaptops.Children.Add(grid);
                    i +=3;
                }
            }
        }    
    }
}