using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project_asm.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public virtual ICollection<Exam> Exams { get; set; }
    }
}