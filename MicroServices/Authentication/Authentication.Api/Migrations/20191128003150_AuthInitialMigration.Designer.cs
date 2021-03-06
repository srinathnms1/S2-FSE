﻿// <auto-generated />
using System;
using Authentication.Infrastracture;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Authentication.Api.Migrations
{
    [DbContext(typeof(AuthContext))]
    [Migration("20191128003150_AuthInitialMigration")]
    partial class AuthInitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Authentication.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<byte[]>("Password");

                    b.Property<byte[]>("Salt");

                    b.Property<bool>("Status");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime>("UpdatedOn");

                    b.Property<string>("UserType");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Authentication.Domain.UserInfo", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Mobile");

                    b.HasKey("UserId");

                    b.ToTable("UserInfo");
                });

            modelBuilder.Entity("Authentication.Domain.UserInfo", b =>
                {
                    b.HasOne("Authentication.Domain.User")
                        .WithOne("UserInfo")
                        .HasForeignKey("Authentication.Domain.UserInfo", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
