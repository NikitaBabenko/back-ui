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
    public class ShareholderController : BaseController
    {
        Service service = Service.Shareholder;

        [HttpGet, Route("GetFiltered/{search}")]
        [AllowAnonymous]
        public async Task<HttpResponseMessage> GetAll(string search)
        {
            HttpResponseMessage result = await GetFromService("GetFiltered", service, new List<string>() { "search=" + search });
            return result;
        }

        [HttpGet, Route("Shareholder/{id}")]
        [AllowAnonymous]
        public async Task<HttpResponseMessage> Shareholder(string id)
        {
            HttpResponseMessage result = await GetFromService("Shareholder", service, new List<string>() { id }, true);
            return result;
        }

        [HttpGet, Route("Export/{search}")]
        [AllowAnonymous]
        public async Task<HttpResponseMessage> Export(string search)
        {
            HttpResponseMessage result = await GetFromService("Export", service, new List<string>() { "search=" + search });
            return result;
        }

        [HttpGet, Route("ExportSingle/{id}")]
        [AllowAnonymous]
        public async Task<HttpResponseMessage> ExportSingle(string id)
        {
            HttpResponseMessage result = await GetFromService("Export", service, new List<string>() { id }, true);
            return result;
        }
    }

}