using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DinnerClub.Data;
using DinnerClub.Enums;

namespace DinnerClub.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20170423201459_1")]
    partial class _1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DinnerClub.Data.Entities.Event", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<Guid>("RestaurantID");

                    b.HasKey("ID");

                    b.HasIndex("RestaurantID");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("DinnerClub.Data.Entities.EventAttendance", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("EventID");

                    b.Property<Guid>("PersonID");

                    b.Property<int>("Response");

                    b.HasKey("ID");

                    b.HasIndex("EventID");

                    b.HasIndex("PersonID");

                    b.ToTable("EventAttendance");
                });

            modelBuilder.Entity("DinnerClub.Data.Entities.Family", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FamilyName");

                    b.HasKey("ID");

                    b.ToTable("Families");
                });

            modelBuilder.Entity("DinnerClub.Data.Entities.Person", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<Guid?>("FamilyID");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("ID");

                    b.HasIndex("FamilyID");

                    b.ToTable("People");
                });

            modelBuilder.Entity("DinnerClub.Data.Entities.Restaurant", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address1");

                    b.Property<string>("Address2");

                    b.Property<string>("City");

                    b.Property<string>("Name");

                    b.Property<string>("State");

                    b.Property<string>("Website");

                    b.Property<string>("Zip");

                    b.HasKey("ID");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("DinnerClub.Data.Entities.Event", b =>
                {
                    b.HasOne("DinnerClub.Data.Entities.Restaurant", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DinnerClub.Data.Entities.EventAttendance", b =>
                {
                    b.HasOne("DinnerClub.Data.Entities.Event", "Event")
                        .WithMany("Attendance")
                        .HasForeignKey("EventID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DinnerClub.Data.Entities.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DinnerClub.Data.Entities.Person", b =>
                {
                    b.HasOne("DinnerClub.Data.Entities.Family", "Family")
                        .WithMany("Members")
                        .HasForeignKey("FamilyID");
                });
        }
    }
}
