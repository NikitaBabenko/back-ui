using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Back_UITest.Controllers
{
    [RoutePrefix("api/shareholder")]
    public class ShareholderController : ApiController
    {
        private string GetHost()
        {
            return ConfigurationManager.AppSettings["Host"];
        }

        private string GetShareholderService()
        {
            return $"{GetHost()}/ShareholderAccountService.svc/Shareholder/";
        }

        [HttpGet, Route("GetFiltered/{search}")]
        [AllowAnonymous]
        public async Task<HttpResponseMessage> GetAll(string search)
        {
            HttpResponseMessage result;
            using (HttpClient client = new HttpClient() { BaseAddress = new Uri(GetShareholderService()) })
            {
                if (string.IsNullOrEmpty(search) || search.ToLower() == "null")
                    result = await client.GetAsync("GetFiltered");
                else
                    result = await client.GetAsync("GetFiltered?search=" + search);
            }
            return result;
        }

        [HttpGet, Route("Shareholder/{id}")]
        [AllowAnonymous]
        public async Task<HttpResponseMessage> Shareholder(string id)
        {
            HttpResponseMessage result;
            using (HttpClient client = new HttpClient() { BaseAddress = new Uri(GetShareholderService()) })
            {
                result = await client.GetAsync("Shareholder/" + id);
            }
            return result;
        }

        [HttpGet, Route("Export/{search}")]
        [AllowAnonymous]
        public async Task<HttpResponseMessage> Export(string search)
        {
            HttpResponseMessage result;
            using (HttpClient client = new HttpClient() { BaseAddress = new Uri(GetShareholderService()) })
            {
                if (string.IsNullOrEmpty(search) || search.ToLower() == "null")
                    result = await client.GetAsync("Export");
                else
                    result = await client.GetAsync("Export?search=" + search);
            }
            return result;
        }

        [HttpGet, Route("ExportSingle/{id}")]
        [AllowAnonymous]
        public async Task<HttpResponseMessage> ExportSingle(string id)
        {
            HttpResponseMessage result;
            using (HttpClient client = new HttpClient() { BaseAddress = new Uri(GetShareholderService()) })
            {
                result = await client.GetAsync("Export/" + id );
            }
            return result;
        }
    }

}