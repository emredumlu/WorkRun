using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WorkRun.Client.BL
{
    public class WorkRunClient
    {
        private readonly HttpClient _client;
        public WorkRunClient()
        {
            _client = GetClient();
        }

        private HttpClient GetClient()
        {
            HttpClient client = new();
            client.BaseAddress = new("");
            client.DefaultRequestHeaders.Add("db-type", "1");
            return client;
        }
    }
}
