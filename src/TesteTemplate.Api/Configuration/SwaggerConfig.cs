using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace TesteTemplate.Api.Configuration
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(c => {

                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Teste Template",
                        Version = "v1",
                        Description = "Teste Template para importação de dados",
                        Contact = new OpenApiContact
                        {
                            Name = "Anderson Pereira"
                            
                        }
                    });
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Teste Template");
            });

            return app;
        }


    }
}
