using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp8
{
    internal class Schedule
    {
        Dictionary<DateTime, Subject> schedule = new Dictionary<DateTime, Subject>();
        public void Add(Subject s , DateTime d)
        {
            schedule.Add(d ,  s);
        }
    }
}
