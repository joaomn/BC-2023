using AgendaBlue.Data;

using AgendaBlue.Interfaces;

using AgendaBlue.Repositorys;
using AgendaBlue.Services;
using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using AgendaBlue;

internal class Program
{
    private static void Main(string[] args)

    { 
        var builder = WebApplication.CreateBuilder(args);


       //  Add services to the container.
         var connectionStringMysql = builder.Configuration.GetConnectionString("ConecxaoMysql");
         builder.Services.AddDbContext<AGDDbContext>(options => options.UseMySql(
          connectionStringMysql,
         ServerVersion.Parse("8.0.31")));

      


        builder.Services.AddControllers();
       
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddCors();

        builder.Services.AddScoped<IAgendaRepository, AgendaRepositoy>();
        builder.Services.AddScoped<IAgendaService, AgendaService>();






        var app = builder.Build();



        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }



        app.UseCors(c =>
        {

            c.AllowAnyHeader();
            c.AllowAnyMethod();
            c.AllowAnyOrigin();
        });


        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}