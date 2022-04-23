using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project_asm.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public virtual ICollection<Exam> Exams { get; set; }
    }
}