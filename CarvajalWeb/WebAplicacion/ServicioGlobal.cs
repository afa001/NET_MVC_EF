using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace WebAplicacion
{
    public static class ServicioGlobal
    {
        public static HttpClient webAppClient = new HttpClient();
        static ServicioGlobal()
        {
            webAppClient.BaseAddress = new Uri("https://localhost:44320/api/");
            webAppClient.DefaultRequestHeaders.Clear();
            webAppClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}