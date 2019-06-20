﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReValuedCarsAPI.Intrastructures;

namespace ReValuedCarsAPI.Migrations
{
    [DbContext(typeof(ReValuedCarsDbContext))]
    [Migration("20190620111702_updatelatestchanges")]
    partial class updatelatestchanges
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ReValuedCarsAPI.Models.CarImages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarID");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("CarImages");
                });

            modelBuilder.Entity("ReValuedCarsAPI.Models.Cars", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityID");

                    b.Property<int>("FuelTypeID");

                    b.Property<int>("InsuranceTypeID");

                    b.Property<int>("KilometersDriven");

                    b.Property<int>("MakeID");

                    b.Property<int>("ModelID");

                    b.Property<string>("Name");

                    b.Property<int>("OwnerTypeID");

                    b.Property<int>("PinCode");

                    b.Property<int>("Price");

                    b.Property<string>("RegistrationNumber");

                    b.Property<int>("RegistrationTypeID");

                    b.Property<int>("StateID");

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("ReValuedCarsAPI.Models.FuelType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("FuelTypes");
                });

            modelBuilder.Entity("ReValuedCarsAPI.Models.InsuranceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("InsuranceTypes");
                });

            modelBuilder.Entity("ReValuedCarsAPI.Models.Make", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Makes");
                });

            modelBuilder.Entity("ReValuedCarsAPI.Models.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ABS");

                    b.Property<string>("AirConditioner");

                    b.Property<string>("Airbags");

                    b.Property<string>("CentralLocking");

                    b.Property<string>("Displacement");

                    b.Property<string>("FuelType");

                    b.Property<string>("Height");

                    b.Property<string>("Length");

                    b.Property<int>("MakeID");

                    b.Property<string>("MaxPower");

                    b.Property<string>("Mileage");

                    b.Property<string>("Name");

                    b.Property<string>("NoofGears");

                    b.Property<string>("PowerWindows");

                    b.Property<string>("SeatingCapacity");

                    b.Property<string>("TransmissionType");

                    b.Property<string>("Width");

                    b.HasKey("Id");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("ReValuedCarsAPI.Models.OwnerType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("OwnerTypes");
                });

            modelBuilder.Entity("ReValuedCarsAPI.Models.RegistrationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("RegistrationTypes");
                });

            modelBuilder.Entity("ReValuedCarsAPI.Models.ViewedCars", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarID");

                    b.Property<string>("Message");

                    b.Property<int>("QuotePrice");

                    b.Property<int>("UserID");

                    b.HasKey("Id");

                    b.ToTable("ViewedCars");
                });
#pragma warning restore 612, 618
        }
    }
}
