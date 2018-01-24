using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LouvOgRathApp.Shared.Entities
{
    [Serializable]
    public class MettingSummery : IPersistable
    {
        readonly int id;
        string resumé;
        Secretary secretary;
        Case @case;

        public MettingSummery(string resumé, Secretary secretary, Case @case) : this (resumé, secretary)
        {
            Case = @case;
        }

        public MettingSummery(string resumé, Secretary secretary)
        {
            Resumé = resumé;
            Secretary = secretary;
            
        }
        public MettingSummery(string resumé, Secretary secretary, int id)
        {
            Resumé = resumé;
            Secretary = secretary;
            this.id = id;
        }

        public Case Case
        {
            get
            {
                return @case;
            }
            set
            {
                @case = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }
        }
        public string Resumé
        {
            get
            {
                return resumé;
            }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    resumé = value;
                }
                else
                {
                    throw new ArgumentNullException("it can't be null or whitespace");
                }
            }
        }
        public Secretary Secretary
        {
            get
            {
                return secretary;
            }
            set
            {
                secretary = value;
            }
        }
        public override string ToString()
        {
            return resumé;
        }
    }
}
