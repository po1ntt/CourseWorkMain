﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kursach
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class VictrovinaEntities : DbContext
    {
        public VictrovinaEntities()
            : base("name=VictrovinaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Results> Results { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Answers> Answers { get; set; }
        public virtual DbSet<CathegoryTests> CathegoryTests { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Tests> Tests { get; set; }
    }
}
