using LouvOgRathApp.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LouvOgRathApp.ServerSide.DataAccess
{
    public class CasesDataAccess
    {
        private Executor executor;
        public CasesDataAccess()
        {
            Executor = new Executor(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=LouvOgRath;Integrated Security=True");
        }
        public Executor Executor
        {
            get { return executor; }
            set
            {
                (bool IsValid, string errorMsg) = ExecutorIsValid(value);
                if (IsValid)
                {
                    executor = value;
                }
                else
                {
                    throw new DataAccessException(errorMsg, new Exception());   
                }
            }
        }
        internal (bool, string) ExecutorIsValid(Executor executor)
        {
            if (executor != null)
            {
                return (true, String.Empty);
            }
            else
            {
                return (false, "it cant be null");
            }
        }
        public List<Case> GetAllCase()
        {
            List<Case> cases = new List<Case>();
            DataSet ds = Executor.Execute("SELECT * FROM GetAllCases");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Client tempClient = new Client(dr.Field<string>("clientFullname"));
                Lawyer tempLaw = new Lawyer(dr.Field<string>("LawyerFullname"));
                Secretary tempsec = new Secretary(dr.Field<string>("secretaryFullname"));
                CaseKind tempCaseK = (CaseKind)Enum.Parse(typeof(CaseKind), dr.Field<string>("caseKind"));
                MettingSummery tempSum = new MettingSummery(dr.Field<string>("résume"), tempsec);
                Case tempCase = new Case(dr.Field<string>("cases"), tempCaseK, tempLaw, tempClient, tempSum, dr.Field<int>("caseId"));
                cases.Add(tempCase);
            }
            return cases;
        }
        public void AddCase(Case @case)
        {
            Executor.Execute($"INSERT INTO Cases (Cases, CaseKindId, PersonId) VALUES ('{@case.CaseTitle}', {(int)@case.CaseKind}, {@case.Client.Id})");
        }
        public List<Case> GetCases()
        {
            List<Case> cases = new List<Case>();
            DataSet ds = Executor.Execute("SELECT * FROM Cases");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Case tempCase = new Case(dr.Field<string>("cases"), (CaseKind)Enum.Parse(typeof(CaseKind),dr.Field<int>("caseKindId").ToString()), new Person(dr.Field<int>("personId").ToString()));
                cases.Add(tempCase);
            }
            return cases;
        }
    }
}
