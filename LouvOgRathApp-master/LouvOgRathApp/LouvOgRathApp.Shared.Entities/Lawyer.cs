using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LouvOgRathApp.Shared.Entities
{
    [Serializable]
    public class Lawyer : Person
    {
        public Lawyer(string fullname) : base(fullname)
        {
        }
        public Lawyer(string fullname, int id) : base(fullname, id)
        {
        }
    }
}
