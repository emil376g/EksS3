using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LouvOgRathApp.ServerSide.DataAccess
{
    public class UserCredentialsDataAccess : Executor
    {
        public UserCredentialsDataAccess(string connectionString) : base(connectionString)
        {
        }

        public override DataSet Execute(string sql)
        {
            return base.Execute(sql);
        }
    }
}
