namespace TimeTrack.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class EmployeeContext : DbContext
    {
        // Your context has been configured to use a 'EmployeeContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'TimeTrack.Models.EmployeeContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'EmployeeContext' 
        // connection string in the application configuration file.
        public EmployeeContext()
            : base("name=EmployeeContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<ClockPunch> ClockPunches { get; set; }

        public DbSet<EmployeeHoursRecord> EmployeeHoursRecords { get; set; }

        public DbSet<PayPeriod> PayPeriods { get; set; }

        public DbSet<PayrollRecord> PayrollRecords { get; set; }

        public DbSet<ScheduleFlag> ScheduleFlags { get; set; }
        public DbSet<FlagEventComment> FlagEventComments { get; set; }
        public DbSet<OtRequest> OtRequests { get; set; }
        public DbSet<OtRequestComment> OtRequestComments { get; set; }
        public DbSet<HolidayShortDay> HolidayShortDays { get; set; }



        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}