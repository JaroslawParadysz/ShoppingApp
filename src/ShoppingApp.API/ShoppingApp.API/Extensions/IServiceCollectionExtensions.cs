using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ShoppingApp.Application.Configuration.Commands;
using ShoppingApp.Application.Configuration.UnitOfWork;

namespace ShoppingApp.API.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddCQRS(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ICommand));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkPipelineBehaviour<,>));
            return services;
        }
    }
}
