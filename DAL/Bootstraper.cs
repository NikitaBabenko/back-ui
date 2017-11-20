using SimpleInjector;
using VtbPortal.Backend.DAL;
using VtbPortal.Backend.DB;
using VtbPortal.Backend.Loggers;

namespace DAL
{
    internal static class Bootstrapper
    {
        #region Static Methods

        public static Container Initialize()
        {
            var container = new Container();

            LoggersComponentRegistration.RegisterLoggers(container);

            ContextRegistration.RegisterContexts(container);

            MappersComponentRegistration.RegisterMappers(container);

            RepositoryComponentRegistration.RegisterRepositories(container);

            container.Verify();

            return container;
        }

        #endregion
    }
}


