using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormAplicacion.Modelos;

namespace WindowsFormAplicacion
{
    public partial class FrmProductos : Form
    {
        HttpClient webAppClient = new HttpClient();

        public FrmProductos()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             webAppClient.BaseAddress = new Uri("https://localhost:44320/api/");
             webAppClient.DefaultRequestHeaders.Clear();
             webAppClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            IEnumerable<Productos> productos;
            HttpResponseMessage response = webAppClient.GetAsync("Productos").Result;
            productos = response.Content.ReadAsAsync<IEnumerable<Productos>>().Result;
            dgvProductos.DataSource = productos;
        }
        
    }
}
