using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp8
{
    [Serializable]
    public class StudentUser
    {
        public Dictionary<Schedule, string> marks = new Dictionary<Schedule, string>();
        public User r = new User();
        public bool InGroup = false;
        public string Group { get; set; }
        public StudentUser(User r)
        {
            this.r = r;
        }
        public void AddMarks(string m,Schedule s)
        {
            marks.Add(s, m);
        }
    }
}
