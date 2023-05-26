using AppExamenObandoBryan.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppExamenObandoBryan.Code
{
    internal class APIConsumer
    {
        public static Models.Laptop[] Laptops(string apiUrl)
        {
            var api = new System.Net.WebClient();
            api.Headers.Add("Content-Type", "application/json");
            var json = api.DownloadString(apiUrl);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Laptop[]>(json);
        }
        public static Models.Procesador[] Procesadors(string apiUrl)
        {
            var api = new System.Net.WebClient();
            api.Headers.Add("Content-Type", "application/json");
            var json = api.DownloadString(apiUrl);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Procesador[]>(json);
        }

        public static Models.Marca[] Marcas(string apiUrl)
        {
            var api = new System.Net.WebClient();
            api.Headers.Add("Content-Type", "application/json");
            var json = api.DownloadString(apiUrl);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Marca[]>(json);
        }

        public static Models.Grafica[] Graficas(string apiUrl)
        {
            var api = new System.Net.WebClient();
            api.Headers.Add("Content-Type", "application/json");
            var json = api.DownloadString(apiUrl);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Grafica[]>(json);
        }

        public static string CreateGrafica(string apiUrl, Models.Grafica grafica, string funcion)
        {
            var api = new System.Net.WebClient();
            api.Headers.Add("Content-Type", "application/json");
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(grafica);
            json = api.UploadString(apiUrl, funcion, json);
            return "OK";
        }
        public static Models.Grafica Grafica(string apiUrl)
        {
            var api = new System.Net.WebClient();
            api.Headers.Add("Content-Type", "application/json");
            var json = api.DownloadString(apiUrl);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Grafica>(json);
        }

        public static string CreateProcesador(string apiUrl, Models.Procesador procesador, string funcion)
        {
            var api = new System.Net.WebClient();
            api.Headers.Add("Content-Type", "application/json");
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(procesador);
            json = api.UploadString(apiUrl, funcion, json);
            return "OK";
        }
        public static Models.Procesador Procesador(string apiUrl)
        {
            var api = new System.Net.WebClient();
            api.Headers.Add("Content-Type", "application/json");
            var json = api.DownloadString(apiUrl);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Procesador>(json);
        }

        public static string CreateMarca(string apiUrl, Models.Marca marca, string funcion)
        {
            var api = new System.Net.WebClient();
            api.Headers.Add("Content-Type", "application/json");
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(marca);
            json = api.UploadString(apiUrl, funcion, json);
            return "OK";
        }
        public static Models.Marca Marca(string apiUrl)
        {
            var api = new System.Net.WebClient();
            api.Headers.Add("Content-Type", "application/json");
            var json = api.DownloadString(apiUrl);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Marca>(json);
        }

        public static string CreateLaptop(string apiUrl, Models.Laptop laptop, string funcion)
        {
            var api = new System.Net.WebClient();
            api.Headers.Add("Content-Type", "application/json");
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(laptop);
            json = api.UploadString(apiUrl, funcion, json);
            return "OK";
        }
        public static Models.Laptop Laptop(string apiUrl)
        {
            var api = new System.Net.WebClient();
            api.Headers.Add("Content-Type", "application/json");
            var json = api.DownloadString(apiUrl);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Laptop>(json);
        }

        public static string DeleteLaptop(string apiUrl, string id)
        {
            var api = new System.Net.WebClient();
            api.Headers.Add("Content-Type", "application/json");
            api.UploadString(apiUrl + "/Laptops/" + id, "DELETE", "");
            return "OK";
        }
    }
}
