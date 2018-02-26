namespace TimeTrack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClockPunches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        PunchTypeId = c.Int(nullable: false),
                        PunchEventTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.PunchTypes", t => t.PunchTypeId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.PunchTypeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FullName = c.String(),
                        PositionId = c.Int(nullable: false),
                        WorkHours = c.String(),
                        Salary = c.Double(nullable: false),
                        OnProbation = c.Boolean(nullable: false),
                        SupervisorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Positions", t => t.PositionId, cascadeDelete: true)
                .ForeignKey("dbo.Supervisors", t => t.SupervisorId, cascadeDelete: true)
                .Index(t => t.PositionId)
                .Index(t => t.SupervisorId);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Supervisors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 25),
                        FullName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PunchTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmployeeHoursRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PayPeriodId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        TotalHoursWorked = c.Double(nullable: false),
                        WeekStart = c.DateTime(nullable: false),
                        WeekEnd = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.PayPeriods", t => t.PayPeriodId, cascadeDelete: true)
                .Index(t => t.PayPeriodId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.PayPeriods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        HolidayCreditHours = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FlagEventComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ScheduleFlagId = c.Int(nullable: false),
                        Author = c.String(),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ScheduleFlags", t => t.ScheduleFlagId, cascadeDelete: true)
                .Index(t => t.ScheduleFlagId);
            
            CreateTable(
                "dbo.ScheduleFlags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        ScheduleFlagTypeId = c.Int(nullable: false),
                        FlagDispositionTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.FlagDispositionTypes", t => t.FlagDispositionTypeId, cascadeDelete: true)
                .ForeignKey("dbo.ScheduleFlagTypes", t => t.ScheduleFlagTypeId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.ScheduleFlagTypeId)
                .Index(t => t.FlagDispositionTypeId);
            
            CreateTable(
                "dbo.FlagDispositionTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ScheduleFlagTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HolidayShortDays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                        HoursCredited = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OtRequestComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OtRequestId = c.Int(nullable: false),
                        Comment = c.String(),
                        Author = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OtRequests", t => t.OtRequestId, cascadeDelete: true)
                .Index(t => t.OtRequestId);
            
            CreateTable(
                "dbo.OtRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        DateOfRequest = c.DateTime(nullable: false),
                        TargetOtDate = c.DateTime(nullable: false),
                        NumberHoursRequested = c.Double(nullable: false),
                        ClientMatter = c.String(),
                        AttorneyRequested = c.Boolean(nullable: false),
                        SupervisorApproved = c.Boolean(nullable: false),
                        ApprovalDate = c.DateTime(nullable: false),
                        ApprovalComment = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.PayrollRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        PayPeriodId = c.Int(nullable: false),
                        TotalHoursWorked = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PayrollRecords", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.OtRequestComments", "OtRequestId", "dbo.OtRequests");
            DropForeignKey("dbo.OtRequests", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.FlagEventComments", "ScheduleFlagId", "dbo.ScheduleFlags");
            DropForeignKey("dbo.ScheduleFlags", "ScheduleFlagTypeId", "dbo.ScheduleFlagTypes");
            DropForeignKey("dbo.ScheduleFlags", "FlagDispositionTypeId", "dbo.FlagDispositionTypes");
            DropForeignKey("dbo.ScheduleFlags", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.EmployeeHoursRecords", "PayPeriodId", "dbo.PayPeriods");
            DropForeignKey("dbo.EmployeeHoursRecords", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.ClockPunches", "PunchTypeId", "dbo.PunchTypes");
            DropForeignKey("dbo.ClockPunches", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "SupervisorId", "dbo.Supervisors");
            DropForeignKey("dbo.Employees", "PositionId", "dbo.Positions");
            DropIndex("dbo.PayrollRecords", new[] { "EmployeeId" });
            DropIndex("dbo.OtRequests", new[] { "EmployeeId" });
            DropIndex("dbo.OtRequestComments", new[] { "OtRequestId" });
            DropIndex("dbo.ScheduleFlags", new[] { "FlagDispositionTypeId" });
            DropIndex("dbo.ScheduleFlags", new[] { "ScheduleFlagTypeId" });
            DropIndex("dbo.ScheduleFlags", new[] { "EmployeeId" });
            DropIndex("dbo.FlagEventComments", new[] { "ScheduleFlagId" });
            DropIndex("dbo.EmployeeHoursRecords", new[] { "EmployeeId" });
            DropIndex("dbo.EmployeeHoursRecords", new[] { "PayPeriodId" });
            DropIndex("dbo.Employees", new[] { "SupervisorId" });
            DropIndex("dbo.Employees", new[] { "PositionId" });
            DropIndex("dbo.ClockPunches", new[] { "PunchTypeId" });
            DropIndex("dbo.ClockPunches", new[] { "EmployeeId" });
            DropTable("dbo.PayrollRecords");
            DropTable("dbo.OtRequests");
            DropTable("dbo.OtRequestComments");
            DropTable("dbo.HolidayShortDays");
            DropTable("dbo.ScheduleFlagTypes");
            DropTable("dbo.FlagDispositionTypes");
            DropTable("dbo.ScheduleFlags");
            DropTable("dbo.FlagEventComments");
            DropTable("dbo.PayPeriods");
            DropTable("dbo.EmployeeHoursRecords");
            DropTable("dbo.PunchTypes");
            DropTable("dbo.Supervisors");
            DropTable("dbo.Positions");
            DropTable("dbo.Employees");
            DropTable("dbo.ClockPunches");
        }
    }
}
