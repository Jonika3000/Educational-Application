using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp8
{
    internal class Subject
    {
        public string Name { get; set; }
         public DateTime time { get; set; }
        Subject(string name, DateTime time)
        {
            Name = name;
            this.time = time;
        }
    }
}
