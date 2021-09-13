using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntouchBilling.Repository
{
    public sealed class ConnectionString
    {
        private static string Connectionstring = "DefaultConnection";

        public static string Value {
            get
            {
                return ConfigurationManager.ConnectionStrings[Connectionstring].ConnectionString;
            }
        }
    }
}
