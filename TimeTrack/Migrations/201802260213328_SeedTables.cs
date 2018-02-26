namespace TimeTrack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedTables : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Positions ([Name]) VALUES ('Secretary')");
            Sql("INSERT INTO Positions ([Name]) VALUES ('Paralegal')");
            Sql("INSERT INTO Positions ([Name]) VALUES ('Admin')");
            Sql("INSERT INTO Positions ([Name]) VALUES ('Contract')");
            Sql("INSERT INTO Positions ([Name]) VALUES ('Other')");

            Sql("INSERT INTO FlagDispositionTypes ([Name]) VALUES ('No action necessary / Approved')");
            Sql("INSERT INTO FlagDispositionTypes ([Name]) VALUES ('Explanation Required')");
            Sql("INSERT INTO FlagDispositionTypes ([Name]) VALUES ('Rejected')");

            Sql("INSERT INTO PunchTypes ([Name]) VALUES ('Clock In')");
            Sql("INSERT INTO PunchTypes ([Name]) VALUES ('Out to Lunch')");
            Sql("INSERT INTO PunchTypes ([Name]) VALUES ('Back from Lunch')");
            Sql("INSERT INTO PunchTypes ([Name]) VALUES ('Clock Out')");

            Sql("INSERT INTO ScheduleFlagTypes ([Name]) VALUES " +
                "('Arrived late')");

            Sql("INSERT INTO ScheduleFlagTypes ([Name]) VALUES " +
                "('Left early')");

            Sql("INSERT INTO ScheduleFlagTypes ([Name]) VALUES " +
                "('Long lunch')");

            Sql("INSERT INTO ScheduleFlagTypes ([Name]) VALUES " +
                "('Short lunch')");

            Sql("INSERT INTO ScheduleFlagTypes ([Name]) VALUES " +
                "('Unapproved overtime')");

            Sql("INSERT INTO ScheduleFlagTypes ([Name]) VALUES " +
                "('Missed punch')");

            Sql("INSERT INTO ScheduleFlagTypes ([Name]) VALUES " +
                "('Absence')");


        }
        
        public override void Down()
        {
        }
    }
}
