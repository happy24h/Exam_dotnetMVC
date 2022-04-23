using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project_asm.Models
{
    public class Faculty
    {
        public int FacultyId { get; set; }
        public string FacultyName { get; set; }
        public virtual ICollection <Exam> Exams { get; set; }

    }
}