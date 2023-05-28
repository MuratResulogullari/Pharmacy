using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Business;
using Pharmacy.Business.Mvc.ModelHandler;
using Pharmacy.Core.Validators.Pharmacies;
using System.Reflection;
using Twilio.Rest.Api.V2010.Account;
using Pharmacy.Business.Mvc.Filters;

namespace Pharmacy.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers(options=>options.Filters.Add<ValidationFilter>()).AddFluentValidation(configuration=>
            configuration.RegisterValidatorsFromAssemblyContaining<PharmacyDTOValidator>())
               .ConfigureApiBehaviorOptions(options=>options.SuppressModelStateInvalidFilter=true);
           // Add Fluent Validation

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region Add Services on IoC

            builder.Services.AddPersistenceServices();

            #endregion Add Services on IoC

            #region Add Specific Cors

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("allowSpecificOrigins",
                policy =>
                {
                    policy.WithOrigins("https://localhost:4200", "http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
                });
            });

            #endregion Add Specific Cors

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("allowSpecificOrigins");
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}