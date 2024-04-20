﻿// <auto-generated />
using System;
using Attendance_Time_tracking_System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Attendance_Time_tracking_System.Migrations
{
    [DbContext(typeof(AttendanceSysDbContext))]
    partial class AttendanceSysDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Attendance_Time_tracking_System.Models.Attendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<TimeOnly?>("TimeIn")
                        .HasColumnType("time");

                    b.Property<TimeOnly?>("TimeOut")
                        .HasColumnType("time");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("Attendance_Time_tracking_System.Models.Branch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Branchs");
                });

            modelBuilder.Entity("Attendance_Time_tracking_System.Models.Intake", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("EndDate")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("Intakes");
                });

            modelBuilder.Entity("Attendance_Time_tracking_System.Models.Permission", b =>
                {
                    b.Property<int>("StdId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("StdId", "Date");

                    b.ToTable("permissions");
                });

            modelBuilder.Entity("Attendance_Time_tracking_System.Models.ProgramType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("Duration")
                        .HasColumnType("real");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Programs");
                });

            modelBuilder.Entity("Attendance_Time_tracking_System.Models.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<TimeOnly>("EndTime")
                        .HasColumnType("time");

                    b.Property<TimeOnly>("StartTime")
                        .HasColumnType("time");

                    b.Property<string>("Subject")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("Attendance_Time_tracking_System.Models.StudentTrackIntake", b =>
                {
                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.Property<int>("TrackID")
                        .HasColumnType("int");

                    b.Property<int>("AbsenceDays")
                        .HasColumnType("int");

                    b.Property<int>("IntakeID")
                        .HasColumnType("int");

                    b.Property<int>("LateDays")
                        .HasColumnType("int");

                    b.HasKey("StudentID", "TrackID");

                    b.HasIndex("IntakeID");

                    b.HasIndex("TrackID");

                    b.ToTable("StudentTrackIntakes");
                });

            modelBuilder.Entity("Attendance_Time_tracking_System.Models.Track", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ProgramID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProgramID");

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("Attendance_Time_tracking_System.Models.TrackSchedule", b =>
                {
                    b.Property<int>("ScheduleID")
                        .HasColumnType("int");

                    b.Property<int>("IntakeID")
                        .HasColumnType("int");

                    b.Property<int>("BranchID")
                        .HasColumnType("int");

                    b.Property<int>("TrackID")
                        .HasColumnType("int");

                    b.HasKey("ScheduleID", "IntakeID");

                    b.HasIndex("BranchID");

                    b.HasIndex("IntakeID");

                    b.HasIndex("TrackID");

                    b.ToTable("TrackSchedules");
                });

            modelBuilder.Entity("Attendance_Time_tracking_System.Models.TrackSupervisor", b =>
                {
                    b.Property<int>("InstructorID")
                        .HasColumnType("int");

                    b.Property<int>("IntakeID")
                        .HasColumnType("int");

                    b.Property<int>("BranchID")
                        .HasColumnType("int");

                    b.Property<int>("TrackID")
                        .HasColumnType("int");

                    b.HasKey("InstructorID", "IntakeID");

                    b.HasIndex("BranchID");

                    b.HasIndex("IntakeID");

                    b.HasIndex("TrackID");

                    b.ToTable("TrackSupervisors");
                });

            modelBuilder.Entity("Attendance_Time_tracking_System.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<long>("Mobile")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.ToTable("Users");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Attendance_Time_tracking_System.Models.Employee", b =>
                {
                    b.HasBaseType("Attendance_Time_tracking_System.Models.User");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Attendance_Time_tracking_System.Models.Instructor", b =>
                {
                    b.HasBaseType("Attendance_Time_tracking_System.Models.User");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("Attendance_Time_tracking_System.Models.Student", b =>
                {
                    b.HasBaseType("Attendance_Time_tracking_System.Models.User");

                    b.Property<string>("Faculty")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("GradYear")
                        .HasColumnType("int");

                    b.Property<string>("Specialization")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("University")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Attendance_Time_tracking_System.Models.Attendance", b =>
                {
                    b.HasOne("Attendance_Time_tracking_System.Models.User", "User")
                        .WithMany("Attendances")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Attendance_Time_tracking_System.Models.Permission", b =>
                {
                    b.HasOne("Attendance_Time_tracking_System.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Attendance_Time_tracking_System.Models.StudentTrackIntake", b =>
                {
                    b.HasOne("Attendance_Time_tracking_System.Models.Intake", "Intake")
                        .WithMany()
                        .HasForeignKey("IntakeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Attendance_Time_tracking_System.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Attendance_Time_tracking_System.Models.Track", "Track")
                        .WithMany()
                        .HasForeignKey("TrackID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Intake");

                    b.Navigation("Student");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("Attendance_Time_tracking_System.Models.Track", b =>
                {
                    b.HasOne("Attendance_Time_tracking_System.Models.ProgramType", "ProgramType")
                        .WithMany("Tracks")
                        .HasForeignKey("ProgramID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProgramType");
                });

            modelBuilder.Entity("Attendance_Time_tracking_System.Models.TrackSchedule", b =>
                {
                    b.HasOne("Attendance_Time_tracking_System.Models.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Attendance_Time_tracking_System.Models.Intake", "Intake")
                        .WithMany()
                        .HasForeignKey("IntakeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Attendance_Time_tracking_System.Models.Schedule", "Schedule")
                        .WithMany("TrackSchedules")
                        .HasForeignKey("ScheduleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Attendance_Time_tracking_System.Models.Track", "Track")
                        .WithMany()
                        .HasForeignKey("TrackID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");

                    b.Navigation("Intake");

                    b.Navigation("Schedule");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("Attendance_Time_tracking_System.Models.TrackSupervisor", b =>
                {
                    b.HasOne("Attendance_Time_tracking_System.Models.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Attendance_Time_tracking_System.Models.Instructor", "Instructor")
                        .WithMany()
                        .HasForeignKey("InstructorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Attendance_Time_tracking_System.Models.Intake", "Intake")
                        .WithMany()
                        .HasForeignKey("IntakeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Attendance_Time_tracking_System.Models.Track", "Track")
                        .WithMany()
                        .HasForeignKey("TrackID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");

                    b.Navigation("Instructor");

                    b.Navigation("Intake");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("Attendance_Time_tracking_System.Models.User", b =>
                {
                    b.HasOne("Attendance_Time_tracking_System.Models.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");
                });

            modelBuilder.Entity("Attendance_Time_tracking_System.Models.Employee", b =>
                {
                    b.HasOne("Attendance_Time_tracking_System.Models.User", null)
                        .WithOne()
                        .HasForeignKey("Attendance_Time_tracking_System.Models.Employee", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Attendance_Time_tracking_System.Models.Instructor", b =>
                {
                    b.HasOne("Attendance_Time_tracking_System.Models.User", null)
                        .WithOne()
                        .HasForeignKey("Attendance_Time_tracking_System.Models.Instructor", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Attendance_Time_tracking_System.Models.Student", b =>
                {
                    b.HasOne("Attendance_Time_tracking_System.Models.User", null)
                        .WithOne()
                        .HasForeignKey("Attendance_Time_tracking_System.Models.Student", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Attendance_Time_tracking_System.Models.ProgramType", b =>
                {
                    b.Navigation("Tracks");
                });

            modelBuilder.Entity("Attendance_Time_tracking_System.Models.Schedule", b =>
                {
                    b.Navigation("TrackSchedules");
                });

            modelBuilder.Entity("Attendance_Time_tracking_System.Models.User", b =>
                {
                    b.Navigation("Attendances");
                });
#pragma warning restore 612, 618
        }
    }
}
