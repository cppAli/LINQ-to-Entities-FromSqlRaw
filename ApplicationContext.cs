using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LINQ_to_Entities_191123_FromSqlRaw
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Company> companies { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = DESKTOP-2T5NU5R; Initial Catalog = LINQ_to_Entities_191123_FromSqlRaw; Trusted_Connection = true; TrustServerCertificate = True");
        }

        //Здесь добавлен метод GetUsersByAge(), который соответствует хранимо функции в БД
        public IQueryable<User> GetUsersByAge(int age) => FromExpression(() => GetUsersByAge(age));

        protected override void OnModelCreating(ModelBuilder modelBuilder) //метод класса контекста
        {
            modelBuilder.HasDbFunction(() => //регистрация метода  GetUsersByAge с помощью вызова HasDbFunction():
            GetUsersByAge(default));
        }
        //вернутся к классу реализвации
    }
}
