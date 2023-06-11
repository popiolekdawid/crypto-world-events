using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
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
            //Tutaj zmieniamy dostepnosc do bazy
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
            var startup = new Startup(builder.Configuration);
            startup.ConfigureServices(builder.Services);
            var app = builder.Build();
            startup.Configure(app);
            app.Run();





        }

    }
}