using System.IO;

namespace Back_UITest.SpaHelper
{
    public class SpaLayoutModel
    {
        public SpaLayoutModel(string rootUrl)
        {
            RootUrl = rootUrl.EndsWith("/") ? rootUrl : rootUrl + "/";
        }

        public string RootUrl { get; private set; }

        public bool TestEnvironment { get; set; }

        public string Url(string relativeUrl)
        {
            return Path.Combine(RootUrl, relativeUrl);
        }

        //public string VersionUrl(string relativeUrl)
        //{
        //    return Path.Combine(RootUrl, relativeUrl) + "?v=" + Info.Version;
        //}
    }
}
