using System.Data.SqlClient;

namespace HtlWeiz.WkstPlaner.DataBaseHelper.Connect

{
    public class MsSqlConnection : IConnectionDefinition
    {
        #region connection Parameter

        public string Server { get;  set; }
        public string Catalog { get; set; }
        public bool UseWindowsAuthentication { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public int Timeout { get; set; } = 15;
        public bool MultipleActiveResultsets { get; set; }
        #endregion

        #region States

        public string State { get; private set; }
        /// <inheritdoc />
        /// <summary>
        /// Connection Data spezified
        /// </summary>
        public bool CanConnect => CheckServerParameter();
        /// <inheritdoc />
        /// <summary>
        /// Conection Data and Catalog spezified
        /// </summary>
        public bool CanAccessData => CheckAllParameter();
        #endregion

        public string ConnectionString => GenerateConnectionString();


        public MsSqlConnection() {}


        private bool CheckServerParameter()
        {
            if (string.IsNullOrEmpty(Server))
            {
                State = "No Servername specified!";
                return false;
            }

            if (UseWindowsAuthentication)
            {
                State = "ready";
                return true;
            }

            if (string.IsNullOrEmpty(User))
            {
                State = "Need User to be specified! (Or Windows Authentificaton)";
                return false;

            }

            if (string.IsNullOrEmpty(Password))
            {
                State = "No Password specified!";
                return false;

            }

            State = "ready";
            return true;

        }

        private bool CheckAllParameter()
        {
            if (!string.IsNullOrEmpty(Catalog)) return CheckServerParameter();
            State = "Need Catalog to be specified!";
            return false;
        }


        private string GenerateConnectionString()
        {
            if (!CheckServerParameter()) return "";

            var builder = new SqlConnectionStringBuilder { DataSource = Server };

            if (UseWindowsAuthentication)
            {
                builder.IntegratedSecurity = true;
            }
            else
            {
                builder.UserID = User;
                builder.Password = Password;
                builder.IntegratedSecurity = false;
            }

            builder.ConnectTimeout = Timeout;
            if (!string.IsNullOrEmpty(Catalog)) builder.InitialCatalog = Catalog;
            builder.MultipleActiveResultSets = MultipleActiveResultsets;
            
            return builder.ConnectionString;
        }

        public override string ToString()
        {
            return GenerateConnectionString();
        }
    }



}

    
