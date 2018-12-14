using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using HtlWeiz.WkstPlaner.DataBaseHelper.Connect;

namespace HtlWeiz.WkstPlaner.DefOpTester.Init
{

    public enum EnumUser
    {
         HqHome
        ,HqRemote
          
    }
    static class InitConnection
    {

        public static IConnectionDefinition GetConnectionParameter(EnumUser user)
        {
            switch (user)
            {
                case EnumUser.HqHome:
                    return ConParHqHome();
                case EnumUser.HqRemote:
                    return ConParHqRemote();

            }
            ;

            return new MsSqlConnection();
        }

        private static IConnectionDefinition ConParHqHome()
        {
            var connection = new MsSqlConnection
            {
                Server = "HQDATABASES01\\MSSQL2016_DEV",
                Catalog = "WkstStPlan",
                UseWindowsAuthentication = true,
                MultipleActiveResultsets = true
            };

            return connection;

        }

        private static IConnectionDefinition ConParHqRemote()
        {
            var connection = new MsSqlConnection
            {
                Server = "HQDATABASES01\\MSSQL2016_DEV",
                Catalog = "WkstStPlan",
                UseWindowsAuthentication = false,
                User = "hquinz",
                Password = "purzl",
                MultipleActiveResultsets = true
            };

            return connection;

        }

    }
}
