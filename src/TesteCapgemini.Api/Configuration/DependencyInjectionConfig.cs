using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using TesteCapgemini.Api.Controllers.Base;
using TesteCapgemini.Domain.Entities;
using TesteCapgemini.Domain.Interfaces.Repositories;
using TesteCapgemini.Domain.Interfaces.Services;
using TesteCapgemini.Domain.Services;
using TesteCapgemini.Infra.Data.Persistence;
using TesteCapgemini.Infra.Data.Persistence.Repositories;
using TesteCapgemini.Infra.IoC.AutoMapper.Pedido;

namespace TesteCapgemini.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {


            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new PedidoProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<IServiceImportacao, ServiceImportacao>();
            services.AddScoped<IRepositoryImportacao, RepositoryImportacao>();
            services.AddScoped<TesteCapgeminiContext>();
            services.AddScoped<Presenter>();

            return services;
        }
    }
}
