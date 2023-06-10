using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;

namespace WebApplication1
{
    [Table("prices")]
    public class Price
    {
        public int Id { get; set; }
        public string date { get; set; }
        public string price { get; set; }
    }
    public class MyDbContext : DbContext
    {
        public DbSet<Price> Prices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Database=ethereum;Uid=root;Pwd=;", new MySqlServerVersion(new Version(8, 0, 26)));
        }
    }
    public class RequestModel
    {
        public int Value { get; set; }
    }
    public class Program
    {

        public static void Main(string[] args)
        {
           
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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