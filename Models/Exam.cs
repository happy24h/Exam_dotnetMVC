using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace project_asm.Models
{
    public class Exam
    {
        public Exam()
        {
            Status = 1;
        }

        public int ExamId { get; set; }
        public int SubjectId { get; set; }
        public int FacultyId { get; set; }
        public int RoomId { get; set; }
        [DisplayFormat(DataFormatString = "{HH:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ExamDate { get; set; }
        public int ExamDuration { get; set; }
        public int Status { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Faculty Faculty { get; set; }
        public virtual Room Room { get; set; }

    }
}