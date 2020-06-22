using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ShoppingApp.Application.Configuration.Commands;
using ShoppingApp.Application.Configuration.UnitOfWork;
using ShoppingApp.Application.SeedWork;
using ShoppingApp.Infrastructure.SqlServer.Application;

namespace ShoppingApp.API.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddCQRS(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ICommand));
            services.AddScoped(typeof(ICommandProcessor<,>), typeof(CommandProcessor<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CQRSPipelineBehaviour<,>));
            return services;
        }
    }
}
