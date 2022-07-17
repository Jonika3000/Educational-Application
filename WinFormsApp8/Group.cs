using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp8
{
    public class Group
    {
        public string NameOfGroup { get; set; }
        public List<StudentUser> users = new List<StudentUser>();
        public List<TeacherUser> teachers = new List<TeacherUser>();
    }
}
