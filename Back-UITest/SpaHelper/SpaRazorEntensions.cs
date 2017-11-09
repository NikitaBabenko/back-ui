using System;
using Owin;
using Owin.Types.Extensions;

namespace Back_UITest.SpaHelper
{
    public static class SpaRazorExtensions
    {
        public static IAppBuilder UseSpaRazor(this IAppBuilder appBuilder, string layotCshtml)
        {
            if (appBuilder == null)
            {
                throw new ArgumentNullException(nameof(appBuilder));
            }

            if (layotCshtml == null)
            {
                throw new ArgumentNullException(nameof(layotCshtml));
            }

            var middleware = new SpaRazorMiddleware(layotCshtml);
            return appBuilder.UseHandlerAsync(middleware.Handle);
        }
    }
}
