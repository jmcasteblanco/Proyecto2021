﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proyecto2021.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class inventariop2021Entities : DbContext
    {
        public inventariop2021Entities()
            : base("name=inventariop2021Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<cliente> cliente { get; set; }
        public virtual DbSet<compra> compra { get; set; }
        public virtual DbSet<producto> producto { get; set; }
        public virtual DbSet<producto_compra> producto_compra { get; set; }
        public virtual DbSet<producto_imagen> producto_imagen { get; set; }
        public virtual DbSet<proveedor> proveedor { get; set; }
        public virtual DbSet<roles> roles { get; set; }
        public virtual DbSet<usuario> usuario { get; set; }
        public virtual DbSet<usuariorol> usuariorol { get; set; }
    }
}
