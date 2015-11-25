using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace contoso.Models
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]

    public class contosoContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public class MyConfiguration : DbMigrationsConfiguration<contosoContext>
        {
            public MyConfiguration()
            {
                this.AutomaticMigrationsEnabled = true;
            }

            protected override void Seed(contosoContext context)
            {

                var courses = new List<Course>
            {
                new Course {CourseID = 1050, Title = "Compsci 101",      Points = 15, Assignments = "3 assignments", Tests ="1 test" },
                new Course {CourseID = 4022, Title = "Compsci 105", Points = 15, Assignments = "3 assignments", Tests ="1 test" },
                new Course {CourseID = 4041, Title = "Infosys 322", Points = 15, Assignments = "3 assignments", Tests ="1 test" },
                new Course {CourseID = 1045, Title = "Infosys 321",       Points = 15, Assignments = "no assignments", Tests ="2 tests" },

            };
                courses.ForEach(s => context.Courses.AddOrUpdate(p => p.Title, s));
                context.SaveChanges();
            }

        }

        public contosoContext() : base("name=contosoContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<contosoContext, MyConfiguration>());

        }

        public System.Data.Entity.DbSet<contoso.Models.Course> Courses { get; set; }
    }
}
