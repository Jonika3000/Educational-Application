using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp8
{
    public class StudentUser
    {
        public Dictionary<Schedule,int> marks = new Dictionary<Schedule,int>();
        public User r = new User();
        public string Group { get; set; }
        public StudentUser(User r)
        {
            this.r = r;
        }
        public void AddMarks(int m,Schedule s)
        {
            marks.Add(s, m);
        }
    }
}
