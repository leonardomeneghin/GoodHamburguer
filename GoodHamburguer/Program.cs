
using GoodHamburguerAPI.db.Services;
using GoodHamburguerAPI.Helper;
using Infrastructure.Model.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Sinks.MSSqlServer.Sinks.MSSqlServer.Options;
using System.Configuration;

namespace GoodHamburguerAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.Services.AddControllers();
            //Log configs
            var connection = builder.Configuration["SQLServerConnection:SQLServerConnectionString"] ?? throw new Exception("Must define connection string");

            var sinkOptions = new SerilogConfigurationHelper().BuildSinkOptions(SerilogConfigurationHelper.GOOD_HAMBURGUER_TABLE_LOG);
            Log.Logger = new LoggerConfiguration()
            .WriteTo.MSSqlServer(connection, sinkOptions)
            .CreateLogger();

            //add dbcontext here

            builder.Services.AddDbContext<MSSQLContext>(options => options.UseSqlServer(connection));

            //migrations
            if (builder.Environment.IsDevelopment())
            {
                ServiceMigration.MigrateDataBase(connection);
            }
            //add dependency injection here

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            //See "ApiVersioning" at readme.md
            builder.Services.AddApiVersioning(x =>
            {
                x.DefaultApiVersion = new ApiVersion(1, 0);
                x.AssumeDefaultVersionWhenUnspecified = true;
                x.ReportApiVersions = true;
            }); 
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
