﻿using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using SuporteSF.Domain.Entities;
using SuporteSF.Infra.Data.EntityConfig;

namespace SuporteSF.Infra.Data.Context
{
    public class SuporteContext : BaseDbContext
    {
        public SuporteContext()
            : base("SuporteContext")
        {
            //this.Configuration.LazyLoadingEnabled = false;
            //this.Configuration.ProxyCreationEnabled = false;
        }

        public IDbSet<Suporte> Suportes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Conventions
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            
            // General Custom Context Properties
            //modelBuilder.Properties()
            //    .Where(p => p.Name == "Id" + p.ReflectedType.Name)
            //    .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));
            
            // ModelConfiguration
            modelBuilder.Configurations.Add(new SuporteConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            //foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            //{
            //    if (entry.State == EntityState.Added)
            //    {
            //        entry.Property("DataCadastro").CurrentValue = DateTime.Now;
            //    }

            //    if (entry.State == EntityState.Modified)
            //    {
            //        entry.Property("DataCadastro").IsModified = false;
            //    }
            //}
            return base.SaveChanges();
        }
    }
}
