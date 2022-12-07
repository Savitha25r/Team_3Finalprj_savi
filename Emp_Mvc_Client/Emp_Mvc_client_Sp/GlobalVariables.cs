using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;


namespace Emp_Mvc_client_Sp
{
    public class GlobalVariables
    {
        public static HttpClient webclient = new HttpClient();

        static GlobalVariables()
        {
            webclient.BaseAddress = new Uri("https://localhost:44374/api/"); webclient.DefaultRequestHeaders.Clear(); webclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

    }
}
