using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Contracts
{
    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
    }


    public class ConnectionStrings
    {
        public string DocumentModelConnectionString { get; set; }
    }
}
