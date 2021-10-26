using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace peticioneshttp
{
    public partial class Form1 : Form
    {

        RestClient cliente = new RestClient("https://randomuser.me");

        public Form1()
        {
            InitializeComponent();
            
        }

        public void obtenerLista()
        {
            var request = new RestRequest("/api/?results=" + txt_numero_registros.Text, Method.GET);
            //request.AddUrlSegment("registros", int.Parse(txt_numero_registros.Text));

            request.RequestFormat = DataFormat.Json;
            var respuesta = cliente.Execute(request);
            JObject dataobject = JObject.Parse(respuesta.Content);

            JArray data = (JArray)dataobject["results"];

            List<string> lista = new List<string>();

            foreach(var item in data)
            {
                lista.Add(item["name"]["first"] + " " + item["name"]["last"]);
            }

            Console.WriteLine("resultado: " + data);
            lts_lista.DataSource = lista;
        }

        private void btn_obtener_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("el numero de la lista: " + txt_numero_registros.Text);
            obtenerLista();
        }

    }
}
