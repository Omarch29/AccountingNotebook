using AccountingNotebookAPI.Business;
using AccountingNotebookAPI.DATA;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingNotebookAPI.Helpers
{
    public static class DependencyContainer
    {
        public static IServiceCollection InjectServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountNotebookService, AccountNotebookService>();
            services.AddScoped<ITransactionService, TransactionService>();
            return services;
        }

        public static IServiceCollection InjectRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            return services;
        }
    }
}
