using Microsoft.EntityFrameworkCore;
using SegundaAPINullo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegundaAPINullo.Data
{
    //representação do banco de dados, e da memória
   //cria a classe e herda de db
    public class DataContext : DbContext
    {
        //método construtor
        public DataContext(DbContextOptions<DbContext>options)
            : base(options)
        {
            
        }

        //atributos/tabelas
        public DbSet<Product> Porducts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
       
    }
}
