using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using zohocrm3._0.Models;

namespace zohocrm3._0.Data
{
    public class ZohoDbContext : DbContext
    {
        public DbSet<Lead> Leads { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Apptask> Tasks { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Email> Emails { get; set; }

        public ZohoDbContext(DbContextOptions<ZohoDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Lead>()
            .HasOne(ac => ac.Account)
            .WithMany(acc => acc.Leads)
            .HasForeignKey(ac => ac.AccountId)
            .OnDelete(DeleteBehavior.Restrict); // Use Restrict or No Action

            modelBuilder.Entity<Lead>()
            .HasOne(ac => ac.Activity)
            .WithMany(acc => acc.Leads)
            .HasForeignKey(ac => ac.AccountId)
            .OnDelete(DeleteBehavior.Restrict); // Use Restrict or No Action

            modelBuilder.Entity<Lead>()
            .HasOne(ac => ac.Apptask)
            .WithMany(acc => acc.Leads)
            .HasForeignKey(ac => ac.ApptaskId)
            .OnDelete(DeleteBehavior.Restrict); // Use Restrict or No Action

            modelBuilder.Entity<Lead>()
            .HasOne(ac => ac.Campaign)
            .WithMany(acc => acc.Leads)
            .HasForeignKey(ac => ac.CampaignId)
            .OnDelete(DeleteBehavior.Restrict); // Use Restrict or No Action

            modelBuilder.Entity<Lead>()
            .HasOne(ac => ac.Contact)
            .WithMany(acc => acc.Leads)
            .HasForeignKey(ac => ac.ContactId)
            .OnDelete(DeleteBehavior.Restrict); // Use Restrict or No Action

            modelBuilder.Entity<Lead>()
            .HasOne(ac => ac.Deal)
            .WithMany(acc => acc.Leads)
            .HasForeignKey(ac => ac.DealId)
            .OnDelete(DeleteBehavior.Restrict); // Use Restrict or No Action

            modelBuilder.Entity<Lead>()
            .HasOne(ac => ac.Email)
            .WithMany(acc => acc.Leads)
            .HasForeignKey(ac => ac.EmailId)
            .OnDelete(DeleteBehavior.Restrict); // Use Restrict or No Action

            modelBuilder.Entity<Lead>()
            .HasOne(ac => ac.Invoice)
            .WithMany(acc => acc.Leads)
            .HasForeignKey(ac => ac.InvoiceId)
            .OnDelete(DeleteBehavior.Restrict); // Use Restrict or No Action

            modelBuilder.Entity<Lead>()
            .HasOne(ac => ac.Quote)
            .WithMany(acc => acc.Leads)
            .HasForeignKey(ac => ac.QuoteId)
            .OnDelete(DeleteBehavior.Restrict); // Use Restrict or No Action
        }
    }
}