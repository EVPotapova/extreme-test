﻿// <auto-generated />
using Extreme_Test.Data;
using Extreme_Test.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Extreme_Test.Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20180203080753_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("Extreme_Test.Models.VacancyDbModel", b =>
                {
                    b.Property<int>("E1Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Desc");

                    b.Property<int>("Experience");

                    b.Property<string>("Header")
                        .IsRequired();

                    b.Property<string>("LinkToE1")
                        .IsRequired();

                    b.Property<decimal>("SalaryMax");

                    b.Property<decimal>("SalaryMin");

                    b.Property<int>("Schedule");

                    b.Property<int>("WorkingType");

                    b.HasKey("E1Id");

                    b.ToTable("Vacancies");
                });
#pragma warning restore 612, 618
        }
    }
}
