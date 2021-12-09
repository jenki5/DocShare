using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Scaffolding;

namespace DocShare.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options){}        
        public DbSet<AdminLevel> AdminLevels {get;set;}
        public DbSet<CaseLog> CaseLogs {get;set;}
        public DbSet<CaseNote> CaseNotes {get;set;}
        public DbSet<CompanyCase> CompanyCases{get;set;}
        public DbSet<Company> Companies {get;set;}
        public DbSet<CompanyType> CompanyTypes {get;set;}
        public DbSet<FriendCompany> FriendCompanies {get;set;}
        public DbSet<PatientCase> PatientCases {get;set;}
        public DbSet<UploadFile> UploadFiles {get;set;}
        public DbSet<User> Users {get;set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FriendCompany>().HasOne<Company>(c => c.Company).WithMany(c => c.Companies).HasForeignKey(c => c.CompanyID);
            modelBuilder.Entity<FriendCompany>().HasOne<Company>(c => c.CompanyFriend).WithMany(c => c.FriendCompanies).HasForeignKey(c => c.FriendCompanyID);
            modelBuilder.Entity<FriendCompany>().HasKey(c => new { c.CompanyID, c.FriendCompanyID });
            modelBuilder.Entity<CompanyCase>().HasKey(c => new { c.CompanyID, c.PatientCaseID });
        }
    }    
}