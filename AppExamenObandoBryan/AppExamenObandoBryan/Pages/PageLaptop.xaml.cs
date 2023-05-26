using AppExamenObandoBryan.Code;
using AppExamenObandoBryan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace AppExamenObandoBryan.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageLaptop : ContentPage
    {
        public string Url = "https://apilaptops.azurewebsites.net/api/";

        public PageLaptop()
        {        
            InitializeComponent();
            CargarDatos();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            CargarDatos();
        }

        public void CargarDatos()
        {
            pickPro.Items.Clear();
            pickMar.Items.Clear();
            pickGra.Items.Clear();
            var procesadores = APIConsumer.Procesadors(Url + "Procesadors");
            var marcas = APIConsumer.Marcas(Url + "Marcas");
            var graficas = APIConsumer.Graficas(Url + "Graficas");
            if (procesadores.Length != 0)
            {
                foreach (Procesador procesado in procesadores)
                {
                    pickPro.Items.Add(procesado.marcaPro + " " + procesado.modeloPro);
                }
            }
            if (marcas.Length != 0)
            {
                foreach (Marca marca in marcas)
                {
                    pickMar.Items.Add(marca.nombreMar);
                }
            }
            if (graficas.Length != 0)
            {
                foreach (Grafica grafica in graficas)
                {
                    pickGra.Items.Add(grafica.marcaGra + " " + grafica.modeloGra + " " + grafica.vramGra);
                }
            }
        }

        private void Button_VerLaptops(object sender, EventArgs e)
        {
            var vl = new VerLaptops();
            Navigation.PushAsync(vl);
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            var laptops = APIConsumer.Laptop(Url + "Laptops/" + txtId.Text);
            if (laptops != null)
            {
                txtId.Text = laptops.idLap;
                txtSerie.Text = laptops.serieLap;
                txtModelo.Text = laptops.modeloLap;
                txtRam.Text = laptops.ramLap;
                txtAlmacenamiento.Text = laptops.almacenamientoLap;
                txtPantalla.Text = laptops.pantallaLap;

                var grafica = APIConsumer.Grafica(Url + "Graficas/" + laptops.idGra);
                var marca = APIConsumer.Marca(Url + "Marcas/" + laptops.idMar);
                var procesador = APIConsumer.Procesador(Url + "Procesadors/" + laptops.idPro);

                string textografica = grafica.marcaGra + " " + grafica.modeloGra + " " + grafica.vramGra;
                string textomarca = marca.nombreMar;
                string textoprocesador = procesador.marcaPro + " " + procesador.modeloPro;

                int indiceGrafica = pickGra.Items.IndexOf(textografica);
                int indiceMarca = pickMar.Items.IndexOf(textomarca);
                int indiceProcesador = pickPro.Items.IndexOf(textoprocesador);
                pickGra.SelectedIndex = indiceGrafica;
                pickMar.SelectedIndex = indiceMarca;
                pickPro.SelectedIndex = indiceProcesador;
            }
        }
        private void Button_Clicked1(object sender, EventArgs e)
        {
            Laptop laptop = new Laptop();
            laptop.idLap = txtId.Text;
            laptop.serieLap = txtSerie.Text;
            laptop.modeloLap = txtModelo.Text;
            laptop.ramLap = txtRam.Text;
            laptop.almacenamientoLap = txtAlmacenamiento.Text;
            laptop.pantallaLap = txtPantalla.Text;

            string[] textografica = pickGra.SelectedItem.ToString().Split(' ');
            string[] textoprocesador = pickPro.SelectedItem.ToString().Split(' ');

            var grafica = APIConsumer.Graficas(Url + "Graficas/All/" + textografica[1] + " "+ textografica[2]);
            var marca = APIConsumer.Marcas(Url + "Marcas/All/" + pickMar.SelectedItem.ToString());
            var procesador = APIConsumer.Procesadors(Url + "Procesadors/All/" + textoprocesador[1] + " "+ textoprocesador[2]);

            laptop.idGra = grafica[0].idGra;
            laptop.idMar = marca[0].idMar;
            laptop.idPro = procesador[0].idPro;
            
            string result = APIConsumer.CreateLaptop(Url + "Laptops", laptop, "POST");
            if (result == "OK")
            {
                txtId.Text = "";
                txtSerie.Text = "";
                txtModelo.Text = "";
                txtRam.Text = "";
                txtAlmacenamiento.Text = "";
                txtPantalla.Text = "";
                pickGra.SelectedItem = null;
                pickMar.SelectedItem = null;
                pickPro.SelectedItem = null;
                DisplayAlert("Ingresar", "Se ingresó la laptop correctamente", "Aceptar");
            }
        }
        private void Button_Clicked2(object sender, EventArgs e)
        {
            Laptop laptop = new Laptop();
            laptop.idLap = txtId.Text;
            laptop.serieLap = txtSerie.Text;
            laptop.modeloLap = txtModelo.Text;
            laptop.ramLap = txtRam.Text;
            laptop.almacenamientoLap = txtAlmacenamiento.Text;
            laptop.pantallaLap = txtPantalla.Text;

            string[] textografica = pickGra.SelectedItem.ToString().Split(' ');
            string[] textoprocesador = pickPro.SelectedItem.ToString().Split(' ');

            var grafica = APIConsumer.Graficas(Url + "Graficas/All/" + textografica[1] + " " + textografica[2]);
            var marca = APIConsumer.Marcas(Url + "Marcas/All/" + pickMar.SelectedItem.ToString());
            var procesador = APIConsumer.Procesadors(Url + "Procesadors/All/" + textoprocesador[1] + " " + textoprocesador[2]);

            laptop.idGra = grafica[0].idGra;
            laptop.idMar = marca[0].idMar;
            laptop.idPro = procesador[0].idPro;

            string result = APIConsumer.CreateLaptop(Url + "Laptops/" + txtId.Text, laptop, "PUT");
            if (result == "OK")
            {
                txtId.Text = "";
                txtSerie.Text = "";
                txtModelo.Text = "";
                txtRam.Text = "";
                txtAlmacenamiento.Text = "";
                txtPantalla.Text = "";
                pickGra.SelectedItem = null;
                pickMar.SelectedItem = null;
                pickPro.SelectedItem = null;
                DisplayAlert("Actualizar", "Se actualizó la laptop correctamente", "Aceptar");
            }
        }
        private async void Button_Clicked3(object sender, EventArgs e)
        {
            bool respuesta = await DisplayAlert(title: "Confirmación", message: "¿Estás seguro de que deseas borrar la laptop?", accept: "Aceptar", cancel: "Cancelar");

            if (respuesta)
            {
                string result = APIConsumer.DeleteLaptop(Url, txtId.Text);
                if (result == "OK")
                {
                    txtId.Text = "";
                    txtSerie.Text = "";
                    txtModelo.Text = "";
                    txtRam.Text = "";
                    txtAlmacenamiento.Text = "";
                    txtPantalla.Text = "";
                    pickGra.SelectedItem = null;
                    pickMar.SelectedItem = null;
                    pickPro.SelectedItem = null;
                    await DisplayAlert("Borrar", "Se eliminó la laptop correctamente", "Aceptar");
                }
            }

            
        }
        private void Button_Procesador(object sender, EventArgs e)
        {
            var pp = new PageProcesador();
            Navigation.PushAsync(pp);
        }
        private void Button_Grafica(object sender, EventArgs e)
        {
            var pg = new PageGrafica();
            Navigation.PushAsync(pg);
        }
        private void Button_Marca(object sender, EventArgs e)
        {
            var pm = new PageMarca();
            Navigation.PushAsync(pm);
        }
    }
}