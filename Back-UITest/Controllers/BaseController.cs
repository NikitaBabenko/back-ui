using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Back_UITest.Controllers
{
    public  class BaseController : ApiController
    {
        private static string GetHost()
        {
            return ConfigurationManager.AppSettings["Host"];
        }

        private static string FeedbackService { get {
                return $"{GetHost()}/FeedbackService.svc/Feedback/";
            } }

        private static string ShareholderService
        {
            get
            {
                return $"{GetHost()}/ShareholderAccountService.svc/Shareholder/";
            }
        }

        private string GetHost(Service service)
        {
            switch (service)
            {
                case Service.Feedback:
                    return FeedbackService;
                case Service.Shareholder:
                    return ShareholderService;
                default:
                    return FeedbackService;
            }
        }

        internal async Task<HttpResponseMessage> GetFromService(string method, Service service, List<string> atributes, bool atFlesh = false)
        {
            atributes = atributes.Where(s => !s.ToLower().Contains("null")).ToList();
            string atributesUrl = string.Empty;
            if (atributes.Any())
                atributesUrl = 
                    atFlesh ? string.Empty : "?" 
                    + string.Join( atFlesh ? "/" : "&", atributes);

            HttpResponseMessage result;
            using (HttpClient client = new HttpClient() { BaseAddress = new Uri(GetHost(service)) })
            {
                result = await client.GetAsync(method + atributesUrl);
            }
            return result;
        }
    }

    public enum Service
    {
        Feedback,
        Shareholder
    }
}