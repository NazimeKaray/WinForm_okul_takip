﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace proje_ogrenci_ogretmen.entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ogrenci_sinavEntities : DbContext
    {
        public ogrenci_sinavEntities()
            : base("name=ogrenci_sinavEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ders> ders { get; set; }
        public virtual DbSet<ogrenci> ogrenci { get; set; }
        public virtual DbSet<ogretmen> ogretmen { get; set; }
        public virtual DbSet<sinif> sinif { get; set; }
        public virtual DbSet<notlar> notlar { get; set; }
    }
}
