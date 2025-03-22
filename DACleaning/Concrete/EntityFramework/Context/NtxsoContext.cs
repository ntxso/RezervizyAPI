using CleaningEntities;
using Core.Entities.Concrete;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;
using CoreNT.Entities;

namespace DACleaning.Concrete.EntityFramework.Context
{
    public class NtxsoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"server=mssql04.trwww.com; initial catalog=ntxs6308_ntxsocom; User ID=ntxso; Password=138181.Nt");
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=rezervizy;Integrated Security=True;Connect Timeout=30;");
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<AddressCustomer> Addresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Quarter> Quarters { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<CustomerNote> CustomerNotes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<LogEntity> LogCleaning { get; set; }
        public DbSet<SupplierParameter> SupplierDefault { get; set; }

    }



}
