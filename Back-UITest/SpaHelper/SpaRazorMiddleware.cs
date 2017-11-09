using Owin.Types;
using RazorEngine;
using RazorEngine.Templating;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Back_UITest.SpaHelper
{
    public class SpaRazorMiddleware
    {
        private readonly ITemplateKey _key;

        //private readonly bool _testEnvironment;

        public SpaRazorMiddleware(string defaultview)
        {
            _key = CreateRazorKey(defaultview);
            //if (!AppSettings.TryGet("TestEnvironment", out _testEnvironment))
            //    _testEnvironment = false;
        }

        public async Task Handle(OwinRequest request, OwinResponse response, Func<Task> next)
        {
            if (request.Uri.AbsolutePath.ToLower().Contains("/elmah.axd"))
            {
                if (next != null) await next();
                return;
            }

            using (var sw = new StringWriter())
            {
                var model = new SpaLayoutModel(request.PathBase) { /*TestEnvironment = _testEnvironment*/ };
                Engine.Razor.RunCompile(_key, sw, model.GetType(), model);
                response.ContentType = "text/html";
                var buffer = System.Text.Encoding.UTF8.GetBytes(sw.ToString());
                await response.Body.WriteAsync(buffer, 0, buffer.Length);
            }
        }

        private static ITemplateKey CreateRazorKey(string defaultview)
        {
            var key = new NameOnlyTemplateKey("spaLayout", ResolveType.Global, null);
            var rootPath = AppDomain.CurrentDomain.BaseDirectory;
            var template = File.ReadAllText(Path.Combine(rootPath, defaultview));
            Engine.Razor.AddTemplate(key, new LoadedTemplateSource(template));
            return key;
        }
    }
}
