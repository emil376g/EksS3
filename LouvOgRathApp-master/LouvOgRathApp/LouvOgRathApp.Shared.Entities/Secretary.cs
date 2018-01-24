using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LouvOgRathApp.Shared.Entities
{
    [Serializable]
    public class Secretary : Person
    {
        public Secretary(string fullname) : base(fullname)
        {
        }
        public Secretary(string fullname, int id) : base(fullname, id)
        {
        }
    }
}
