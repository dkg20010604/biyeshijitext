using System;
using System.Collections.Generic;
using DOEMTEXT.Models;
using Microsoft.EntityFrameworkCore;

namespace DOEMTEXT.Context;

public partial class StudentContext : DbContext
{
    public StudentContext()
    {
    }

    public StudentContext(DbContextOptions<StudentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BaseClassInfo> BaseClassInfos { get; set; }

    public virtual DbSet<CollegeInfo> CollegeInfos { get; set; }

    public virtual DbSet<DetailedClassInfo> DetailedClassInfos { get; set; }

    public virtual DbSet<Diskeep> Diskeeps { get; set; }

    public virtual DbSet<Disskeepinformation> Disskeepinformations { get; set; }

    public virtual DbSet<DormitoryBuildingInfo> DormitoryBuildingInfos { get; set; }

    public virtual DbSet<LiveInfo> LiveInfos { get; set; }

    public virtual DbSet<LiveInfoOld> LiveInfoOlds { get; set; }

    public virtual DbSet<LiveInformation> LiveInformations { get; set; }

    public virtual DbSet<Lostthing> Lostthings { get; set; }

    public virtual DbSet<Noticething> Noticethings { get; set; }

    public virtual DbSet<RepairWork> RepairWorks { get; set; }

    public virtual DbSet<RoomInfo> RoomInfos { get; set; }

    public virtual DbSet<Score> Scores { get; set; }

    public virtual DbSet<ScoreOld> ScoreOlds { get; set; }

    public virtual DbSet<ScoreStudent> ScoreStudents { get; set; }

    public virtual DbSet<StudentsInfo> StudentsInfos { get; set; }

    public virtual DbSet<StudentsInformation> StudentsInformations { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<Traffic> Traffics { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DESKTOP-54954D6\\SQLEXPRESS;Database=DORMITORY;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BaseClassInfo>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PK__BASE_CLA__32F54A3CB64CF8A4");

            entity.ToTable("BASE_CLASS_INFO", tb => tb.HasComment("基本班级信息"));

            entity.Property(e => e.ClassId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("班级代码")
                .HasColumnName("CLASS_ID");
            entity.Property(e => e.ClassName)
                .HasMaxLength(90)
                .IsUnicode(false)
                .HasComment("班级名称")
                .HasColumnName("CLASS_NAME");
            entity.Property(e => e.CollegeId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("学院代码")
                .HasColumnName("COLLEGE_ID");
            entity.Property(e => e.Status)
                .HasComment("状态（是否启用）")
                .HasColumnName("STATUS");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("更新人")
                .HasColumnName("UPDATED_BY");
            entity.Property(e => e.UpdatedTime)
                .HasComment("更新时间")
                .HasColumnType("datetime")
                .HasColumnName("UPDATED_TIME");
        });

        modelBuilder.Entity<CollegeInfo>(entity =>
        {
            entity.HasKey(e => e.CollegeId).HasName("PK__COLLEGE___F669C6802D4EA127");

            entity.ToTable("COLLEGE_INFO", tb => tb.HasComment("学院信息"));

            entity.Property(e => e.CollegeId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("学院代码")
                .HasColumnName("COLLEGE_ID");
            entity.Property(e => e.CollegeName)
                .HasMaxLength(90)
                .IsUnicode(false)
                .HasComment("学院名称")
                .HasColumnName("COLLEGE_NAME");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("更新人")
                .HasColumnName("UPDATED_BY");
            entity.Property(e => e.UpdatedTime)
                .HasComment("更新时间")
                .HasColumnType("datetime")
                .HasColumnName("UPDATED_TIME");
        });

        modelBuilder.Entity<DetailedClassInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DETAILED__3214EC27819AD9BE");

            entity.ToTable("DETAILED_CLASS_INFO", tb => tb.HasComment("详细班级信息"));

            entity.Property(e => e.Id)
                .HasComment("")
                .HasColumnName("ID");
            entity.Property(e => e.Additional)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasDefaultValueSql("('ORDINARY')")
                .HasComment("附加描述")
                .HasColumnName("ADDITIONAL");
            entity.Property(e => e.Class)
                .HasComment("班级")
                .HasColumnName("CLASS");
            entity.Property(e => e.ClassId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("班级代码")
                .HasColumnName("CLASS_ID");
            entity.Property(e => e.Grade)
                .HasComment("年级")
                .HasColumnName("GRADE");
            entity.Property(e => e.Headmaster)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("班主任")
                .HasColumnName("HEADMASTER");
            entity.Property(e => e.Instructor)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("辅导员")
                .HasColumnName("INSTRUCTOR");
            entity.Property(e => e.Nature)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasComment("本/专科")
                .HasColumnName("NATURE");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("更新人")
                .HasColumnName("UPDATED_BY");
            entity.Property(e => e.UpdatedTime)
                .HasComment("更新时间")
                .HasColumnType("datetime")
                .HasColumnName("UPDATED_TIME");

            entity.HasOne(d => d.ClassNavigation).WithMany(p => p.DetailedClassInfos)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DETAILED_CLASS_INFO_BASE_CLASS_INFO");

            entity.HasOne(d => d.HeadmasterNavigation).WithMany(p => p.DetailedClassInfoHeadmasterNavigations)
                .HasForeignKey(d => d.Headmaster)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DETAILED_CLASS_INFO_TEACHERS");

            entity.HasOne(d => d.InstructorNavigation).WithMany(p => p.DetailedClassInfoInstructorNavigations)
                .HasForeignKey(d => d.Instructor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DETAILED_CLASS_INFO_TEACHERS1");
        });

        modelBuilder.Entity<Diskeep>(entity =>
        {
            entity.ToTable("DISKEEP", tb => tb.HasComment("违纪记录"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DiskeepText)
                .HasComment("违规描述")
                .HasColumnType("text")
                .HasColumnName("DISKEEP_TEXT");
            entity.Property(e => e.DiskeepTime)
                .HasComment("违规时间")
                .HasColumnType("datetime")
                .HasColumnName("DISKEEP_TIME");
            entity.Property(e => e.DiskeepType)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasDefaultValueSql("('DIS_RETURN')")
                .HasComment("违规类型")
                .HasColumnName("DISKEEP_TYPE");
            entity.Property(e => e.StudentId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("学号")
                .HasColumnName("STUDENT_ID");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("更新人")
                .HasColumnName("UPDATED_BY");

            entity.HasOne(d => d.Student).WithMany(p => p.Diskeeps)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DISKEEP_STUDENTS_INFO");
        });

        modelBuilder.Entity<Disskeepinformation>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("DISSKEEPINFORMATION");

            entity.Property(e => e.Additional)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("ADDITIONAL");
            entity.Property(e => e.Class).HasColumnName("CLASS");
            entity.Property(e => e.ClassName)
                .HasMaxLength(90)
                .IsUnicode(false)
                .HasColumnName("CLASS_NAME");
            entity.Property(e => e.CollegeName)
                .HasMaxLength(90)
                .IsUnicode(false)
                .HasColumnName("COLLEGE_NAME");
            entity.Property(e => e.DiskeepText)
                .HasColumnType("text")
                .HasColumnName("DISKEEP_TEXT");
            entity.Property(e => e.DiskeepTime)
                .HasColumnType("datetime")
                .HasColumnName("DISKEEP_TIME");
            entity.Property(e => e.DiskeepType)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("DISKEEP_TYPE");
            entity.Property(e => e.Grade).HasColumnName("GRADE");
            entity.Property(e => e.Nature)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("NATURE");
            entity.Property(e => e.StudentId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("STUDENT_ID");
            entity.Property(e => e.StudentName)
                .HasMaxLength(90)
                .IsUnicode(false)
                .HasColumnName("STUDENT_NAME");
        });

        modelBuilder.Entity<DormitoryBuildingInfo>(entity =>
        {
            entity.HasKey(e => e.BuildId).HasName("PK__DORMITOR__8E753D001946B9D0");

            entity.ToTable("DORMITORY_BUILDING_INFO", tb => tb.HasComment("宿舍楼信息"));

            entity.Property(e => e.BuildId)
                .ValueGeneratedNever()
                .HasComment("楼号")
                .HasColumnName("BUILD_ID");
            entity.Property(e => e.BuildFloors)
                .HasComment("楼层数")
                .HasColumnName("BUILD_FLOORS");
            entity.Property(e => e.FloorRoomNumber)
                .HasComment("每层房间数")
                .HasColumnName("FLOOR_ROOM_NUMBER");
            entity.Property(e => e.ManageId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("管理人员")
                .HasColumnName("MANAGE_ID");
            entity.Property(e => e.RoomBed)
                .HasComment("房间床数")
                .HasColumnName("ROOM_BED");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("更新人")
                .HasColumnName("UPDATED_BY");
            entity.Property(e => e.UpdatedTime)
                .HasComment("更新时间")
                .HasColumnType("datetime")
                .HasColumnName("UPDATED_TIME");

            entity.HasOne(d => d.Manage).WithMany(p => p.DormitoryBuildingInfos)
                .HasForeignKey(d => d.ManageId)
                .HasConstraintName("FK_DORMITORY_BUILDING_INFO_TEACHERS");
        });

        modelBuilder.Entity<LiveInfo>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__LIVE_INF__E69FE77B372821A4");

            entity.ToTable("LIVE_INFO", tb => tb.HasComment("居住信息"));

            entity.HasIndex(e => e.Role, "ROLE_INDEX");

            entity.HasIndex(e => e.RoomId, "ROOM_INDEX");

            entity.HasIndex(e => e.StudentId, "STUDENT");

            entity.Property(e => e.StudentId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("学号")
                .HasColumnName("STUDENT_ID");
            entity.Property(e => e.BedId)
                .HasComment("床号")
                .HasColumnName("BED_ID");
            entity.Property(e => e.Role)
                .HasComment("宿舍角色")
                .HasColumnName("ROLE");
            entity.Property(e => e.RoomId)
                .HasComment("房间标识")
                .HasColumnName("ROOM_ID");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("更新人")
                .HasColumnName("UPDATED_BY");
            entity.Property(e => e.UpdatedTime)
                .HasComment("更新时间")
                .HasColumnType("datetime")
                .HasColumnName("UPDATED_TIME");

            entity.HasOne(d => d.Room).WithMany(p => p.LiveInfos)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LIVE_INFO_ROOM_INFO");
        });

        modelBuilder.Entity<LiveInfoOld>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("LIVE_INFO_OLD", tb => tb.HasComment("历史居住信息"));

            entity.Property(e => e.BedId)
                .HasComment("床号")
                .HasColumnName("BED_ID");
            entity.Property(e => e.Role)
                .HasComment("宿舍角色")
                .HasColumnName("ROLE");
            entity.Property(e => e.RoomId)
                .HasComment("房间标识")
                .HasColumnName("ROOM_ID");
            entity.Property(e => e.StudentId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("学号")
                .HasColumnName("STUDENT_ID");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("更新人")
                .HasColumnName("UPDATED_BY");
            entity.Property(e => e.UpdatedTime)
                .HasComment("更新时间")
                .HasColumnType("datetime")
                .HasColumnName("UPDATED_TIME");
            entity.Property(e => e.YearTerm)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasComment("年;yyyy-0/1")
                .HasColumnName("YEAR_TERM");
        });

        modelBuilder.Entity<LiveInformation>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("LIVE_INFORMATION");

            entity.Property(e => e.BedId).HasColumnName("BED_ID");
            entity.Property(e => e.BuildId).HasColumnName("BUILD_ID");
            entity.Property(e => e.ElectricityFees)
                .HasColumnType("decimal(24, 2)")
                .HasColumnName("ELECTRICITY_FEES");
            entity.Property(e => e.Gender)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("GENDER");
            entity.Property(e => e.IdentityCard)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("IDENTITY_CARD");
            entity.Property(e => e.ManageId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MANAGE_ID");
            entity.Property(e => e.Role)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("ROLE");
            entity.Property(e => e.RoomNumber).HasColumnName("ROOM_NUMBER");
            entity.Property(e => e.StudentId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("STUDENT_ID");
            entity.Property(e => e.StudentName)
                .HasMaxLength(90)
                .IsUnicode(false)
                .HasColumnName("STUDENT_NAME");
        });

        modelBuilder.Entity<Lostthing>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LOSTTHIN__3214EC270017D619");

            entity.ToTable("LOSTTHING", tb => tb.HasComment("失物招领信息"));

            entity.Property(e => e.Id)
                .HasComment("标识")
                .HasColumnName("ID");
            entity.Property(e => e.DownPerson)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("申领人员")
                .HasColumnName("DOWN_PERSON");
            entity.Property(e => e.DownTime)
                .HasComment("申领时间")
                .HasColumnType("datetime")
                .HasColumnName("DOWN_TIME");
            entity.Property(e => e.LostText)
                .HasMaxLength(900)
                .IsUnicode(false)
                .HasComment("失物信息")
                .HasColumnName("LOST_TEXT");
            entity.Property(e => e.Status)
                .HasComment("状态")
                .HasColumnName("STATUS");
            entity.Property(e => e.UpPerson)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("上交人员")
                .HasColumnName("UP_PERSON");
            entity.Property(e => e.UpTime)
                .HasComment("提交时间")
                .HasColumnType("datetime")
                .HasColumnName("UP_TIME");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("更新人")
                .HasColumnName("UPDATED_BY");
        });

        modelBuilder.Entity<Noticething>(entity =>
        {
            entity.HasKey(e => e.ThingId).HasName("PK__NOTICETH__141C04B8A1670E59");

            entity.ToTable("NOTICETHING", tb => tb.HasComment("公告"));

            entity.Property(e => e.ThingId)
                .HasComment("公告标识（唯一）")
                .HasColumnName("THING_ID");
            entity.Property(e => e.NoticeText)
                .HasMaxLength(900)
                .IsUnicode(false)
                .HasComment("公告内容")
                .HasColumnName("NOTICE_TEXT");
            entity.Property(e => e.Release)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("发布人")
                .HasColumnName("RELEASE");
            entity.Property(e => e.UpdatedTime)
                .HasComment("更新时间")
                .HasColumnType("datetime")
                .HasColumnName("UPDATED_TIME");
        });

        modelBuilder.Entity<RepairWork>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__REPAIR_W__3214EC2783CBD3EA");

            entity.ToTable("REPAIR_WORK", tb => tb.HasComment("维修事务"));

            entity.Property(e => e.Id)
                .HasComment("事件标识")
                .HasColumnName("ID");
            entity.Property(e => e.CreatedTime)
                .HasComment("创建时间")
                .HasColumnType("datetime")
                .HasColumnName("CREATED_TIME");
            entity.Property(e => e.DetailedInformation)
                .HasMaxLength(900)
                .IsUnicode(false)
                .HasComment("详细信息")
                .HasColumnName("DETAILED_INFORMATION");
            entity.Property(e => e.Handled)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("当前处理人")
                .HasColumnName("HANDLED");
            entity.Property(e => e.Status)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasDefaultValueSql("('已提交')")
                .HasComment("事件状态")
                .HasColumnName("STATUS");
            entity.Property(e => e.StudentId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("提交人学号/工号")
                .HasColumnName("STUDENT_ID");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("更新人")
                .HasColumnName("UPDATED_BY");
            entity.Property(e => e.UpdatedTime)
                .HasComment("更新时间")
                .HasColumnType("datetime")
                .HasColumnName("UPDATED_TIME");
        });

        modelBuilder.Entity<RoomInfo>(entity =>
        {
            entity.HasKey(e => e.RoomId);

            entity.ToTable("ROOM_INFO", tb => tb.HasComment("宿舍房间信息"));

            entity.HasIndex(e => e.BuildId, "BUILD_ID_INDEX");

            entity.Property(e => e.RoomId)
                .HasComment("房间标识")
                .HasColumnName("ROOM_ID");
            entity.Property(e => e.BedNumber)
                .HasComment("床数")
                .HasColumnName("BED_NUMBER");
            entity.Property(e => e.BuildId)
                .HasComment("楼号")
                .HasColumnName("BUILD_ID");
            entity.Property(e => e.ElectricityFees)
                .HasComment("电费")
                .HasColumnType("decimal(24, 2)")
                .HasColumnName("ELECTRICITY_FEES");
            entity.Property(e => e.RoomNumber)
                .HasComment("房间号 : 楼层房间号")
                .HasColumnName("ROOM_NUMBER");
            entity.Property(e => e.State)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasDefaultValueSql("('空')")
                .HasComment("状态")
                .HasColumnName("STATE");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("更新人")
                .HasColumnName("UPDATED_BY");
            entity.Property(e => e.UpdatedTime)
                .HasComment("更新时间")
                .HasColumnType("datetime")
                .HasColumnName("UPDATED_TIME");

            entity.HasOne(d => d.Build).WithMany(p => p.RoomInfos)
                .HasForeignKey(d => d.BuildId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ROOM_INFO_DORMITORY_BUILDING_INFO");
        });

        modelBuilder.Entity<Score>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SCORE", tb => tb.HasComment("查寝分数"));

            entity.Property(e => e.Old)
                .HasComment("是否最新学期")
                .HasColumnName("OLD");
            entity.Property(e => e.RoomId)
                .HasComment("房间标识")
                .HasColumnName("ROOM_ID");
            entity.Property(e => e.RoomScore)
                .HasComment("房间分数")
                .HasColumnName("ROOM_SCORE");
            entity.Property(e => e.ScoreTimes).HasColumnName("SCORE_TIMES");
            entity.Property(e => e.YearTerm)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasComment("年-学期;yyyy-0/1")
                .HasColumnName("YEAR_TERM");
        });

