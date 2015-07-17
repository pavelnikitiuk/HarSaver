using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarSaver.Models
{

    public class Timings
    {
        public float blocked { get;  set; }
        public float dns { get;  set; }
        public float connect { get;  set; }
        public float send { get;  set; }
        public float wait { get;  set; }
        public float receive { get;  set; }
        public float ssl { get;  set; }
    }

}
