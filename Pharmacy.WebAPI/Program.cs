using Pharmacy.Business;

namespace Pharmacy.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();
            builder.Services.AddControllers();

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
                    policy.WithOrigins("http://localhost:4200", "https://localhost:4200")
                    .AllowAnyHeader().AllowAnyMethod();//  clientin browser üzerinde çalıştığı addresler ve hostlar burada veriyoruz 
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
            //add for cors middleware specific name
            app.UseCors("allowSpecificOrigins");

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}