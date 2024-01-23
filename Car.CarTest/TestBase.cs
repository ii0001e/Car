using Car.ApplicationServices.Services;
using Car.CarTest.Macros;
using Car.CarTest.Mock;
using Car.Core.ServiceInterface;
using Car.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Car.CarTest
{
    public class TestBase
    {
        protected IServiceProvider ServiceProvider { get; }

        protected TestBase()
        {
            var services = new ServiceCollection();
            SetupServices(services);
            ServiceProvider = services.BuildServiceProvider();
        }
        public void Dispose()
        {

        }
        protected T Svc<T>()
        {
            return ServiceProvider.GetService<T>();
        }

        protected T Macro<T>() where T : IMacros
        {
            return ServiceProvider.GetService<T>();
        }

        public virtual void SetupServices(IServiceCollection services)
        {
            services.AddScoped<ICarDataServices, CarDataServices>();
            services.AddScoped<IHostEnvironment, MockHostEnviroment>();



            services.AddDbContext<CarContext>(x =>
            {
                x.UseInMemoryDatabase("TEST");
                x.ConfigureWarnings(e => e.Ignore(InMemoryEventId.TransactionIgnoredWarning));

            });
            RegisterMacros(services);

        }
        private void RegisterMacros(IServiceCollection services)
        {
            var macrosBaseType = typeof(IMacros);

            var macros = macrosBaseType.Assembly.GetTypes()
                .Where(x => macrosBaseType.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);

            foreach (var macro in macros)
            {
                services.AddSingleton(macro);

            }
        }
    }
}