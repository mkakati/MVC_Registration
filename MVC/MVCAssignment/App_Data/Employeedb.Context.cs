﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCAssignment.App_Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class sdirecttestdbEntities : DbContext
    {
        public sdirecttestdbEntities()
            : base("name=sdirecttestdbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<EmployeesDB> EmployeesDBs { get; set; }
        public virtual DbSet<EmployeesCountry> EmployeesCountries { get; set; }
        public virtual DbSet<EmployeesState> EmployeesStates { get; set; }
    }
}