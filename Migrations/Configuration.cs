namespace project_asm.Migrations
{
    using project_asm.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<project_asm.Data.ExamContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(project_asm.Data.ExamContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var subjects = new List<Subject>
            {
                new Subject { SubjectName = "Core Java" , SubjectId = 1},
                new Subject { SubjectName = "Advance Java "  , SubjectId = 2},
                new Subject { SubjectName = "Programming C#"  , SubjectId = 3},

            };
            subjects.ForEach(s => context.Subject.AddOrUpdate(s));

            var rooms = new List<Room>
            {
                new Room { RoomName = "B10" , RoomId = 1},
                new Room { RoomName = "B16" , RoomId = 2},
                new Room { RoomName = "B14" , RoomId = 3},

            };
            rooms.ForEach(s => context.Room.AddOrUpdate(s));

            var faculties = new List<Faculty>
            {
                new Faculty { FacultyName = "Jayalakshmi" , FacultyId = 1},
                new Faculty { FacultyName = "Join Carter", FacultyId = 2},
                new Faculty { FacultyName = "HienPA" , FacultyId = 3},

            };
            faculties.ForEach(s => context.Faculty.AddOrUpdate(s));
            var exams = new List<Exam>
            {
                new Exam { SubjectId = 1,   StartTime = DateTime.Parse("13:30"), ExamDate= DateTime.Parse("2015-2-11"), ExamDuration=60, RoomId=1, FacultyId=1,Status=1 },
                new Exam { SubjectId = 2,   StartTime = DateTime.Parse("9:30"), ExamDate= DateTime.Parse("2015-5-20"), ExamDuration=60, RoomId=2, FacultyId=2,Status=2 },
                new Exam { SubjectId = 3,   StartTime = DateTime.Parse("9:30"), ExamDate= DateTime.Parse("2015-5-13"), ExamDuration=60, RoomId=3, FacultyId=3,Status=3 },
            };
            exams.ForEach(s => context.Exam.AddOrUpdate(s));

           
            context.SaveChanges();
        }
    }
}
