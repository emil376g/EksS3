using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LouvOgRathApp.Shared.Entities
{
    [Serializable]
    public class Case : IPersistable
    {
        readonly int id;
        string caseTitle;
        CaseKind caseKind;
        Person person;
        private Lawyer lawyer;
        private Client client;
        private MettingSummery mettingSummery;

        public Case(string caseTitle, CaseKind caseKind, Person person)
        {
            CaseTitle = caseTitle;
            CaseKind = caseKind;
            Person = person;
        }

        public Case(string caseTitle,  CaseKind caseKind, Lawyer lawyer, Client client, MettingSummery mettingSummery)
        {
            CaseTitle = caseTitle;
            CaseKind = caseKind;
            Lawyer = lawyer;
            Client = client;
            MettingSummery = mettingSummery;
        }
        public Case(string caseTitle, CaseKind caseKind, Lawyer lawyer, Client client, MettingSummery mettingSummery, int id) : this(caseTitle ,caseKind, lawyer, client, mettingSummery)
        {
            this.id = id;
        }
        public Person Person
        {
            get
            {
                return person;
            }
            set
            {
                person = value;
            }
        }
        public string CaseTitle
        {
            get
            {
                return caseTitle;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    caseTitle = value;
                }
                else
                {
                    throw new ArgumentNullException("it can't be null or empty");
                }
            }
        }
        public int Id
        {
            get
            {
                return id;
            }
        }

        public CaseKind CaseKind
        {
            get
            {
                return caseKind;
            }
            set
            {
                caseKind = value;
            }
        }
        public Lawyer Lawyer
        {
            get { return lawyer; }
            set { lawyer = value; }
        }
        public Client Client
        {
            get { return client; }
            set { client = value; }
        }
        public MettingSummery MettingSummery
        {
            get { return mettingSummery; }
            set { mettingSummery = value; }
        }
    }
}
