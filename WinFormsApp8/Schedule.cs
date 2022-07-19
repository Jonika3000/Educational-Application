using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp8
{
    [Serializable]
    public class Schedule
    {
        public Dictionary<DateTime, Subject> schedule = new Dictionary<DateTime, Subject>();
        //дата уроку и початок уроку
        public void Add(Subject s, DateTime d)
        {
            schedule.Add(d, s);
        }
        public void Delete(DateTime d)
        {
            schedule.Remove(d);
        }
    }
}
