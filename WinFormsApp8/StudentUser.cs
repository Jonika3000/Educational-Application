using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp8
{
    public class StudentUser
    {
        Dictionary<Schedule,int> marks = new Dictionary<Schedule,int>();
        User r = new User();
        public string Group { get; set; }
        public StudentUser(User r)
        {
            this.r = r;
        }
    }
}