        modelBuilder.Entity<ScoreOld>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SCORE_OLD", tb => tb.HasComment("过往成绩"));

            entity.Property(e => e.RoomId)
                .HasComment("房间标识")
                .HasColumnName("ROOM_ID");
            entity.Property(e => e.RoomScore)
                .HasComment("房间分数")
                .HasColumnType("decimal(24, 6)")
                .HasColumnName("ROOM_SCORE");
            entity.Property(e => e.YearTerm)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("年;yyyyy-0/1")
                .HasColumnName("YEAR_TERM");
        });

        modelBuilder.Entity<ScoreStudent>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("SCORE_STUDENT");

            entity.Property(e => e.Role)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("ROLE");
            entity.Property(e => e.RoomScore)
                .HasColumnType("decimal(24, 6)")
                .HasColumnName("ROOM_SCORE");
            entity.Property(e => e.StudentId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("STUDENT_ID");
            entity.Property(e => e.StudentName)
                .HasMaxLength(90)
                .IsUnicode(false)
                .HasColumnName("STUDENT_NAME");
            entity.Property(e => e.YearTerm)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("YEAR_TERM");
        });

        modelBuilder.Entity<StudentsInfo>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__STUDENTS__E69FE77B6ADB052F");

            entity.ToTable("STUDENTS_INFO", tb => tb.HasComment("学生信息"));

            entity.HasIndex(e => new { e.CollegeId, e.Id }, "CLASS_INDEX");

            entity.HasIndex(e => e.IdentityCard, "IDCARD_INDEX").IsUnique();

            entity.Property(e => e.StudentId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("学号")
                .HasColumnName("STUDENT_ID");
            entity.Property(e => e.CollegeId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("学院代码")
                .HasColumnName("COLLEGE_ID");
            entity.Property(e => e.Gender)
                .HasComment("性别")
                .HasColumnName("GENDER");
            entity.Property(e => e.Id)
                .HasComment("详细班级代码")
                .HasColumnName("ID");
            entity.Property(e => e.IdentityCard)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("身份证")
                .HasColumnName("IDENTITY_CARD");
            entity.Property(e => e.Password)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("密码")
                .HasColumnName("PASSWORD");
            entity.Property(e => e.Power)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasDefaultValueSql("('普通学生')")
                .HasComment("权限")
                .HasColumnName("POWER");
            entity.Property(e => e.Status)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasDefaultValueSql("('正常')")
                .HasComment("状态")
                .HasColumnName("STATUS");
            entity.Property(e => e.StudentName)
                .HasMaxLength(90)
                .IsUnicode(false)
                .HasComment("姓名")
                .HasColumnName("STUDENT_NAME");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("更新人")
                .HasColumnName("UPDATED_BY");
            entity.Property(e => e.UpdatedTime)
                .HasComment("更新时间")
                .HasColumnType("datetime")
                .HasColumnName("UPDATED_TIME");

            entity.HasOne(d => d.College).WithMany(p => p.StudentsInfos)
                .HasForeignKey(d => d.CollegeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_STUDENTS_INFO_COLLEGE_INFO");

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.StudentsInfos)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_STUDENTS_INFO_DETAILED_CLASS_INFO");

            entity.HasOne(d => d.Student).WithOne(p => p.StudentsInfo)
                .HasForeignKey<StudentsInfo>(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_STUDENTS_INFO_LIVE_INFO");
        });

        modelBuilder.Entity<StudentsInformation>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("STUDENTS_INFORMATION");

            entity.Property(e => e.Additional)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("ADDITIONAL");
            entity.Property(e => e.AdminName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ADMIN_NAME");
            entity.Property(e => e.Class).HasColumnName("CLASS");
            entity.Property(e => e.ClassName)
                .HasMaxLength(90)
                .IsUnicode(false)
                .HasColumnName("CLASS_NAME");
            entity.Property(e => e.CollegeName)
                .HasMaxLength(90)
                .IsUnicode(false)
                .HasColumnName("COLLEGE_NAME");
            entity.Property(e => e.Gender)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("GENDER");
            entity.Property(e => e.Grade).HasColumnName("GRADE");
            entity.Property(e => e.IdentityCard)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("IDENTITY_CARD");
            entity.Property(e => e.Nature)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("NATURE");
            entity.Property(e => e.Power)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("POWER");
            entity.Property(e => e.Status)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("STATUS");
            entity.Property(e => e.StudentId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("STUDENT_ID");
            entity.Property(e => e.StudentName)
                .HasMaxLength(90)
                .IsUnicode(false)
                .HasColumnName("STUDENT_NAME");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.AdministeredId).HasName("PK__TEACHERS__9D2D4F9E2717AB85");

            entity.ToTable("TEACHERS", tb => tb.HasComment("老师/宿管信息"));

            entity.Property(e => e.AdministeredId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("同工号")
                .HasColumnName("ADMINISTERED_ID");
            entity.Property(e => e.AdminName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("姓名")
                .HasColumnName("ADMIN_NAME");
            entity.Property(e => e.Password)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("登陆密码")
                .HasColumnName("PASSWORD");
            entity.Property(e => e.Phone)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasComment("手机号")
                .HasColumnName("PHONE");
            entity.Property(e => e.Powers)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasDefaultValueSql("('班主任')")
                .HasComment("权限")
                .HasColumnName("POWERS");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("更新人")
                .HasColumnName("UPDATED_BY");
            entity.Property(e => e.UpdatedTime)
                .HasComment("更新时间")
                .HasColumnType("datetime")
                .HasColumnName("UPDATED_TIME");
        });

        modelBuilder.Entity<Traffic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TRAFFIC__3214EC2797428524");

            entity.ToTable("TRAFFIC", tb => tb.HasComment("人员流动"));

            entity.Property(e => e.Id)
                .HasComment("")
                .HasColumnName("ID");
            entity.Property(e => e.ComeTime)
                .HasComment("进时间")
                .HasColumnType("datetime")
                .HasColumnName("COME_TIME");
            entity.Property(e => e.Idcard)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("身份证")
                .HasColumnName("IDCARD");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("姓名")
                .HasColumnName("NAME");
            entity.Property(e => e.Notes)
                .HasMaxLength(900)
                .IsUnicode(false)
                .HasComment("备注")
                .HasColumnName("NOTES");
            entity.Property(e => e.OutTime)
                .HasComment("出时间")
                .HasColumnType("datetime")
                .HasColumnName("OUT_TIME");
            entity.Property(e => e.PhionNumber)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasComment("手机号")
                .HasColumnName("PHION_NUMBER");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasComment("更新人")
                .HasColumnName("UPDATED_BY");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
