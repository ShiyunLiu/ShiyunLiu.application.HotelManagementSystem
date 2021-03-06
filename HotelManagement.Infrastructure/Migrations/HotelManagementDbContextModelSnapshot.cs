// <auto-generated />
using System;
using HotelManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HotelManagement.Infrastructure.Migrations
{
    [DbContext(typeof(HotelManagementDbContext))]
    partial class HotelManagementDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HotelManagement.Core.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("ADDRESS");

                    b.Property<decimal?>("Advance")
                        .HasColumnType("Money")
                        .HasColumnName("ADVANCE");

                    b.Property<int?>("BookingDays")
                        .HasColumnType("int");

                    b.Property<string>("CName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("CNAME");

                    b.Property<DateTime?>("CheckIn")
                        .HasColumnType("datetime2")
                        .HasColumnName("CHECKIN");

                    b.Property<string>("Email")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("EMAIL");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("PHONE");

                    b.Property<int?>("RoomId")
                        .HasColumnType("int")
                        .HasColumnName("ROOMNO");

                    b.Property<int?>("TotalPersons")
                        .HasColumnType("int")
                        .HasColumnName("TotalPERSONS");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("CUSTOMERS");
                });

            modelBuilder.Entity("HotelManagement.Core.Entities.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("RoomTypeId")
                        .HasColumnType("int")
                        .HasColumnName("RTCODE");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit")
                        .HasColumnName("STATUS");

                    b.HasKey("Id");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("ROOMS");
                });

            modelBuilder.Entity("HotelManagement.Core.Entities.RoomType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("Rent")
                        .HasColumnType("Money");

                    b.Property<string>("RtDesc")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("RTDESC");

                    b.HasKey("Id");

                    b.ToTable("ROOMTYPES");
                });

            modelBuilder.Entity("HotelManagement.Core.Entities.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("Amount")
                        .HasColumnType("Money")
                        .HasColumnName("AMOUNT");

                    b.Property<int?>("RoomId")
                        .HasColumnType("int")
                        .HasColumnName("ROOMNO");

                    b.Property<string>("SDesc")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("SDESC");

                    b.Property<DateTime?>("ServiceDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("SERVICES");
                });

            modelBuilder.Entity("HotelManagement.Core.Entities.Customer", b =>
                {
                    b.HasOne("HotelManagement.Core.Entities.Room", "Room")
                        .WithMany("Customers")
                        .HasForeignKey("RoomId");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("HotelManagement.Core.Entities.Room", b =>
                {
                    b.HasOne("HotelManagement.Core.Entities.RoomType", "RoomType")
                        .WithMany("Rooms")
                        .HasForeignKey("RoomTypeId");

                    b.Navigation("RoomType");
                });

            modelBuilder.Entity("HotelManagement.Core.Entities.Service", b =>
                {
                    b.HasOne("HotelManagement.Core.Entities.Room", "Room")
                        .WithMany("Services")
                        .HasForeignKey("RoomId");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("HotelManagement.Core.Entities.Room", b =>
                {
                    b.Navigation("Customers");

                    b.Navigation("Services");
                });

            modelBuilder.Entity("HotelManagement.Core.Entities.RoomType", b =>
                {
                    b.Navigation("Rooms");
                });
#pragma warning restore 612, 618
        }
    }
}
