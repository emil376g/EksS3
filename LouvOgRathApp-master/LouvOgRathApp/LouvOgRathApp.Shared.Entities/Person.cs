using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LouvOgRathApp.Shared.Entities
{
    [Serializable]
    public class Person : IPersistable
    {
        private readonly int id;
        private string fullname;
        public Person(string fullname)
        {
            Fullname = fullname;
        }
        public Person(string fullname, int id) : this(fullname)
        {
            this.id = id;
        }

        public int Id
        {
            get
            {
                return id;
            }
        }

        public string Fullname
        {
            get
            {
                return fullname;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    fullname = value;
                }
                else
                {
                    throw new ArgumentException("it cant be null or whitespace");
                }
            }
        }
        public override string ToString()
        {
            return Fullname;
        }

    }
}
