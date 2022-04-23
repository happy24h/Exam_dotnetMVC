using project_asm.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace project_asm.Data
{
    public class ExamContext: DbContext
    {
        public ExamContext() : base("name=ThiExam")
        {
        }

        public DbSet<Exam> Exam { get; set; }
        public DbSet<Faculty> Faculty { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Subject> Subject { get; set; }
    }
}