using BookStore.Service.Contract;
using BookStore.Service.Implementation;
using Microsoft.Extensions.DependencyInjection;
namespace BookStore.Service
{
    public static class DependencyInjection
    {
        public static void AddServiceLayer(this IServiceCollection services)
        {
            services.AddTransient<IBookService, BookService>();
        }
    }
}

