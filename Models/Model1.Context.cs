﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Library_Management_System.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DB_LibraryEntities : DbContext
    {
        public DB_LibraryEntities()
            : base("name=DB_LibraryEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblAuthor> tblAuthors { get; set; }
        public virtual DbSet<tblCategory> tblCategories { get; set; }
        public virtual DbSet<tblPublisher> tblPublishers { get; set; }
        public virtual DbSet<tblMember> tblMembers { get; set; }
        public virtual DbSet<tblBook> tblBooks { get; set; }
        public virtual DbSet<tblIssueBook> tblIssueBooks { get; set; }
        public virtual DbSet<tblReturnBook> tblReturnBooks { get; set; }
        public virtual DbSet<tblUser> tblUsers { get; set; }
    }
}
