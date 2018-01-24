using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LouvOgRathApp.Shared.Entities
{
    [Serializable]
    public class Client : Person
    {
        public Client(string fullname) : base(fullname)
        {
        }
        public Client(string fullname, int id) : base(fullname, id)
        {
        }
    }
}
