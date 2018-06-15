using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace web_api_log4net.Models
{
    public class WebApiLogger
    {
        public string url { get; set; }
        public HttpClient client { get; set; }

        public WebApiLogger(string protocol, string hostname, int port, string loglevel, string apiUrl, string jsonString)
        {
            // Setting up the url to send log info
            url = protocol + "://" + hostname + ":" + port + "/" + apiUrl;

            // Creating instance of http client
            client = new HttpClient();

            // Performing the SendLogInfoToApiAsync Task asyncroniously
            Task SendResultTask = Task.Run(async () => await SendLogInfoToApiAsync(url, jsonString));

        }

        public async Task SendLogInfoToApiAsync(string url, string jsonString)
        {
            var json = jsonString.Replace("'", "\"");
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await client.PostAsync(url, content);
        }
    }
}