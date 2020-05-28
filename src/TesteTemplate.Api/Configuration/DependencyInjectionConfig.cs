using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using TesteTemplate.Api.Controllers.Base;
using TesteTemplate.Domain.Interfaces.Repositories;
using TesteTemplate.Domain.Interfaces.Services;
using TesteTemplate.Infra.Data.Persistence;
using TesteTemplate.Infra.Data.Persistence.Repositories;
using TesteTemplate.Infra.IoC.AutoMapper.Importacao;
using TesteTemplate.Infra.IoC.AutoMapper.Pedido;
using TesteTemplate.Service;

namespace TesteTemplate.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {


            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new PedidoProfile());
                mc.AddProfile(new ImportacaoProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<IServiceImportacao, ServiceImportacao>();
            services.AddScoped<IRepositoryImportacao, RepositoryImportacao>();
            services.AddScoped<TesteTemplateContext>();
            services.AddScoped<Presenter>();

            return services;
        }
    }
}
