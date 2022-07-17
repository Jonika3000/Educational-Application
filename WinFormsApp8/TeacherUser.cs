using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp8
{
    public class TeacherUser
    {
        User user = new User();
        public Schedule schedule = new Schedule();
        public TeacherUser(User obj_r)
        {
            user = obj_r;
        }
    }
}
