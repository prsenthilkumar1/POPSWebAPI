﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace POPSWebApi
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class POPSEntities : DbContext
    {
        public POPSEntities()
            : base("name=POPSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ITEM> ITEMs { get; set; }
        public virtual DbSet<PODETAIL> PODETAILs { get; set; }
        public virtual DbSet<POMASTER> POMASTERs { get; set; }
        public virtual DbSet<SUPPLIER> SUPPLIERs { get; set; }
    }
}
