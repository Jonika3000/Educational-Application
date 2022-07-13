using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp8
{
    public class Subject
    {
        public string Name { get; set; }
         public DateTime time { get; set; }
        public Subject(string name, DateTime time)
        {
            Name = name;
            this.time = time;
        }
    }
}
