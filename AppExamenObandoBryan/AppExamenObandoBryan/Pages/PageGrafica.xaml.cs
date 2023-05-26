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
    public partial class PageGrafica : ContentPage
    {
        private string Url = "https://apilaptops.azurewebsites.net/api/";
        public PageGrafica()
        {
            InitializeComponent();
            CargarGrafica();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //cerramos la pagina actual y regresar a la pagina anterior de la pila
            Navigation.PopAsync();
        }

        private void CargarGrafica()
        {
            GridGraficas.RowDefinitions.Clear();
            GridGraficas.ColumnDefinitions.Clear();
            GridGraficas.Children.Clear();
            var graficas = APIConsumer.Graficas(Url + "Graficas");
            if (graficas.Length != 0)
            {
                int i = 0;
                foreach (Grafica grafica in graficas)
                {
                    Grid grid = new Grid();
                    GridGraficas.RowDefinitions.Add(new RowDefinition());
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

                    ColumnDefinition columna4 = new ColumnDefinition();
                    columna4.Width = new GridLength(1, GridUnitType.Star);
                    grid.ColumnDefinitions.Add(columna4);

                    Label id = new Label();
                    Label marca = new Label();
                    Label modelo = new Label();
                    Label vram = new Label();

                    id.Text = grafica.idGra + "";
                    marca.Text = grafica.marcaGra + "";
                    modelo.Text = grafica.modeloGra + "";
                    vram.Text = grafica.vramGra + "";

                    Grid.SetColumn(id, 0);
                    Grid.SetColumn(marca, 1);
                    Grid.SetColumn(modelo, 2);
                    Grid.SetColumn(vram, 3);

                    grid.Children.Add(id);
                    grid.Children.Add(marca);
                    grid.Children.Add(modelo);
                    grid.Children.Add(vram);

                    GridGraficas.Children.Add(grid);
                    i++;
                }
            }
        }

        private void Button_Clicked1(object sender, EventArgs e)
        {
            var graficas = APIConsumer.Grafica(Url + "Graficas/" + txtId.Text);
            if (graficas != null)
            {
                txtId.Text = graficas.idGra;
                txtMarca.Text = graficas.marcaGra;
                txtModelo.Text = graficas.modeloGra;
                txtRam.Text = graficas.vramGra;
            }
        }
        private void Button_Clicked2(object sender, EventArgs e)
        {
            Grafica grafica = new Grafica();
            grafica.idGra = txtId.Text;
            grafica.marcaGra = txtMarca.Text;
            grafica.modeloGra = txtModelo.Text;
            grafica.vramGra = txtRam.Text;
            string result = APIConsumer.CreateGrafica(Url + "Graficas", grafica, "POST");
            CargarGrafica();
        }
        private void Button_Clicked3(object sender, EventArgs e)
        {
            Grafica grafica = new Grafica();
            grafica.idGra = txtId.Text;
            grafica.marcaGra = txtMarca.Text;
            grafica.modeloGra = txtModelo.Text;
            grafica.vramGra = txtRam.Text;
            string result = APIConsumer.CreateGrafica(Url + "Graficas/" + txtId.Text, grafica, "PUT");
            CargarGrafica();
        }
    }
}