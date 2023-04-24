using Hotel.API.Extensions;
using Hotel.API.Middlewares;
using Hotel.Application;
using Hotel.Infrastructure;

namespace Hotel.API
{
    internal class Program
    {
        private static void Main( string[] args )
        {
            var builder = WebApplication.CreateBuilder( args );

            builder.Services.AddSqlContext( builder.Configuration );

            builder.Services.AddControllers();

            builder.Services.AddApplication();
            builder.Services.AddInfrastructure();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.AddExceptionHandler();

            if ( app.Environment.IsDevelopment() )
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}