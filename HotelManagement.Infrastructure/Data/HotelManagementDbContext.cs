using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;
using HotelManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelManagement.Infrastructure.Data
{
    public class HotelManagementDbContext : DbContext
    {
        public HotelManagementDbContext(DbContextOptions<HotelManagementDbContext>options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Service> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(ConfigureCustomer);
            modelBuilder.Entity<Room>(ConfigureRoom);
            modelBuilder.Entity<RoomType>(ConfigureRoomType);
            modelBuilder.Entity<Service>(ConfigureService);
        }

        private void ConfigureService(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("SERVICES");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).HasColumnName("ID");
            builder.Property(s => s.SDesc).HasMaxLength(50);
            builder.Property(s => s.SDesc).HasColumnName("SDESC");
            builder.Property(s => s.Amount).HasColumnName("AMOUNT");
            builder.Property(s => s.Amount).HasColumnType("Money");
        }

        private void ConfigureRoomType(EntityTypeBuilder<RoomType> builder)
        {
            builder.ToTable("ROOMTYPES");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.RtDesc).HasColumnName("RTDESC");
            builder.Property(t => t.RtDesc).HasMaxLength(20);
            builder.Property(t => t.Rent).HasColumnType("Money");
        }

        private void ConfigureRoom(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("ROOMS");
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Status).HasColumnName("STATUS");
        }

        private void ConfigureCustomer(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("CUSTOMERS");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.CName).HasMaxLength(20);
            builder.Property(c => c.CName).HasColumnName("CNAME");
            builder.Property(c => c.Address).HasMaxLength(100);
            builder.Property(c => c.Address).HasColumnName("ADDRESS");
            builder.Property(c => c.Phone).HasMaxLength(20);
            builder.Property(c => c.Phone).HasColumnName("PHONE");
            builder.Property(c => c.Email).HasMaxLength(40);
            builder.Property(c => c.Email).HasColumnName("EMAIL");
            builder.Property(c => c.CheckIn).HasColumnName("CHECKIN");
            builder.Property(c => c.TotalPersons).HasColumnName("TotalPERSONS");
            builder.Property(c => c.Advance).HasColumnType("Money");
            builder.Property(c => c.Advance).HasColumnName("ADVANCE");
        }
    }

}
