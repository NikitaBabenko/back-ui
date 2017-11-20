using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.Mvc;
using System.Configuration;
using System.Web.Http;
//using System.Web.Http.Routing;

using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using VtbPortal.Backend.Core.Models;

namespace Back_UITest.Controllers
{
    [RoutePrefix("api/feedback")]
    public class FeedbackController : BaseController
    {
        Service service = Service.Feedback;


        //[HttpGet, Route("GetAll")]
        //[AllowAnonymous]
        //public IEnumerable<FeedbackForm> GetAll()
        //{
        //    var dal = new DAL.DAL();
        //    return dal.GetAllFeedbackForms();


        //    //HttpResponseMessage result = await GetFromService("get-all", service, new List<string>());
        //    //return result;
        //}

        [HttpGet, Route("GetAll")]
        [AllowAnonymous]
        public async Task<HttpResponseMessage> GetAll()
        {
            HttpResponseMessage result = await GetFromService("get-all", service, new List<string>());
            return result;
        }

        [HttpGet, Route("GetByFilter/{startDate}/{endDate}/{feedbackFormId}/{search}")]
        [AllowAnonymous]
        public async Task<HttpResponseMessage> GetByFilter(string startDate, string endDate, string feedbackFormId, string search)
        {
            //HttpResponseMessage result;
            //List<string> atributes = 
            //    new List<string> { $"StartDate={startDate}", $"EndDate={endDate}", $"Id={feedbackFormId}", $"Search={search}" }
            //    .Where(s => !s.ToLower().Contains("null")).ToList();
            //using (HttpClient client = new HttpClient() { BaseAddress = new Uri(FeedbackService) })
            //{
            //    if (atributes.Any())
            //        result = await client.GetAsync($"GetByFilter?{string.Join("&",atributes)}");
            //    else
            //        result = await client.GetAsync("get-all");
            //}
            HttpResponseMessage result = await GetFromService("GetByFilter", service, 
                 new List<string> { $"StartDate={startDate}", $"EndDate={endDate}", $"Id={feedbackFormId}", $"Search={search}" });
            return result;
        }

        [HttpGet, Route("Export/{startDate}/{endDate}/{feedbackFormId}/{search}")]
        [AllowAnonymous]
        public async Task<HttpResponseMessage> Export(string startDate, string endDate, string feedbackFormId, string search)
        {
            //HttpResponseMessage result;
            //List<string> atributes =
            //    new List<string> { $"StartDate={startDate}", $"EndDate={endDate}", $"Id={feedbackFormId}", $"Search={search}" }
            //    .Where(s => !s.ToLower().Contains("null")).ToList();
            //using (HttpClient client = new HttpClient() { BaseAddress = new Uri(FeedbackService) })
            //{
            //    if (atributes.Any())
            //        result = await client.GetAsync($"Export?{string.Join("&", atributes)}");
            //    else
            //        result = await client.GetAsync("Export");
            //}
            HttpResponseMessage result = await GetFromService("Export", service,
                 new List<string> { $"StartDate={startDate}", $"EndDate={endDate}", $"Id={feedbackFormId}", $"Search={search}" });
            return result;
        }

        [HttpGet, Route("ExportSingle/{id}")]
        [AllowAnonymous]
        public async Task<HttpResponseMessage> ExportSingle(int id)
        {
            //HttpResponseMessage result;
            //using (HttpClient client = new HttpClient() { BaseAddress = new Uri(FeedbackService) })
            //{
            //    result = await client.GetAsync($"Export/{id}");
            //}
            HttpResponseMessage result = await GetFromService("Export", service, new List<string>(id), true);
            return result;
        }
        [HttpGet, Route("GetData/{id}")]
        [AllowAnonymous]
        public async Task<HttpResponseMessage> GetData(int id)
        {
            //HttpResponseMessage result;
            //using (HttpClient client = new HttpClient() { BaseAddress = new Uri(FeedbackService) })
            //{
            //    result = await client.GetAsync($"get-data/{id}");
            //}
            HttpResponseMessage result = await GetFromService("get-data", service, new List<string>(id), true);
            return result;
        }

        

    }
}