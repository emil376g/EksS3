using LouvOgRathApp.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LouvOgRathApp.ServerSide.DataAccess
{
    public class SummeryDataAccess 
    {
        private Executor executor;
        public SummeryDataAccess()
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
        public List<MettingSummery> GetAllSummerysById()
        {
            List<MettingSummery> mettingSummery = new List<MettingSummery>();
            DataSet ds = Executor.Execute($"SELECT * FROM SelectSummerys");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Secretary tempsec = new Secretary(dr.Field<string>("secretaryFullname"));
                MettingSummery tempSum = new MettingSummery(dr.Field<string>("résume"), tempsec);
                mettingSummery.Add(tempSum);
            }
            return mettingSummery;
        }
        public void SafeSummery(MettingSummery summery)
        {
            Executor.Execute($"INSERT INTO Summery(CaseId, SecretaryId, résume) VALUES({1}, { summery.Secretary.Id}, '{ summery.Resumé}')");
        }
    }
}
